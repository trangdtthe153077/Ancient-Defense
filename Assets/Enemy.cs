using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public float attackDistance = 1f;

    private Rigidbody2D rb;
    int basehealth = 10;
    public int maxHealth = 10;
    private int currentHealth;
    public int basedamage = 10;
    public int damage = 10; // Lượng sát thương gây ra khi tấn công
    public float attackDelay = 2f; // Thời gian giữa hai lần tấn công
    private float attackTimer; // Thời gian từ lần tấn công cuối cùng
    public GameObject coinPrefab; // đối tượng tiền tệ
    public int baseCoin;
    public int coinCount = 1; // số lượng tiền tệ rơi ra
    private bool isDead = false; // kiểm tra quái đã chết hay chưa
public bool hasFoundPlayer = false;
    public GameObject Player;

    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!hasFoundPlayer)
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
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 6f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Player")
                {
                    collider.GetComponent<Player>().TakeDamage(damage);
                    Debug.Log("here!");
                    StopMoving();
                    hasFoundPlayer = true;

                }
            }
        }

    }
    void StopMoving()
    {
        // Dừng di chuyển của quái
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.Sleep();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Add code here to handle enemy death (e.g. play death animation, spawn loot, etc.)
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }

    public void SetLevel(int lv)
    {

        damage = basedamage + lv;
        maxHealth = basehealth + lv * 3;
        coinCount = baseCoin + lv;

        Debug.Log("DMG, Health of enemy: "+damage + ","+ maxHealth);
    }    
    
}

    






