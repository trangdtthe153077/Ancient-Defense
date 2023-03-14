using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyFlyPrefab;

    public float waveInterval=10;
    public float spawnInterval;
    public int maxEnemiesPerWave = 10;
    public int bossWaveInterval = 5;
    public GameObject bossPrefab;

    private int currentLevel = 5;
    private int currentWave = 1;
    private int enemiesToSpawn = 0;
    private float timer = 0f;
    private int maxWave;
    Timer timing;
    bool isSpawning = false;
    bool isBoss = false;

    bool inGame = false;
    private void Start()
    {
        timing = GetComponent<Timer>();
        maxWave= NumberWave();
        SpawnWave();
        timing.Duration = 1;
        timing.Run();
    }

    private void Update()
    {
        if(inGame==true)

        {
            SpawnInGame();
        }
      
      
    }

    public void SpawnInGame()
    {
        if (enemiesToSpawn > 0 && timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
            enemiesToSpawn--;
        }

        timer += Time.deltaTime;



        if (enemiesToSpawn == 0)
        {
            if (isSpawning == false)
            {
                timing.Run();
                isSpawning = true;
            }


            if (timing.Finished)
            {
                Debug.Log("Finished");
                if (currentWave == maxWave && currentLevel % 5 == 0 && isBoss == false)
                {
                    isBoss = true;
                    SpawnBoss();
                    Debug.Log("WIn the game");
                }
                else if (currentWave < maxWave)
                {
                    SpawnWave();
                    timing.Run();
                    Debug.Log("Wait");
                }
                isSpawning = false;
            }

        }
    }    

    public void SetLevelOfGame(int lv)
    {
        currentLevel = lv;
        inGame = true;
    }    

    private void SpawnEnemy()
    {
      var enemy=  Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.tag = "Enemy";
        var enemyfly = Instantiate(enemyFlyPrefab, transform.position, Quaternion.identity);
        enemyfly.tag = "Enemy fly";
    }

    private void SpawnBoss()
    {
        Instantiate(bossPrefab, transform.position, Quaternion.identity);
    }

    private void SpawnWave()
    {
      

        enemiesToSpawn = Random.Range(3, 6);
        currentWave++;
        Debug.Log(spawnInterval);
        spawnInterval = 7 / enemiesToSpawn;
        Debug.Log(spawnInterval);
  
    }
    private int NumberWave()
    {

       if(currentLevel%5==1 || currentLevel % 5 == 2)
        {
            return 4;
        }
        return 5;

    }
 
}
