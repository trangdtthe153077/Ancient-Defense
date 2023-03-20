using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class Witch : Archer{
    public float delay = 25f;
    public float mana = 20;
    public float price = 500;
    public int level = 1;
    public float upgradeprice;
    public float skilldmg = 15*2;
    void Start()
    {
        Damage = 15;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
 
    public void LevelUp()
    {
        level += 1;
        mana += 2;
          Damage += 2;
        skilldmg = (float)(skilldmg + (Damage * 0.2));
        upgradeprice = (500 * (level - 1) / 5) + 500; ;
    }

    public void OnButtonClick()
    {

  
    }

}
