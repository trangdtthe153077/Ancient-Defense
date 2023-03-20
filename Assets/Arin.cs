using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Arin : Archer{
    public float delay = 25f;
    public float mana = 20;
    public float price = 500;
    public int level = 1;
    public float upgradeprice;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CallSolider()
    {
        Debug.Log("Skill used!");
    
    }

    public void UpgradeLevel()
    {

    }

    public void LevelUp()
    {
        level += 1;
        mana += 1;
        Basedmg += 2;
        upgradeprice = (500 * (level - 1) / 5) + 500; ;
    }

}
