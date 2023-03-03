using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    int health = 10;
    public int maxHealth = 10;
    private int currentHealth;



    void Start()
    {
        currentHealth = maxHealth;
     /*   Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        transform.position = new Vector3(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y), 0f);*/

   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 3f * Time.deltaTime);
        /* GetComponent<Rigidbody2D>().AddForce(-transform.right * 0.5f);*/
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Arrow arrow = collision.gameObject.GetComponent<Arrow>();
             health = health;
         
            Destroy(collision.gameObject);
        }
    }*/

    
    public void TakeDamage(int damage)
    {
        Debug.Log("Auuu");
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
    }
}
