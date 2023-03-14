using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameStateController;

public class ChangeCharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
    public Canvas canvasDetails;
    ArcherManager manager;
    public TextMeshProUGUI title;
    public TextMeshProUGUI content;
    public TextMeshProUGUI level;
    public int currentSlot;
    public int CurrentArcNum;

    GameStateController gameStateController;
    SavingObject savingObject;
    void Start()
    {
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
        savingObject = GameObject.FindGameObjectWithTag("SavingObject").GetComponent<SavingObject>();
        manager = GameObject.FindGameObjectWithTag("ArcherManager").GetComponent<ArcherManager>();
        /*
                canvasDetails = GameObject.FindGameObjectWithTag("Char-Details")?.GetComponent<Canvas>();*/

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnOffCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
    public void TurnOffDetailsCanvas()
    {
        canvasDetails.gameObject.SetActive(false);
    }

    public void OnClickSlot1()
    {
    
            if (canvasDetails.gameObject.activeSelf == false)
            {
                canvas.gameObject.SetActive(false);

                title.SetText("Arin");
                content.SetText("Nhan vat chinh");
                level.SetText("Level: 20");


                savingObject.setCurrentArcNum(1);
                canvasDetails.gameObject.SetActive(true);
            }



    }
    public void OnClickSlot2()
    {
       
            if (canvasDetails.gameObject.activeSelf == false)
            {
                canvas.gameObject.SetActive(false);
                Debug.Log("Why");
                title.SetText("Witch");
                content.SetText("Ac nhu quy");
                level.SetText("Level: 20");
                savingObject.setCurrentArcNum(2);
                canvasDetails.gameObject.SetActive(true);
      
        }

    }

    public void OnClickSlot3()
    {
        
            if (canvasDetails.gameObject.activeSelf == false)
            {
                canvas.gameObject.SetActive(false);
                Debug.Log("Why");
                title.SetText("Giam muc");
                content.SetText("Lam viec o chua");
                level.SetText("Level: 20");
                savingObject.setCurrentArcNum(3);
                canvasDetails.gameObject.SetActive(true);
         
        }

    }
    public void OnClickSlot4()
    {
      
            if (canvasDetails.gameObject.activeSelf == false)
            {
                canvas.gameObject.SetActive(false);
                Debug.Log("Why");
                title.SetText("Thien xa");
                content.SetText("Lam viec o chua");
                level.SetText("Level: 20");
                savingObject.setCurrentArcNum(4);
                canvasDetails.gameObject.SetActive(true);
    
        }
    }

    public void OnClickSlot5()
    {
        
            if (canvasDetails.gameObject.activeSelf == false)
            {
                canvas.gameObject.SetActive(false);
                Debug.Log("Why");
                title.SetText("Nguoi trieu hoi");
                content.SetText("Trieu hoi golem tan cong");
                level.SetText("Level: 20");
                savingObject.setCurrentArcNum(5);
                canvasDetails.gameObject.SetActive(true);
     
        }
    
    }

    public void ChangePos()
    {
        currentSlot = savingObject.getCurrentSlot();
        CurrentArcNum = savingObject.getCurrentArcNum();
        Debug.Log("Current num: " + CurrentArcNum + "," + currentSlot);

        manager.ChangeArcher(CurrentArcNum, currentSlot);
    }
    public void UseSkill()
    {
        currentSlot = savingObject.getCurrentSlot();
        CurrentArcNum = savingObject.getCurrentArcNum();
        Debug.Log("Current num: " + CurrentArcNum + "," + currentSlot);

        manager.ChangeArcher(CurrentArcNum, currentSlot);
    }

    public void Upgrade()
    {

    }
    public void SetPosNum(int num)
    {
        currentSlot = num;
    }
}
