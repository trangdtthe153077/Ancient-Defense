using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStateController;

public class ArcherManager : MonoBehaviour
{
    [SerializeField]
    Transform pos1;
    [SerializeField]
    Transform pos2;
    [SerializeField]
    Transform pos3;
    [SerializeField]
    Transform pos4;

    [SerializeField]
    GameObject archer1;
    [SerializeField]
    GameObject archer2;
    [SerializeField]
    GameObject archer3;
    [SerializeField]
    GameObject archer4;
    [SerializeField]
    GameObject archer5;
    GameObject[] archer;

    GameObject tempArc;
    Transform tempPos;

    GameObject varA;
    string tagName;
    public Canvas ChangeCharCanvas;
    public Canvas ChangeCharDetailsCanvas;
    SavingObject changeCharacterCanvas;
    GameStateController gameStateController;
    // Start is called before the first frame update

    private void Awake()
    {

        changeCharacterCanvas = GameObject.FindGameObjectWithTag("SavingObject").GetComponent<SavingObject>();
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();

    }
    void Start()
    {
<<<<<<< HEAD
    
=======

        LevelArcherDB = new int[6];
        LevelArcherDB[1] = 0;
        LevelArcherDB[2] = 0;
        LevelArcherDB[3] = 0;
        LevelArcherDB[4] = 0;
        LevelArcherDB[5] = 0;

        PriceArcherDB = new int[6];
        PriceArcherDB[1] = 500;
        PriceArcherDB[2] = 1000;
        LevelArcherDB[3] = 2000;
        PriceArcherDB[4] = 1500;
        PriceArcherDB[5] = 1500;


>>>>>>> parent of 077d4e0 (fix bug)
        archer = new GameObject[5];

        ChangeCharCanvas.gameObject.SetActive(false);

        if (  changeCharacterCanvas.getIsSpawn()==false)
        {
            varA = Instantiate(archer1, pos1.position, Quaternion.identity);
            var arc2 = Instantiate(archer2, pos2.position, Quaternion.identity);

            archer[1] = (varA);
            archer[2] = (arc2);
            changeCharacterCanvas.setIsSpawn(true);
        }    
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickSlot1()
    {

        if (ChangeCharDetailsCanvas.gameObject.activeSelf == false && gameStateController.GetGameState() == GameState.Waiting)
        {
            ChangeCharCanvas.gameObject.SetActive(true);
            changeCharacterCanvas.setCurrentSlot(1);
        }
        else
        {
            UseSkill(1);
        }
    }
    public void OnClickSlot2()
    {
        if (ChangeCharDetailsCanvas.gameObject.activeSelf == false && gameStateController.GetGameState() == GameState.Waiting)
        {
            Debug.Log("current: " + gameStateController.GetGameState());
            Debug.Log("Game are waiting");
            ChangeCharCanvas.gameObject.SetActive(true);
            Debug.Log(ChangeCharCanvas.gameObject.tag);
            changeCharacterCanvas.setCurrentSlot(2);
        }
        else
        {
            UseSkill(2);
        }
    }
    public void OnClickSlot3()
    {
        if (ChangeCharDetailsCanvas.gameObject.activeSelf == false && gameStateController.GetGameState() == GameState.Waiting)
        {
            ChangeCharCanvas.gameObject.SetActive(true);
            changeCharacterCanvas.setCurrentSlot(3);
        }
        else
        {
            UseSkill(3);
        }
    }
    public void OnClickSlot4()
    {
        if (ChangeCharDetailsCanvas.gameObject.activeSelf == false && gameStateController.GetGameState() == GameState.Waiting)
        {
            ChangeCharCanvas.gameObject.SetActive(true);
            changeCharacterCanvas.setCurrentSlot(4);
        }
        else
        {
            UseSkill(4);
        }
    }

    public void UseSkill(int pos)
    {
        if (archer[pos].tag == "GM")
        {
            archer[pos].GetComponent<GM>().OnButtonClick();
        }
        else if(archer[pos].tag == "TH")
        {
            archer[pos].GetComponent<TH>().OnButtonClick();
        }
        else if (archer[pos].tag == "Arin")
        {
            archer[pos].GetComponent<ArinSkill>().OnButtonClick();
        }
    }
<<<<<<< HEAD
=======
    public float PriceArcher(int arcNum)
    {
        if (arcNum == 1)
        {

            if (LevelArcherDB[1] == 0)
            { return PriceArcherDB[1];  }
            return GameObject.FindGameObjectWithTag("Arin").GetComponent<Arin>().upgradeprice;
        }
        else if (arcNum == 2)
        {
            if (LevelArcherDB[2] == 0)
            { return PriceArcherDB[2]; }
            return GameObject.FindGameObjectWithTag("Witch").GetComponent<Witch>().upgradeprice;
        }
        else if (arcNum == 3)
        {
            if (LevelArcherDB[3] == 0)
            { return PriceArcherDB[3]; }
            return GameObject.FindGameObjectWithTag("GM").GetComponent<GM>().upgradeprice;
        }
        else if (arcNum == 4)
        {
            if (LevelArcherDB[4] == 0)
            { return PriceArcherDB[4]; }
            return GameObject.FindGameObjectWithTag("TX").GetComponent<TX>().upgradeprice;
        }
        else if (arcNum == 5)
        {
            if (LevelArcherDB[5] == 0)
            { return PriceArcherDB[5]; }
            return GameObject.FindGameObjectWithTag("TH").GetComponent<TH>().upgradeprice;
        }

        return 0;
    }
    public int LevelArcher(int arcNum)
    {
        if (arcNum == 1)
        {
            return LevelArcherDB[1];

        }
        else if (arcNum == 2)
        {
            return LevelArcherDB[2];
        }
        else if (arcNum == 3)
        {
            return LevelArcherDB[3];
        }
        else if (arcNum == 4)
        {
            return LevelArcherDB[4];
        }
        else if (arcNum == 5)
        {
            return LevelArcherDB[5];
        }

        return 0;
    }
    public void UpgradeArcher(int arcNum)
    {
        switch (arcNum)
        {
            case 1:

                tagName = "Arin";
                break;
            case 2:

                tagName = "Witch";
                break;
            case 3:

                tagName = "GM";
                break;
            case 4:

                tagName = "TX";
                break;
            case 5:

                tagName = "TH";
                break;

        }

        for (int i = 1; i < archer.Length; i++)
        {

            if (archer[i] != null && archer[i].gameObject.tag == tagName)
            {
                var a = GameObject.FindGameObjectWithTag(tagName);
                if (a != null)
                {
                    if (arcNum == 1)
                    {
                  if(      archer[i].GetComponent<Arin>().LevelUp() ==true)
                        LevelArcherDB[1]++;
                        changeCharacterController.OnClickSlot1();
                    }
                    else if (arcNum == 2)
                    {
                        Debug.Log("Click on Witch");
                        if (archer[i].GetComponent<Witch>().LevelUp() ==true)
                        LevelArcherDB[2]++;
                        changeCharacterController.OnClickSlot2();
                    }
                    else if (arcNum == 3)
                    {
                    if(    archer[i].GetComponent<GM>().LevelUp() ==true)
                        LevelArcherDB[3]++;
                        changeCharacterController.OnClickSlot3();
                    }
                    else if (arcNum == 4)
                    {
                      if(  archer[i].GetComponent<TX>().LevelUp()==true)
                        LevelArcherDB[4]++;
                        changeCharacterController.OnClickSlot4();
                    }
                    else if (arcNum == 5)
                    {
                     if(   archer[i].GetComponent<TH>().LevelUp()==true)
                        LevelArcherDB[5]++;
                        changeCharacterController.OnClickSlot5();
                    }
                }
            }

        }


    }
>>>>>>> parent of 077d4e0 (fix bug)

    public void ChangeArcher(int arcNum, int pos)
    {
        switch (arcNum)
        {

            case 1:

                tempArc = archer1;
                tagName = "Arin";
                break;
            case 2:
                tempArc = archer2;
                tagName = "Witch";
                break;
            case 3:
                tempArc = archer3;
                tagName = "GM";
                break;
            case 4:
                tempArc = archer4;
                tagName = "TX";
                break;
            case 5:
                tempArc = archer5;
                tagName = "TH";
                break;




        }

        switch (pos)
        {

            case 1:

                tempPos = pos1;
                break;
            case 2:
                tempPos = pos2;
                break;
            case 3:
                tempPos = pos3;
                break;
            case 4:
                tempPos = pos4;
                break;
        }
        Debug.Log("call");

        for (int i = 1; i < archer.Length; i++)
        {
            Debug.Log(tagName);
            if (archer[i] != null && archer[i].gameObject.tag==tagName)
            {
                var a = GameObject.FindGameObjectWithTag(tagName);
                if(a!= null)
                Destroy(a);
                Debug.Log("tag" + i +archer[i].tag);
/*           var b = GameObject.FindGameObjectWithTag(archer[i].tag);
           
Destroy(b);
                Debug.Log("call");*/
          
            }
        }
      

        if (archer[pos] != null)
        {
            archer[pos].SetActive(false);
            Destroy(archer[pos]); // Destroy the current archer instance
        }
        var arc = Instantiate(tempArc, tempPos.position, Quaternion.identity);
<<<<<<< HEAD
        archer[pos]=arc;
=======
        arc.SetActive(true);
        archer[pos] = arc;
        if (LevelArcherDB[arcNum] == 0)
        {
            LevelArcherDB[arcNum]++;
        }
        switch (arcNum)
        {

            case 1:

                arc.gameObject.GetComponent<Arin>().setLevel(LevelArcherDB[arcNum]);
                break;
            case 2:
                arc.gameObject.GetComponent<Witch>().setLevel(LevelArcherDB[arcNum]);
                break;
            case 3:
                arc.gameObject.GetComponent<GM>().setLevel(LevelArcherDB[arcNum]);
                break;
            case 4:
                arc.gameObject.GetComponent<TX>().setLevel(LevelArcherDB[arcNum]);
                break;
            case 5:
                arc.gameObject.GetComponent<TH>().setLevel(LevelArcherDB[arcNum]);
                break;

        }

>>>>>>> parent of 077d4e0 (fix bug)

    }
}
