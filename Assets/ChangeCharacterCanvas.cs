using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeCharacterCanvas : MonoBehaviour
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

    SavingObject savingObject;
    void Start()
    {
        savingObject = GameObject.FindGameObjectWithTag("SavingObject").GetComponent<SavingObject>();
        manager = GameObject.FindGameObjectWithTag("ArcherManager").GetComponent<ArcherManager>();
        canvasDetails.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffCanvas()
    {
        canvas.gameObject.SetActive(false);
    }    

    public void OnClickSlot1()
    {
        canvas.gameObject.SetActive(false);
        Debug.Log("Why");
        title.SetText("Giam muc");
        content.SetText("Ban chuong ban cung ban sung ban ten");
        level.SetText("Level: 20");
        savingObject.setCurrentArcNum(1);
        canvasDetails.gameObject.SetActive(true);
/*        manager.ChangeArcher(3, 1);*/
    }
    public void OnClickSlot2()
    {
        manager.ChangeArcher(4, 2);
    }


    public void ChangePos()
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
