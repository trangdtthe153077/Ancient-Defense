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
<<<<<<< HEAD
=======
    public Text pricebtn;
>>>>>>> parent of 077d4e0 (fix bug)
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

<<<<<<< HEAD

                savingObject.setCurrentArcNum(1);
                canvasDetails.gameObject.SetActive(true);
            }
=======
         
            canvas.gameObject.SetActive(false);

            title.SetText("Arin");
            content.SetText("Arin is the leader of the army against monsters and the main character in the story. He is a talented and careful warrior, full of faith and ready to fight to protect humanity.");


            savingObject.setCurrentArcNum(1);
            canvasDetails.gameObject.SetActive(true);
        }
  
     level.SetText("Level: " + manager.LevelArcher(1));
      BuyOrUpgrade(1);
>>>>>>> parent of 077d4e0 (fix bug)



    }
    public void OnClickSlot2()
    {
<<<<<<< HEAD
       
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
=======

        if (canvasDetails.gameObject.activeSelf == false)
        {
         
            canvas.gameObject.SetActive(false);
            Debug.Log("Why");
            title.SetText("Witch");
            content.SetText("Ac nhu quy");
      
            savingObject.setCurrentArcNum(2);
            canvasDetails.gameObject.SetActive(true);

        }
    
 level.SetText("Level: " + manager.LevelArcher(2));
        ///
      BuyOrUpgrade(2);
>>>>>>> parent of 077d4e0 (fix bug)

    }

    public void OnClickSlot3()
    {
<<<<<<< HEAD
        
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
=======

        if (canvasDetails.gameObject.activeSelf == false)
        {
            
            canvas.gameObject.SetActive(false);
            Debug.Log("Why");
            title.SetText("Giam muc");
            content.SetText("Lam viec o chua");
        
            savingObject.setCurrentArcNum(3);
            canvasDetails.gameObject.SetActive(true);

        }
    
        level.SetText("Level: " + manager.LevelArcher(3));
     BuyOrUpgrade(3);
>>>>>>> parent of 077d4e0 (fix bug)

    }
    public void OnClickSlot4()
    {
<<<<<<< HEAD
      
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
=======

        if (canvasDetails.gameObject.activeSelf == false)
        {
            
            canvas.gameObject.SetActive(false);
            Debug.Log("Why");
            title.SetText("Thien xa");
            content.SetText("Lam viec o chua");
    
            savingObject.setCurrentArcNum(4);
            canvasDetails.gameObject.SetActive(true);

        }
      
        level.SetText("Level: " + manager.LevelArcher(4));
     BuyOrUpgrade(4);
>>>>>>> parent of 077d4e0 (fix bug)
    }

    public void OnClickSlot5()
    {
<<<<<<< HEAD
        
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
    
=======

        if (canvasDetails.gameObject.activeSelf == false)
        {
           
            canvas.gameObject.SetActive(false);
            Debug.Log("Why");
            title.SetText("Nguoi trieu hoi");
            content.SetText("Trieu hoi golem tan cong");
          
            savingObject.setCurrentArcNum(5);
            canvasDetails.gameObject.SetActive(true);

        }

        level.SetText("Level: " + manager.LevelArcher(5));

      BuyOrUpgrade(5);
    }

    public void BuyOrUpgrade(int arcNum)

    {
        string tagName;
        switch (arcNum)
        {
            case 1:
                tagName = "Arin";
                if (GameObject.FindGameObjectWithTag("Arin") != null)

                {
                    pricebtn.text = "Upgrade " + manager.PriceArcher(1);
                }
                else
                {
                    pricebtn.text = "Buy Archer " + manager.PriceArcher(1);
                }
                break;
            case 2:

                tagName = "Witch";
                if (GameObject.FindGameObjectWithTag("Witch") != null)

                {
                    pricebtn.text = "Upgrade " + manager.PriceArcher(2);
                }
                else
                {
                    pricebtn.text = "Buy Archer " + manager.PriceArcher(2);
                }
                break;
            case 3:

                tagName = "GM";
                if (GameObject.FindGameObjectWithTag("TX") != null)
                {
                    pricebtn.text = "Upgrade " + manager.PriceArcher(3);
                }
                else
                {
                    pricebtn.text = "Buy Archer " + manager.PriceArcher(3);
                }
                break;
            case 4:

                if (GameObject.FindGameObjectWithTag("TX") != null)
                {
                    pricebtn.text = "Upgrade " + manager.PriceArcher(4);
                }
                else
                {
                    pricebtn.text = "Buy Archer " + manager.PriceArcher(4);
                }
                break;
            case 5:

                tagName = "TH";
                var e = GameObject.FindGameObjectWithTag(tagName).GetComponent<TH>();
                if (e != null)
                {
                    pricebtn.text = "Upgrade " + manager.PriceArcher(5);
                }
                else
                {
                    pricebtn.text = "Buy Archer " + manager.PriceArcher(5);
                }
                break;
        }

>>>>>>> parent of 077d4e0 (fix bug)
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
<<<<<<< HEAD

=======
     
        CurrentArcNum = savingObject.getCurrentArcNum();
        Debug.Log("Current num: " + CurrentArcNum + "," + currentSlot);

        manager.UpgradeArcher(CurrentArcNum);
>>>>>>> parent of 077d4e0 (fix bug)
    }
    public void SetPosNum(int num)
    {
        currentSlot = num;
    }
}
