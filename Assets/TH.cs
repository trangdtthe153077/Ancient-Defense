using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class TH : Archer
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
    public GameObject Golem;
<<<<<<< HEAD

    void Start()
    {
=======
    public float upgradeprice;

    GoldManager goldManager;

    void Start()
    {
        goldManager = GameObject.FindGameObjectWithTag("Gold").GetComponent<GoldManager>();

        //setup character

        Basedmg = 15;
        Damage = Basedmg;
        Speed = 1f;
        delay = 30;
        mana = 30;
        upgradeprice = price;
        skilldmg = (float)(2.5 / 100);

        //---------------------------------





>>>>>>> parent of 077d4e0 (fix bug)
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
<<<<<<< HEAD
        level += 1;
        mana += 2;
        skilldmg += (float)2.5 / 100;
        efftime += (float)0.2;
=======
        if (goldManager.currnetGold > upgradeprice)
        {
            goldManager.addGold((int)-upgradeprice);
            level += 1;
            mana += 2;
            upgradeprice = (price * (level - 1) / 5) + price;
            return true;
        }
        return false;
    }
    public void setLevel(int lv)
    {
        lv = lv - 1;
        level += lv;
        mana += lv * 2;
        upgradeprice = (price * (level - 1) / 5) + price;
>>>>>>> parent of 077d4e0 (fix bug)

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
            SkillSpawnGolem();
        }

    }

    
    public void SkillSpawnGolem()
    {
        // Tạo ra một instance của prefab
        GameObject obj = Instantiate(Golem, transform);
        // Đặt vị trí của đối tượng
        float xPos = -1.64f;
        float yPos = -3.58f;
        obj.transform.position = new Vector3(xPos, yPos, 100);
    }

    public void StopIncreasing()
<<<<<<< HEAD
=======
    {

        Archer[] archers = FindObjectsOfType<Archer>();
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Basedmg;
            Debug.Log("DMG archer:" + archer.Damage);
        }
    }
    public float getLevel()
>>>>>>> parent of 077d4e0 (fix bug)
    {

        Archer[] archers = FindObjectsOfType<Archer>();
        foreach (Archer archer in archers)
        {
            archer.Damage = archer.Basedmg;
            Debug.Log("DMG archer:" + archer.Damage);
        }
    }
}
