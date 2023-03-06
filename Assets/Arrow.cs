using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Profiling;
using UnityEditor.PackageManager;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float x;
    public bool lateStartX;
    Rigidbody2D rb;
    Archer archer;
    public int damage;
    Vector2 startPos;
    Vector3 nextPos;

    int arcHeight = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = 5;
        /*      rb.gravityScale = 0.3f;*/
        Destroy(gameObject, 3);

        startPos = transform.position;
    }
    void Update()
    {

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        /*        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
        transform.rotation= Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);



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
