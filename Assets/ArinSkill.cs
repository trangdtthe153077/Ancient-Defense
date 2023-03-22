using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class ArinSkill : Archer
{
    private Tower tower;
    public int manatower;
    public float delay = 30f;
    public int mana = 50;
    public float price = 500;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;
    public Button btn;
    GameStateController gameStateController;
    Timer timer;
    Timer delayTimer;
    bool delayFinished = false;
    bool success = false;
    public GameObject Soldier;
    public float spacing=10;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.Duration = 5f;
        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();
        manatower = tower.getMana();
        Debug.Log("mana tower: " + manatower);
        Debug.Log("bonk");
        btn = GetComponent<Button>();
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (success == true && timer.Finished)
        {
            success = false;
            StopIncreasing();
        }
    }
    public void CallSolider()
    {
        Debug.Log("Skill used!");

    }

    public void LevelUp()
    {
        level += 1;
        mana += 2;
        skilldmg += (float)2.5 / 100;
        efftime += (float)0.2;

    }

    public void OnButtonClick()
    {

        Debug.Log("BUtton called");
        if ((manatower - mana >= 0) && success == false && (delayTimer.Finished || delayFinished == false))
        {
            manatower = manatower - mana;
            tower.setMana(manatower);
            Debug.Log("mana: " + manatower);
            delayTimer.Run();
            timer.Run();
            success = true;
            delayFinished = true;
            SkillSpawnSoldier();
        }

    }


    public void SkillSpawnSoldier()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Spawn quái number " + i);
            // Tạo ra một instance của prefab
            GameObject obj = Instantiate(Soldier, transform);
            // Đặt vị trí của đối tượng
            float xPos = -2.44f + i * 2;
            float yPos = -5.18f;
            obj.transform.position = new Vector3(xPos, yPos, 100);
        }
    }

    public void StopIncreasing()
    {

        Archer[] archers = FindObjectsOfType<Archer>();
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Basedmg;
            Debug.Log("DMG archer:" + archer.Damage);
        }
    }
}