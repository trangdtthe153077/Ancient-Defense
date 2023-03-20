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
    public float price = 500;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;
    public Button btn;
    GameStateController gameStateController;

    public float upgradeprice;
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    public void LevelUp()
    {
        level += 1;
        mana += 1;
        Damage += 2;
        skilldmg = skilldmg + 5 / 100 * skilldmg;
        upgradeprice = (500 * (level - 1) / 5) + 500; ;
    }

    public void OnButtonClick()
    {

      
    }

}
