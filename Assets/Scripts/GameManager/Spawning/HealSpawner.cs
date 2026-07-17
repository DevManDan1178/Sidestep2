using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    public GameObject heal;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float TimeBetweenSpawns;
    public float SpawnTime;

    public bool spawnIncrease = false;
    
    public float spawnDecreaseInterval;

    public float SpawnCountown;

    private float originalSDInterval;

    public float spawnDecrease;

    public int maxSpawnDecrease;

    // Update is called once per frame
    void Start() 
    {
        SpawnTime = SpawnCountown;
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
        if(spawnIncrease == true)

        spawnDecreaseInterval -= Time.deltaTime;
        
        if(spawnDecreaseInterval <= 0.0 && TimeBetweenSpawns > maxSpawnDecrease)
        {
        spawnDecreaseInterval = originalSDInterval;
        TimeBetweenSpawns -= spawnDecrease;    
        } 
    }

    void Spawn()
    {
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);

        Instantiate(heal, transform.position + new Vector3(X, Y, 0), transform.rotation);    
    }

      
}
