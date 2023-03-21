using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth =100;
    public int currentHealth;
    public int maxMana= 50;
    public int currentMana;
    public float manaRegenRate = 5; // Số mana được hồi mỗi giây.
    public int lv=1;
    public int goldUpdate=200;
    public TextMeshProUGUI healthtext;
    public TextMeshProUGUI manatext;
    public TextMeshProUGUI towerlv;
    public TextMeshProUGUI goldtext;
    public GoldManager goldmanager;

    GameStateController gameStateController;
    void Start()
    {
        goldUpdate = 200;
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
        currentHealth = maxHealth;
        currentMana = maxMana;
        StartCoroutine(RegenerateMana());
        healthtext.text = currentHealth.ToString();
        manatext.text = currentMana.ToString();
        towerlv.text = "Lv" + lv.ToString();
        goldtext.text = goldUpdate.ToString();
        goldmanager = GameObject.FindWithTag("Gold").GetComponent<GoldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUp()
    {
        goldmanager.addGold(-goldUpdate);
        lv++;
        goldUpdate= 100 *(lv / 5) + 100 *(lv + 1);
        maxMana = 10 * (lv + 1);
        maxHealth = 50 * (lv + 1);
        towerlv.text ="Lv"+ lv.ToString();
        goldtext.text = " "+ goldUpdate.ToString();
        healthtext.text = " "+maxHealth.ToString();
        manatext.text = " " + maxMana.ToString();
        
    }
    public IEnumerator RegenerateMana()
    {
        while (true)
        {
            if (currentMana < maxMana)
            {
                currentMana = Mathf.Min(maxMana, currentMana + Mathf.RoundToInt(manaRegenRate * Time.deltaTime));
            }

            yield return new WaitForSeconds(1f); // Chờ 1 giây trước khi hồi thêm mana.
        }
    }
    public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			//Die();
			Debug.Log("here found tower!");
        
            var a = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(var b in a)
            {
                Destroy(b);
            }    
            currentHealth = 0;
            currentMana = 0;
        }
	}

    public void ResetTower()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }    
	private void Die()
    {
       //  Add code here to handle enemy death (e.g. play death animation, spawn loot, etc.)
        Destroy(gameObject);
    }
    public int getHealth()
    {
        return currentHealth;
    }
    public void setHealth(int health)
    {
        currentHealth = health;
    }
    public int getMana()
    {
        return currentMana;
    }
    public void setMana(int mana)
    {
        currentMana = mana;
    }
}
