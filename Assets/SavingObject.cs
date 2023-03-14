using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingObject : MonoBehaviour
{
    public int currentSlot;
    public int currentArcNum;
    public bool isSpawn;
    public Canvas canvasDetails;
    public int getCurrentSlot()
    {
        return currentSlot;
    }
    public int getCurrentArcNum()
    {
        return currentArcNum;
    }
    public void setCurrentSlot(int slot)
    {
       currentSlot = slot;
    }
    public void setCurrentArcNum(int num)
    {
     currentArcNum = num;
    }

    public bool getIsSpawn()
    {
        return isSpawn;
    }
    public void setIsSpawn(bool a)
    {
        isSpawn = a;
    }

    void Start()
    {
        canvasDetails = GameObject.FindGameObjectWithTag("Char-Details").GetComponent<Canvas>();
        canvasDetails.gameObject.SetActive(false);
        Debug.Log("Off");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
