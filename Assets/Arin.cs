using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Arin : Archer
{
    private Tower tower;
    public int manatower;
    public float delay = 30f;
    public int mana = 50;
    public float price = 500;
    public float level = 1;
    public float skilldmg = (float)(2.5 / 100);
    public float efftime = 5;

    GameStateController gameStateController;
    Timer timer;
    Timer delayTimer;
    bool delayFinished = false;
    bool success = false;
    public GameObject Soldier;
    public float spacing;



    public float upgradeprice;
    GoldManager goldManager;

    Archer archer;


    void Start()
    {
        archer = gameObject.GetComponent<Archer>();
     
        goldManager = GameObject.FindGameObjectWithTag("Gold").GetComponent<GoldManager>();
        Basedmg = 5;
        Damage = Basedmg;
        Speed = 1f;
        delay = 25;
        mana = 20;
        upgradeprice = 500;


        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.Duration = 5f;
        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();
     
        Debug.Log("mana tower: " + manatower);
        Debug.Log("bonk");

        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();



        archer.Damage = Basedmg;
        Debug.Log("Archer dmg" + archer.Damage);
    }

    // Update is called once per frame
    void Update()
    {
        manatower = tower.getMana();
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
            SkillSpawnSoldier();
        }
    }
    public void SkillSpawnSoldier()
    {
        for (int i = 0; i < 5; i++)
        {
            // T?o ra m?t instance c?a prefab
            GameObject obj = Instantiate(Soldier, transform);
            obj.GetComponent<SoldierMoving>().setUp((int)Basedmg);
            // ??t v? trí c?a ??i t??ng
            float xPos = -2.44f + i * 2;
            float yPos = -5.18f;
            obj.transform.position = new Vector3(xPos, yPos, 100);
        }
        success = false;
    }


    public bool LevelUp()
    {
        Debug.Log("Archer dmg" + archer.Damage);
        if (goldManager.currnetGold > upgradeprice)
        {
            goldManager.addGold((int)-upgradeprice);
            level += 1;
            mana += 1;
            Basedmg += 2;
            upgradeprice = (price * (level - 1) / 5) + price;
            archer.Damage = Basedmg;
            return true;
        }
        return false;
    }
    public void setLevel(int lv)
    {
        lv = lv - 1;
        level += lv;
        mana += lv;
        Basedmg += 2 * lv;
        upgradeprice = (price * (level - 1) / 5) + price;
        archer.Damage = Basedmg;
    }
    public float getLevel()
    {
        return level;
    }
}
