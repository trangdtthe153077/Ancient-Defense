using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float x;
    public bool lateStartX;
    Rigidbody2D rb;
    Archer archer;
    public int damage;
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.3f;
        Destroy(gameObject, 3);
    }

    private void Update()
    {

        if (lateStartX == false)
        {
            x = transform.localEulerAngles.z;
            lateStartX = true;
        }
        Vector2 direction =  rb.velocity;
        float angle= Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("Take damage");
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
