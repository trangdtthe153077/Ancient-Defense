using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    SavingObject changeCharacterCanvas;

    // Start is called before the first frame update
    void Start()
    {
        changeCharacterCanvas = GameObject.FindGameObjectWithTag("SavingObject").GetComponent<SavingObject>();
       
        
        archer = new GameObject[] { null, archer1, archer2, archer3, archer4, archer5 };

        ChangeCharCanvas.gameObject.SetActive(false);

      if(  changeCharacterCanvas.getIsSpawn()==false)
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
        ChangeCharCanvas.gameObject.SetActive(true);
        changeCharacterCanvas.setCurrentSlot(1);
    }
    public void OnClickSlot2()
    {
        ChangeCharCanvas.gameObject.SetActive(true);
        changeCharacterCanvas.setCurrentSlot(2);
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

        for (int i = 0; i < archer.Length; i++)
        {
            if (archer[i] != null && archer[i].gameObject==tempArc)
            {
                var a = GameObject.FindGameObjectWithTag(tagName);
                if(a!= null)
                Destroy(a);

           
                archer[i] = null;
            }
        }
        archer[pos].SetActive(false);

        if (archer[pos] != null)
        {
            Destroy(archer[pos]); // Destroy the current archer instance
        }
        var arc = Instantiate(tempArc, tempPos.position, Quaternion.identity);
        archer[pos]=arc;


    }
}
