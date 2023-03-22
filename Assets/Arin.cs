using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Arin : Archer{
<<<<<<< HEAD
    public float delay = 25f;
    public float mana = 20;
    public float price = 500; 
    void Start()
    {
        
=======
    public float delay;
    public float mana;
    public float price = 500;
    public int level = 1;
    public float upgradeprice;
    GoldManager goldManager;
    void Start()
    {
        goldManager = GameObject.FindGameObjectWithTag("Gold").GetComponent<GoldManager>();
        Basedmg = 10;
        Damage = Basedmg;
        Speed = 1f;
        delay = 25;
        mana = 20;
        upgradeprice = 500;
>>>>>>> parent of 077d4e0 (fix bug)
    }

    // Update is called once per frame
    void Update()
    {
        
<<<<<<< HEAD
    }
    public void CallSolider()
    {
        Debug.Log("Skill used!");
    
    }

=======
    }

    public bool LevelUp()
    {
      
     if   (goldManager.currnetGold> upgradeprice)
        {
            goldManager.addGold((int)- upgradeprice);
            level += 1;
        mana += 1;
        Basedmg += 2;
        upgradeprice = (price * (level - 1) / 5) + price;
            return true;
        }
        return false;
    }
    public void setLevel(int lv)
    {
        lv = lv - 1;
        level +=lv;
        mana += lv;
        Basedmg += 2*lv;
        upgradeprice = (price * (level - 1) / 5) + price;
    }
    public float getLevel()
    {
        return level;
    }
>>>>>>> parent of 077d4e0 (fix bug)
}
