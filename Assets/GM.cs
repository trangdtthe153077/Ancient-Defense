using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GM : Archer{
    public float delay = 30f;
    public float mana = 50;
    public float price = 500;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;

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

    public void LevelUp()
    {
        level += 1;
        mana += 2;
        skilldmg += (float)  2.5 / 100;
        efftime += (float)0.2;

    }
    public void OnButtonClick()
    {
        StartCoroutine(SkillIncreaseDamage());
    }

    public IEnumerator SkillIncreaseDamage()
    {
        Archer[] archers = FindObjectsOfType<Archer>();
        
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Damage + archer.Damage * skilldmg;
        }

        yield return new WaitForSeconds(efftime);

        // Reset the damage back to its original value
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Basedmg;
        }
    }
}
