﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class WitchSkill : MonoBehaviour
{
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
    bool delayFinished = false;
    bool success = false;
    public GameObject WitchSkillGen;
    public float spacing;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.Duration = 5f;
        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();
        manatower = tower.getMana();
        Debug.Log("mana tower: " + manatower);
        Debug.Log("bonk");
        btn = GetComponent<Button>();
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (success == true && timer.Finished)
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
        skilldmg += (float)2.5 / 100;
        efftime += (float)0.2;

    }

    public void OnButtonClick()
    {

        Debug.Log("BUtton called");
        if ((manatower - mana >= 0) && success == false && (delayTimer.Finished || delayFinished == false))
        {
            manatower = manatower - mana;
            tower.setMana(manatower);
            Debug.Log("mana: " + manatower);
            delayTimer.Run();
            timer.Run();
            success = true;
            delayFinished = true;
            Witch();
        }

    }


    public void Witch()
    {
        /*GameObject towerObject = GameObject.FindGameObjectWithTag("tower");

        if (towerObject != null)
        {
            // Tìm tọa độ x của object có tag "enemy" gần nhất so với object có tag "tower"
            float nearestX = Mathf.Infinity;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(towerObject.transform.position, 20f, enemyLayerMask);
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "enemy")
                {
                    float distance = Mathf.Abs(towerObject.transform.position.x - collider.transform.position.x);
                    if (distance < Mathf.Abs(towerObject.transform.position.x - nearestX))
                    {
                        nearestX = collider.transform.position.x;
                    }
                }
            }

            // Tạo một object mới tại tọa độ x gần nhất và y = 0
            Vector3 spawnPosition = new Vector3(nearestX, 0, 0);
            Instantiate(WitchSkillGen, spawnPosition, Quaternion.identity);
        }*/
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