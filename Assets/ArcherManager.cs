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
    List<Object> archer;

    public Canvas ChangeCharCanvas;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCharCanvas.gameObject.SetActive(false);
        archer = new List<Object>();
        var arc1 = Instantiate(archer1, pos1.position, Quaternion.identity);
        var arc2 = Instantiate(archer2, pos2.position, Quaternion.identity);
        archer.Add(arc1);
        archer.Add(arc2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickSlot1()
    {
        ChangeCharCanvas.gameObject.SetActive(true);
    }    
}
