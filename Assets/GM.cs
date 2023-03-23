using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class GM : Archer{
    private Tower tower;
    public int manatower;
    public float delay = 30f;
    public int mana = 50;
    public float price = 1500;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;
    public Button btn;
    GameStateController gameStateController;
    Timer timer;
    Timer delayTimer;
    bool delayFinished=false;
    bool success = false;
    public float upgradeprice;

    GoldManager goldManager;
    Archer archer;


    void Start()
    {
        archer = gameObject.GetComponent<Archer>();
        goldManager = GameObject.FindGameObjectWithTag("Gold").GetComponent<GoldManager>();
//set up char
        Basedmg = 10;
        Damage = Basedmg;
        Speed = 1f;
        delay = 30;
        mana = 50;
        upgradeprice = price;
        skilldmg = 0.5f;
        efftime = 5f;



        //--------------------------------------
        timer =  gameObject.AddComponent<Timer>();
   
        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.Duration = 5f;
   tower= GameObject.FindWithTag("Tower").GetComponent<Tower>();
     
        Debug.Log("mana tower: "+manatower);
        Debug.Log("bonk");
         btn = GetComponent<Button>();
      
        gameStateController  = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
        archer.Damage = Basedmg;
    }

    // Update is called once per frame
    void Update()
    {
        manatower = tower.getMana();
        if (success==true && timer.Finished )
        {
            Debug.Log("time end");
            success = false;
            StopIncreasing();
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
            goldManager.addGold((int)-upgradeprice);
            level += 1;
            mana += 2;
            Basedmg += 2;
            Damage = Basedmg;
            skilldmg = 0.5f + (0.025f * level);
            efftime += 0.2f;
            upgradeprice = (500 * (level - 1) / 5) + 500; ;
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
        skilldmg = 0.5f + (0.025f * level);
        efftime += 0.2f*lv;
        upgradeprice = (500 * (level - 1) / 5) + 500;
        archer.Damage = Basedmg;
    }
    public void OnButtonClick()
    {

        Debug.Log("time start BUtton called");
        if ((manatower-mana>=0)&& success == false && ( delayTimer.Finished || delayFinished==false))
        {
            timer.Duration = efftime;
            manatower = manatower - mana;
            tower.setMana(manatower);
            Debug.Log("mana: "+ manatower);
            delayTimer.Run();
            timer.Run();
            success = true;
            delayFinished = true;
            SkillIncreaseDamage();
        } 
 
    }

    public void SkillIncreaseDamage()
    {
      
      
            Archer[] archers = FindObjectsOfType<Archer>();

        GameObject [] archerColor = GameObject.FindGameObjectsWithTag("Archer");
        foreach(var item in archerColor)
        {
            var m_SpriteRenderer = item.GetComponent<SpriteRenderer>();
            //Set the GameObject's Color quickly to a set Color (blue)
            m_SpriteRenderer.color = Color.red;
        }    
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Damage + archer.Damage * skilldmg;
            Debug.Log("DMG archer:" + archer.Damage);
           
      
        }

  
        // Reset the damage back to its original value
    
      
    }
    public void StopIncreasing()
    {
        Debug.Log("Stop increasing");
        GameObject[] archerColor = GameObject.FindGameObjectsWithTag("Archer");
        foreach (var item in archerColor)
        {
            var m_SpriteRenderer = item.GetComponent<SpriteRenderer>();
            //Set the GameObject's Color quickly to a set Color (blue)
            m_SpriteRenderer.color = Color.green;
        }
        Archer[] archers = FindObjectsOfType<Archer>();
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Basedmg;
            Debug.Log("DMG archer:" + archer.Damage);
       
        }
    }

    public float getLevel()
    {
        return level;
    }
}
