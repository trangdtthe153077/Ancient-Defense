using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private  ChangeCharacterController changeCharacterCanvas;
    Tower tower;
    ArcherManager manager;
    BasicArcherController basicArcher;
    void Awake()
    {
        basicArcher = GameObject.FindGameObjectWithTag("BasicArcher").GetComponent<BasicArcherController>();
        manager = GameObject.FindGameObjectWithTag("ArcherManager").GetComponent<ArcherManager>();
        var a = GameObject.FindGameObjectWithTag("ChangeChar");
        changeCharacterCanvas = a.GetComponent<ChangeCharacterController>();
        var b = a.GetComponent<Rigidbody2D>();
        Debug.Log(b);
        tower = GameObject.FindGameObjectWithTag("Tower").gameObject.GetComponent<Tower>();
    }



    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickSlot1()
    {

        changeCharacterCanvas.OnClickSlot1();

    }
    public void OnClickSlot2()
    {
       changeCharacterCanvas.OnClickSlot2();

    }

    public void OnClickSlot3()
    {
        changeCharacterCanvas.OnClickSlot3();

    }
    public void OnClickSlot4()
    {
        changeCharacterCanvas.OnClickSlot4(); ;


    }
    public void OnClickSlot5()
    {
        changeCharacterCanvas.OnClickSlot5();

    }

    //bam vao vi tri
    public void OnClickArc1()
    {

        manager.OnClickSlot1();

    }
    public void OnClickArc2()
    {
        manager.OnClickSlot2();

    }

    public void OnClickAr3()
    {
        manager.OnClickSlot3();

    }
    public void OnClickArc4()
    {
        manager.OnClickSlot4(); ;


    }
   
    public void CloseCharacter()
    {
        changeCharacterCanvas.TurnOffCanvas();

    }
    public void ChangePos()
    {
        changeCharacterCanvas.ChangePos();

    }
    public void CloseCharDetails()
    {
        Debug.Log("AA");
        changeCharacterCanvas.TurnOffDetailsCanvas();

    }
    public void UpdateTower()
    {
        tower.LevelUp();
    }

    public void UpdateLevelArcher()
    {
        basicArcher.LevelUp();
    }
}
