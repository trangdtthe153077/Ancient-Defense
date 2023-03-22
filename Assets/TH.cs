﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class TH : Archer
{
    private Tower tower;
    public int manatower;
    public float delay = 30f;
    public int mana = 50;
    public float price = 2000;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;
    public Button btn;
    GameStateController gameStateController;
    Timer timer;
    Timer delayTimer;
    bool delayFinished = false;
    bool success = false;
    public GameObject Golem;
    public float upgradeprice;
 

    GoldManager goldManager;
    Archer archer;


    void Start()
    {
        archer = gameObject.GetComponent<Archer>();
        goldManager = GameObject.FindGameObjectWithTag("Gold").GetComponent<GoldManager>();

        //setup character

        Basedmg = 15;
        Damage = Basedmg;
        Speed = 1f;
        delay = 30;
        mana = 30;
        upgradeprice = price;
        skilldmg = (float)(2.5 / 100);

        //---------------------------------





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
        archer.Damage = Basedmg;
    }

    // Update is called once per frame
    void Update()
    {
        if (success == true && timer.Finished)
        {
            success = false;
  
        }
    }
    public void CallSolider()
    {
        Debug.Log("Skill used!");

    }

    public bool LevelUp()
    {
        if (goldManager.currnetGold > upgradeprice)
        {
            Basedmg +=2;
            Damage = Basedmg;
            goldManager.addGold((int)-upgradeprice);
            level += 1;
            mana += 2;
            upgradeprice = (price * (level - 1) / 5) + price;
            archer.Damage = Basedmg;
            return true;
        }
        return false;
    }
    public void setLevel(int lv)
    {
        Basedmg +=2*lv;
        Damage = Basedmg;
        lv = lv - 1;
        level += lv;
        mana += lv * 2;
        upgradeprice = (price * (level - 1) / 5) + price;
        archer.Damage = Basedmg;
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
            SkillSpawnGolem();
        }
   
    }

    
    public void SkillSpawnGolem()
    {
        // Tạo ra một instance của prefab
        GameObject obj = Instantiate(Golem, transform);
        obj.gameObject.GetComponent<GolemMOving>().setUp((int)level, Basedmg);
        // Đặt vị trí của đối tượng
        float xPos = -1.64f;
        float yPos = -3.58f;
        obj.transform.position = new Vector3(xPos, yPos, 100);
        success = false;
    }


    public float getLevel()
    {
        return level;
    }    


    
}
