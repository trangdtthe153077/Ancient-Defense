using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class GM : Archer{
    public float laudaimana = 200;
    public float delay = 30f;
    public float mana = 50;
    public float price = 500;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;
    public Button btn;
    GameStateController gameStateController;
    Timer timer;
    Timer delayTimer;
    bool delayFinished=false;
    bool success=false;
    
    void Start()
    {
      timer=  gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.Duration = 5f;
   
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
        level += 1;
        mana += 2;
        skilldmg += (float)  2.5 / 100;
        efftime += (float)0.2;

    }

    public void OnButtonClick()
    {

        Debug.Log("BUtton called");
        if ((laudaimana-mana>0)&& success == false && ( delayTimer.Finished || delayFinished==false))
        {
            laudaimana = laudaimana - mana;
            Debug.Log("mana: "+laudaimana);
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
