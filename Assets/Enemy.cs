using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public float attackDistance = 1f;

    private Rigidbody2D rb;
    int health = 10;
    public int maxHealth = 10;
    private int currentHealth;
    public int damage = 10; // Lượng sát thương gây ra khi tấn công
    public float attackDelay = 2f; // Thời gian giữa hai lần tấn công
    private float attackTimer; // Thời gian từ lần tấn công cuối cùng
    public GameObject coinPrefab; // đối tượng tiền tệ
    public int coinCount = 1; // số lượng tiền tệ rơi ra
    private bool isDead = false; // kiểm tra quái đã chết hay chưa

    public GameObject Player;

    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // quái di chuyển sang trái
        transform.Translate(Vector3.left * 3f * Time.deltaTime);
        /* GetComponent<Rigidbody2D>().AddForce(-transform.right * 0.5f);*/
        // Tính toán thời gian giữa hai lần tấn công
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            attackTimer = 0f;

            // Tấn công nếu người chơi ở trong vùng va chạm
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Player")
                {
                    collider.GetComponent<Player>().TakeDamage(damage);
                }
            }
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
        else if (other.gameObject.CompareTag("Arrow"))
        {
            Arrow arrow = other.GetComponent<Arrow>();
            TakeDamage(arrow.damage);
        }
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    Tiền sẽ rơi ra tại vị trí hiện tại của quái vật
        //    Instantiate(coinPrefab, transform.position, Quaternion.identity);
        //    Destroy quái vật
        //    Destroy(gameObject);
        //}
    }
    void MoveTowardsPlayer()
    {
        Vector2 direction = target.position - transform.position;
        rb.velocity = direction.normalized * speed;
    }

    void Attack()
    {
        // Add code to damage the player here
    }
    //void Fire()
    //{
    //    // Create a new arrow and set its position and rotation
    //    GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);

    //    // Apply a force to the arrow to make it move forward
    //    arrow.GetComponent<Rigidbody2D>().AddForce(transform.right * 1500f);
    //    arrow.GetComponent<Arrow>().damage = Mathf.RoundToInt(archer.damage);
    //}
}






