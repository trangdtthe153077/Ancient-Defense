using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyFlyPrefab;
    public Transform eneflyTransform;
    public int currentEnemyChosen;
    List<GameObject> enemies = new List<GameObject>();
    public float waveInterval = 10;
    public float spawnInterval;
    public int maxEnemiesPerWave = 10;
    public int bossWaveInterval = 5;
    public GameObject bossPrefab;

    private int currentLevel = 1;
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

    Tower tower;
    private void Start()
    {
        enemies.Add(enemyPrefab);
        timing = GetComponent<Timer>();

        timing.Duration = 1;
        timing.Run();
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
        StartGame();

        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();
    }

    private void Update()
    {

        if (newGame == false)
        {
            StartGame();
        }
        if (inGame == true)

        {
            SpawnInGame();
        }


    }

    public void SpawnInGame()
    {

        if (tower.getHealth() <= 0)
        {
            Debug.Log("Loooossssssssseeeeeeeee game");
            gameStateController.ReturnLoose();
            inGame = false;
            newGame = false;
            tower.ResetTower();
            return;
        }


        if (enemiesToSpawn > 0 && timer >= spawnInterval)
        {
            SpawnEnemy(currentEnemyChosen);
            timer = 0f;
            enemiesToSpawn--;
        }

        timer += Time.deltaTime;

        if (isBoss == true)
        {
            if (WinTheGame())
            {
                Debug.Log("WIn win win win game");
                gameStateController.ReturnWaiting();
                inGame = false;
                newGame = false;
                tower.ResetTower();
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
        if (currentLevel == 5)
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
        isSpawning = false;
        isBoss = false;
        newGame = true;
    }

    private void SpawnEnemy(int i)
    {

        Debug.Log("Total enemies: " + enemies.Count);
        if (i == 1)
        {
            var enemy = Instantiate(enemies[i], eneflyTransform.transform.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetLevel(currentLevel);
            enemy.tag = "Enemy";
        }
        else
        {
            var enemy = Instantiate(enemies[i], transform.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetLevel(currentLevel);
            enemy.tag = "Enemy";
        }


    }

    private void SpawnBoss()
    {
     var boss=   Instantiate(bossPrefab, transform.position, Quaternion.identity);
        boss.GetComponent<Enemy>().setDmgBoss();
       boss.GetComponent<Enemy>().SetLevel(currentLevel);

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
        if (currentLevel % 5 == 1 || currentLevel % 5 == 2)
        {
            return 4 + i;
        }
        return 5 + i;

    }
    public bool WinTheGame()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
