using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class TX : Archer{
   
    public int manatower;
    public float delay = 20f;
    public int mana = 50;
    public float price = 1500;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;
    public Button btn;
    GameStateController gameStateController;
    GoldManager goldManager;

    public float upgradeprice;
    Archer archer;


    void Start()
    {
        archer = gameObject.GetComponent<Archer>();
        goldManager = GameObject.FindGameObjectWithTag("Gold").GetComponent<GoldManager>();
        Basedmg = 10;
        Damage = Basedmg;
        Speed = 0.75f;
        delay = 25;
        mana = 40;
        upgradeprice = 500;
        skilldmg = (float)(2.5 / 100);
        archer.Damage = Basedmg;
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    public bool LevelUp()
    {
        if (goldManager.currnetGold > upgradeprice)
        {
            goldManager.addGold((int)-upgradeprice);
            level += 1;
            mana += 2;
            Basedmg += 2;
            Damage = Basedmg;
            skilldmg = (float)((Basedmg * 0.05 * level) + Basedmg); ;
            upgradeprice = (price * (level - 1) / 5) + price;
            archer.Damage = Basedmg;
            return true;
        }
        return false;
    }
    public void setLevel(int lv)
    {
        lv = lv - 1;
        level += lv;
        mana += lv * 2;
        Basedmg += lv * 2;
        Damage = Basedmg;
        skilldmg = (float)((Basedmg * 0.05 * level) + Basedmg); ;
        upgradeprice = (price * (level - 1) / 5) + price;
        archer.Damage = Basedmg;

    }
    public void OnButtonClick()
    {

      
    }
    public float getLevel()
    {
        return level;
    }

}
