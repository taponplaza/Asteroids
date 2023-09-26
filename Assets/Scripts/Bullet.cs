using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] int speed = 10;
    [SerializeField] float maxLifeTime = 3;
     public GameObject fragmentPrefab;
    
    public Vector3 targetVector;    
    void Start()
    {
        // nada más nacer, le damos unos segundos de vida,
        // lo suficiente para salir de la pantalla
        Destroy(gameObject, maxLifeTime);
    }
    void Update()
    {
        // la bala se mueve en la dirección del jugador al disparar
        transform.Translate(targetVector * speed * Time.deltaTime);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            IncrementScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void IncrementScore()
    {
        Player.SCORE += 100;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos : " + Player.SCORE;
    }
    
}
