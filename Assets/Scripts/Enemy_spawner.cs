using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    [SerializeField]  float spawnRatePerMinute = 10f;
    [SerializeField]  float spawnRateIncrement = 1f;
    [SerializeField]  float y_spawn,z_spawn;
    private float spawnNext = 0;
    [SerializeField]  float x_limit;
    [SerializeField]  float maxLifeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext){
            spawnNext = Time.time + 60/spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-x_limit,x_limit);

            Vector3 spawnPosition = new Vector3(x:rand,y:y_spawn,z:z_spawn);

            GameObject meteor = Instantiate(asteroidPrefab,spawnPosition, Quaternion.identity);

            Destroy(meteor, maxLifeTime);
        }  
    }
}
