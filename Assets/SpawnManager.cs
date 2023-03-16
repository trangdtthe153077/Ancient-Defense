using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyFlyPrefab;

    public int currentEnemyChosen;
    List<GameObject> enemies = new List<GameObject>();
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

    int maxEnemyWave;
    int minEnemyWave;

    Timer timing;
    bool isSpawning = false;
    bool isBoss = false;

    bool inGame = false;

    bool newGame = false;
    GameStateController gameStateController;
    private void Start()
    {
        enemies.Add(enemyPrefab);
        timing = GetComponent<Timer>();
      
        timing.Duration = 1;
        timing.Run();
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
        StartGame();
    }

    private void Update()
    {
        if(newGame==false)
        {
            StartGame();
        }    
        if(inGame==true)

        {
            SpawnInGame();
        }
      
      
    }

    public void SpawnInGame()
    {
        if (enemiesToSpawn > 0 && timer >= spawnInterval)
        {
            SpawnEnemy(currentEnemyChosen);
            timer = 0f;
            enemiesToSpawn--;
        }

        timer += Time.deltaTime;

    if(isBoss==true)
        {
           if( WinTheGame())
            {
                Debug.Log("WIn win win win game");
                gameStateController.ReturnWaiting();
                inGame = false;
                newGame = false;
            }    
        }    

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
                else
                {
                    isBoss = true;
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
    public void StartGame()
    {
        if(currentLevel==6 )
        {
            enemies.Add(enemyFlyPrefab);
            Debug.Log("Add new enemy");
        }    
        minEnemyWave = currentLevel / 10 + 3;
        maxEnemyWave = minEnemyWave + 2;
        Debug.Log("Spawn min: " + minEnemyWave + ", max: " + maxEnemyWave);
        currentWave = 1;
        maxWave = NumberWave();
        SpawnWave();
        isSpawning=false;
        isBoss = false;
        newGame = true;
    }    

    private void SpawnEnemy(int i)
    {
    
        Debug.Log("Total enemies: "+enemies.Count);
      var enemy= Instantiate(enemies[i], transform.position, Quaternion.identity);
        enemy.tag = "Enemy";
   /*     var enemyfly = Instantiate(enemyFlyPrefab, transform.position, Quaternion.identity);
        enemyfly.tag = "Enemy";*/
    }

    private void SpawnBoss()
    {
        Instantiate(bossPrefab, transform.position, Quaternion.identity);
    }

    private void SpawnWave()
    {
      

        enemiesToSpawn = Random.Range(minEnemyWave, maxEnemyWave);
        currentWave++;
        Debug.Log(spawnInterval);
        spawnInterval = 7 / enemiesToSpawn;
        Debug.Log(spawnInterval);
    currentEnemyChosen = Random.Range(0, enemies.Count); 


    }
private int NumberWave()
    {
        var i = currentLevel / 20;
        if (i > 5)
            i = 5;    
       if(currentLevel%5==1 || currentLevel % 5 == 2)
        {
            return 4 +i;
        }
        return 5+i;

    }
    public bool WinTheGame()
    {
   var enemies =     GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Checking enemy all dead");
        /*  var boss = GameObject.FindGameObjectsWithTag("Boss");*/
        if (enemies.Length == 0)
        {
            Debug.Log("All enemies dead");
            return true;
        }
        return false;
    }    
 
}
