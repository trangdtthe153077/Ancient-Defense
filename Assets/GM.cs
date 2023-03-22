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
    public float price = 500;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;
    public Button btn;
    GameStateController gameStateController;
    Timer timer;
    Timer delayTimer;
    bool delayFinished=false;
<<<<<<< HEAD
    bool success=false;
    
    void Start()
    {
      timer=  gameObject.AddComponent<Timer>();
=======
    bool success = false;
    public float upgradeprice;

    GoldManager goldManager;
    void Start()
    {
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
>>>>>>> parent of 077d4e0 (fix bug)
        timer.Duration = 1;
        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.Duration = 5f;
   tower= GameObject.FindWithTag("Tower").GetComponent<Tower>();
        manatower= tower.getMana();
        Debug.Log("mana tower: "+manatower);
        Debug.Log("bonk");
         btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
        gameStateController  = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(success==true && timer.Finished )
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
<<<<<<< HEAD
        level += 1;
        mana += 2;
        skilldmg += (float)  2.5 / 100;
        efftime += (float)0.2;

=======
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
        efftime += 0.2f;
        upgradeprice = (500 * (level - 1) / 5) + 500; ;
>>>>>>> parent of 077d4e0 (fix bug)
    }

    public void OnButtonClick()
    {

        Debug.Log("BUtton called");
        if ((manatower-mana>=0)&& success == false && ( delayTimer.Finished || delayFinished==false))
        {
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
        
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Damage + archer.Damage * skilldmg;
            Debug.Log("DMG archer:" + archer.Damage);
        }

  
        // Reset the damage back to its original value
    
      
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
