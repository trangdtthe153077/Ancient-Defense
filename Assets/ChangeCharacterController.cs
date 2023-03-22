using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    public Text pricebtn;
    public int currentSlot;
    public int CurrentArcNum;

    GameStateController gameStateController;
    SavingObject savingObject;

    private float priceUpgradeOrBuy;
    void Start()
    {
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
        savingObject = GameObject.FindGameObjectWithTag("SavingObject").GetComponent<SavingObject>();
        manager = GameObject.FindGameObjectWithTag("ArcherManager").GetComponent<ArcherManager>();
        /*
                canvasDetails = GameObject.FindGameObjectWithTag("Char-Details")?.GetComponent<Canvas>();*/
        canvas.gameObject.SetActive(false);
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
            content.SetText("Arin is the leader of the army against monsters and the main character in the story. He is a talented and careful warrior, full of faith and ready to fight to protect humanity.");


            savingObject.setCurrentArcNum(1);
            canvasDetails.gameObject.SetActive(true);
        }
  
     level.SetText("Level: " + manager.LevelArcher(1));
      BuyOrUpgrade(1);



    }
    public void OnClickSlot2()
    {

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

    }

    public void OnClickSlot3()
    {

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

    }
    public void OnClickSlot4()
    {

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
    }

    public void OnClickSlot5()
    {

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
     
        CurrentArcNum = savingObject.getCurrentArcNum();
        Debug.Log("Current num: " + CurrentArcNum + "," + currentSlot);

        manager.UpgradeArcher(CurrentArcNum);
    }
    public void SetPosNum(int num)
    {
        currentSlot = num;
    }
}
