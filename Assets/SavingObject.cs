using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingObject : MonoBehaviour
{
    public int currentSlot;
    public int currentArcNum;
    public bool isSpawn;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
