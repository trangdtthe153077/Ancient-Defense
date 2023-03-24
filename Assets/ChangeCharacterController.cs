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
    public Button priceBtn;
    public Button changeBtn;
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
            content.SetText("Summon warriors to help defend the tower");


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
            content.SetText("Summons lightning to attack the nearest enemy");

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
            title.SetText("Bishop");
            content.SetText("Increase damage to archers");

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
            title.SetText("Marksman");
            content.SetText("Shoots arrows continuously at enemies at super fast speed");

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
            title.SetText("Summoner");
            content.SetText("Summon golems to support castle defense");

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
                if (GameObject.FindGameObjectWithTag(tagName) == null)
                {
                    pricebtn.text = "Upgrade -- ";
                    priceBtn.interactable = false;

                }
                else
                {
                    var price = manager.PriceArcher(1);
                    pricebtn.text = "Upgrade " + price;
                    priceBtn.interactable = true;
                }

                break;

            case 2:

                tagName = "Witch";
                if (gameStateController.gameLevel > 1)
                {
                    changeBtn.interactable = true;
                }
                else
                {
                    changeBtn.interactable = false;
                }
                if (GameObject.FindGameObjectWithTag(tagName) == null)
                {
                    pricebtn.text = "Upgrade -- ";
                    priceBtn.interactable = false;
                }
                else
                {
                    var price = manager.PriceArcher(2);
                    pricebtn.text = "Upgrade " + price;
                    priceBtn.interactable = true;
                }
                break;
            case 3:

                tagName = "GM";
                if (gameStateController.gameLevel > 2)
                {
                    changeBtn.interactable = true;
                }
                else
                {
                    changeBtn.interactable = false;
                }
                if (GameObject.FindGameObjectWithTag(tagName) == null)
                {
                    pricebtn.text = "Upgrade -- ";
                    priceBtn.interactable = false;
                }
                else
                {
                    var price = manager.PriceArcher(3);
                    pricebtn.text = "Upgrade " + price;
                    priceBtn.interactable = true;
                }
                break;
            case 4:
                tagName = "TX";
                if (gameStateController.gameLevel > 3)
                {
                    changeBtn.interactable = true;
                }
                else
                {
                    changeBtn.interactable = false;
                }
                if (GameObject.FindGameObjectWithTag(tagName) == null)
                {
                    pricebtn.text = "Upgrade -- ";
                    priceBtn.interactable = false;
                }
                else
                {
                    var price = manager.PriceArcher(4);
                    pricebtn.text = "Upgrade " + price;
                    priceBtn.interactable = true;
                }
                /*       if (manager.LevelArcher(4) == 0)
                       {
                           pricebtn.text = "Buy Archer " + price;

                       }
                       else
                       {
                           pricebtn.text = "Upgrade " + price;

                       }*/
                break;
            case 5:
                tagName = "TH";
                if (gameStateController.gameLevel > 4)
                {
                    changeBtn.interactable = true;
                }
                else
                {
                    changeBtn.interactable = false;
                }
                if (GameObject.FindGameObjectWithTag(tagName) == null)
                {
                    pricebtn.text = "Upgrade -- ";
                    priceBtn.interactable = false;
                }
                else
                {
                    var price = manager.PriceArcher(5);
                    pricebtn.text = "Upgrade " + price;
                    priceBtn.interactable = true;
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
