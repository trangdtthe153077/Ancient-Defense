using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicArcherController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;

    public GameObject archer;
    public Button upgradeArcher;
    public int archerLevel = 0;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI priceText;
    public float upgradePrice = 50;
    GoldManager goldManager;

    public GameObject[] archers;
    void Start()
    {
        archers = new GameObject[5];
        goldManager = GameObject.FindWithTag("Gold").GetComponent<GoldManager>();
        var arch = Instantiate(archer,new Vector3(pos1.position.x,pos1.position.y,100), Quaternion.identity);
        archers[0] = arch;
        archers[0].gameObject.GetComponent<Archer>().Basedmg = 1;
        archerLevel++;
        priceText.SetText(upgradePrice.ToString());
        levelText.SetText("Lv" + archerLevel.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelUp()
    {

        if (goldManager.currnetGold - upgradePrice > 0)
        {
            var a = archerLevel % 5;
            if (archerLevel >= 5)
            {
                archers[a].gameObject.GetComponent<Archer>().Basedmg += 2;
            }
            else
            {
                if (a == 1)
                {
                 
                    var arch = Instantiate(archer, new Vector3(pos2.position.x, pos2.position.y, 100), Quaternion.identity);
                    arch.gameObject.GetComponent<Archer>().Basedmg = 1;
                    archers[archerLevel] = arch;
                }
                if (a == 2)
                {
                    var arch = Instantiate(archer, new Vector3(pos3.position.x, pos3.position.y, 100), Quaternion.identity);
                    arch.gameObject.GetComponent<Archer>().Basedmg = 1;
                    archers[archerLevel] = arch;
                }
                if (a == 3)
                {
                    var arch = Instantiate(archer, new Vector3(pos4.position.x, pos4.position.y, 100), Quaternion.identity);
                    arch.gameObject.GetComponent<Archer>().Basedmg = 1;
                    archers[archerLevel] = arch;
                }
                if (a == 4)
                {
                    var arch = Instantiate(archer, new Vector3(pos5.position.x, pos5.position.y, 100), Quaternion.identity);
                    arch.gameObject.GetComponent<Archer>().Basedmg = 1;
                    archers[archerLevel] = arch;
                }
            }
            goldManager.addGold((int)-upgradePrice);
            upgradePrice = 50 * (archerLevel / 5) + 50 * archerLevel;
            priceText.SetText(upgradePrice.ToString());
            archerLevel++;
            levelText.SetText("Lv"+archerLevel.ToString());

        }

    }
}
