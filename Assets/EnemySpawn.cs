using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField]
    GameObject prefabEnemy;

    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;
    Timer spawnTimer;

    const int SpawnBorderSize = 100;
    int minSpawnX;
    int minSpawnY;
    int maxSpawnX;
    int maxSpawnY;
    
    // Start is called before the first frame update
    void Start()
    {
        minSpawnX= SpawnBorderSize;
        minSpawnY= SpawnBorderSize;
        maxSpawnX= Screen.width - SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        spawnTimer = gameObject.AddComponent<Timer>();
       // spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnEnemy();
         //   spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
        
    }
    void SpawnEnemy()
    {
      //  Vector3 location  = new Vector3(Random.Range(minSpawnX,maxSpawnX),Random.Range(minSpawnY,maxSpawnY),- Camera.main.transform.position.z);
       // Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
       // GameObject enemy = Instantiate(prefabEnemy) as GameObject;
       // enemy.transform.position = worldLocation;


    }
}
