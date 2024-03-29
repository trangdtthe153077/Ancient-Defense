﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{

    public float speed = 5f;
    public Transform target;
    public float attackDistance = 1f;

    private Rigidbody2D rb;
    int basehealth = 20;
    public int maxHealth = 10;
    private int currentHealth;
    public int basedamage;
    public int damage = 10; // Lượng sát thương gây ra khi tấn công
    public float attackDelay = 2f; // Thời gian giữa hai lần tấn công
    private float attackTimer; // Thời gian từ lần tấn công cuối cùng
    public GameObject coinPrefab; // đối tượng tiền tệ
    public int baseCoin;
    public int coinCount = 1; // số lượng tiền tệ rơi ra
    private bool isDead = false; // kiểm tra quái đã chết hay chưa
    public bool hasFoundTower = false;
    public GameObject Towerbd;
    public bool allysPresent = false;
    public bool stopForever = false;
    GameStateController gameStateController;

    GoldManager goldManager;
    void Start()
    {
        basedamage = 10;
    
        gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();
        goldManager = GameObject.FindWithTag("Gold").GetComponent<GoldManager>();
    }

    void Update()
    {
        if (!hasFoundTower)
        {
            // quái di chuyển sang trái
            transform.Translate(Vector3.left * 3f * Time.deltaTime);

        }

        /* GetComponent<Rigidbody2D>().AddForce(-transform.right * 0.5f);*/
        // Tính toán thời gian giữa hai lần tấn công


        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            attackTimer = 0f;

            // Tấn công nếu người chơi ở trong vùng va chạm
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Tower" || collider.tag == "Ally")
                {
                    Tower tower = collider.GetComponent<Tower>();
                    SoldierMoving ally = collider.GetComponent<SoldierMoving>();
                    GolemMOving ally2 = collider.GetComponent<GolemMOving>();


                    if (tower != null)
                    {

                        // Tower component được tìm thấy
                        Debug.Log("Found Tower!");
                        //StartCoroutine(RotateObject());
                        tower.TakeDamage(damage);
                        /*       StartCoroutine(RotateObject());*/
                        StartCoroutine(RotateObject());
                    }
                    else
                    {
                        // Tower component không tồn tại trên đối tượng
                        Debug.Log("Tower component not found!");
                    }
                    if (ally != null)
                    {

                        // Tower component được tìm thấy
                        Debug.Log("Found ally!");
                        //StartCoroutine(RotateObject());
                        ally.TakeDamage(damage);
                        /*       StartCoroutine(RotateObject());*/
                        StartCoroutine(RotateObject());
                    }
                    else
                    {
                        // Tower component không tồn tại trên đối tượng
                        Debug.Log("Ally component not found!");
                    }
                    if (ally2 != null)
                    {
                        Debug.Log("Danh linh danh linh");
                        ally2.TakeDamage(damage);
                        StartCoroutine(RotateObject());

                    }
                }
                
                 
            }
        }

    }
    public void setDmgBoss()
    {
        basedamage = 25;
        basehealth =75;
        baseCoin = 100;
    }
    IEnumerator RotateObject()
    {
        int numRotations = 0;
        float totalRotation = 0f;
        while (numRotations < 1)
        {
            transform.Rotate(0, 0, 10);
            totalRotation += 10f;
            yield return null;
            if (totalRotation >= 360f)
            {
                numRotations++;
                Debug.Log("Finish turn " + numRotations);
            }
        }
    }

    void Moving()
    {
        
       Debug.Log("tiep tuc di chuyen");
            rb.WakeUp(); // Kích hoạt tính toán vật lý cho Rigidbody
      /*      rb.velocity = new Vector2(-2, 0);*/
        hasFoundTower = false;

      
    }    
    void StopMoving()
    {
        if (allysPresent)
        {
            Debug.Log("Ngừng di chuyển");
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.Sleep();

        }
 /*       else
        {
            Debug.Log("tiep tuc di chuyen");
            rb.WakeUp(); // Kích hoạt tính toán vật lý cho Rigidbody
            rb.velocity = new Vector2(-2, 0);

        }*/
    }


    public void TakeDamage(int damage)
    {
        Debug.Log("Quai bi tru so mau " + damage + "tu so mau la " + currentHealth);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Add code here to handle enemy death (e.g. play death animation, spawn loot, etc.)



        coinCount = gameStateController.gameLevel + 20;
        var a = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        goldManager.addGold(coinCount);
        Destroy(a, 0.7f);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            stopForever = true;
            hasFoundTower = true;
            allysPresent = true;
            StopMoving();
        }
        if (other.gameObject.CompareTag("Ally"))
        {
            hasFoundTower = true;
            allysPresent = true;
            StopMoving();
        }
        else if(stopForever==false)
        {
            Moving();

        }    
     
 
     
        if (other.gameObject.CompareTag("Ground"))
        {

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    public void SetLevel(int lv)
    {

        damage = basedamage + lv;
        maxHealth = basehealth + lv * 3;
        currentHealth = maxHealth;
        coinCount = baseCoin + lv;

        Debug.Log("DMG, Health of enemy: " + damage + "," + maxHealth);
    }

}








