using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float TimeBetweenSpawns;
    public float SpawnTime;

    public bool difficultyIncrease = false;

    public float spawnDecreaseInterval = 10f;

    public float spawnDecrease = 0.05f;

    private float originalSDInterval;

    // Update is called once per frame

   void Start() 
    {
        originalSDInterval = spawnDecreaseInterval;
    }
    
    void Update()
    {
        SpawnTime -= Time.deltaTime;

        if(SpawnTime <= 0)
        {
            Spawn();
            SpawnTime = TimeBetweenSpawns;
        }
        if(difficultyIncrease == true)

        spawnDecreaseInterval -= Time.deltaTime;
        
        if(spawnDecreaseInterval <= 0.0 && TimeBetweenSpawns > 0.75)
        {
        spawnDecreaseInterval = originalSDInterval;
        TimeBetweenSpawns -= spawnDecrease;    
        } 
    }

    void Spawn()
    {
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);

        Instantiate(Obstacle, transform.position + new Vector3(X, Y, 0), transform.rotation); 
        

    }

           
}
