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
    void Start()
    {
        changeCharacterCanvas = GameObject.FindGameObjectWithTag("SavingObject").GetComponent<SavingObject>();
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();

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
        if (ChangeCharDetailsCanvas.gameObject.activeSelf == false &&gameStateController.GetGameState()== GameState.Waiting)
        {
            ChangeCharCanvas.gameObject.SetActive(true);
            changeCharacterCanvas.setCurrentSlot(1);
        }
    }
    public void OnClickSlot2()
    {
        if (ChangeCharDetailsCanvas.gameObject.activeSelf == false && gameStateController.GetGameState() == GameState.Waiting)
        {
            Debug.Log("Game are waiting");
            ChangeCharCanvas.gameObject.SetActive(true);
            Debug.Log(ChangeCharCanvas.gameObject.tag);
            changeCharacterCanvas.setCurrentSlot(2);
        }
    }
    public void OnClickSlot3()
    {
        if (ChangeCharDetailsCanvas.gameObject.activeSelf == false && gameStateController.GetGameState() == GameState.Waiting)
        {
            ChangeCharCanvas.gameObject.SetActive(true);
            changeCharacterCanvas.setCurrentSlot(3);
        }
    }
    public void OnClickSlot4()
    {
        if (ChangeCharDetailsCanvas.gameObject.activeSelf == false && gameStateController.GetGameState() == GameState.Waiting)
        {
            ChangeCharCanvas.gameObject.SetActive(true);
            changeCharacterCanvas.setCurrentSlot(4);
        }
    }

    public void UseSkill(int pos)
    {
        if (archer[pos].tag=="GM")
        {
            archer[pos].GetComponent<GM>().OnButtonClick();
        }    
    }    

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
        archer[pos]=arc;


    }
}
