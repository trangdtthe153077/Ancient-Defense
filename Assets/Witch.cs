using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class Witch : Archer
{
    public float delay = 25f;
    public float mana = 20;
    public float price = 1000;
    public int level = 1;
    public float upgradeprice;
    public float skilldmg = 15 * 2;
    GoldManager goldManager;
    Archer archer;


    void Start()
    {
        archer = gameObject.GetComponent<Archer>();

        goldManager = GameObject.FindGameObjectWithTag("Gold").GetComponent<GoldManager>();
        Basedmg = 15;
        Damage = Basedmg;
        mana = 40;
        Speed = 1.25f;
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
            skilldmg = Basedmg * 2 + Basedmg;
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
        mana += lv*2;
        Basedmg += lv*2;
        skilldmg = Basedmg * 2 + Basedmg;
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
