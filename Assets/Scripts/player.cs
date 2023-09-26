using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float thrustForce = 5f;
    [SerializeField] float rotationSpeed = 120f;
    public static int SCORE = 0;
    public float xBorderLimit,yBorderLimit;
    [SerializeField] GameObject gun,_bulletPrefab;
    

    Vector2 thrustDirection;
    Rigidbody _rigidbody;
    void Start()
    {
        // rigidbody nos permite aplicar fuerzas en el jugador
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
        {
            InfiniteRespawn();

            // obtenemos las pulsaciones de teclado
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            float thrust = Input.GetAxis("Vertical") * thrustForce;
            // la dirección de empuje por defecto es .right (el eje X positivo)
            thrustDirection = transform.right;
            // rotamos con el eje "Rotate" negativo para que la dirección sea correcta
            transform.Rotate(Vector3.forward, -rotation);
            // añadimos la fuerza capturada arriba a la nave del jugador
            _rigidbody.AddForce(thrust * thrustDirection);

            if(Input.GetKeyDown(KeyCode.Space)){
                GameObject bullet = Instantiate(_bulletPrefab,gun.transform.position, Quaternion.identity);

                Bullet basascript = bullet.GetComponent<Bullet>();

                basascript.targetVector = transform.right;
            }
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void InfiniteRespawn()
    {
        var newPos = transform.position;
        if (newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit+1;
        else if (newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit-1;
        else if (newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit+1;
        else if (newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit-1;
        transform.position = newPos;
    }
}
