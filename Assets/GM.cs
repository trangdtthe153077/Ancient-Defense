using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class GM : Archer{
    public float delay = 30f;
    public float mana = 50;
    public float price = 500;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;
    public Button btn;
    GameStateController gameStateController;
    void Start()
    {
        Debug.Log("bonk");
         btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
        gameStateController  = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void wagaga()
    {
        Debug.Log("BUtton called");
        
    }
    public void OnButtonClick()
    {
        Debug.Log("BUtton called");
        StartCoroutine(SkillIncreaseDamage());
    }

    public IEnumerator SkillIncreaseDamage()
    {
      

            Archer[] archers = FindObjectsOfType<Archer>();
        
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Damage + archer.Damage * skilldmg;
            Debug.Log("DMG archer:" + archer.Damage);
        }

        yield return new WaitForSeconds(efftime);

        // Reset the damage back to its original value
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Basedmg;
        }
      
    }
}
