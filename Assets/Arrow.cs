using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEditor.PackageManager;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    /* public float x;
     public bool lateStartX;
     Rigidbody2D rb;
     Archer archer;
     public int damage;
     void Start()
     {
          rb = GetComponent<Rigidbody2D>();
  *//*       rb.gravityScale = 0.3f;*//*
         Destroy(gameObject, 3);
     }

     private void Update()
     {

      *//*   if (lateStartX == false)
         {
             x = transform.localEulerAngles.z;
             lateStartX = true;
         }

         Vector2 direction = rb.velocity ;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

         transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*//*
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
     }*/









    [Tooltip("Position we want to hit")]
    public Vector3 targetPos;

    [Tooltip("Horizontal speed, in units/sec")]
    public float speed = 10;

    [Tooltip("How high the arc should be, in units")]
    public float arcHeight = 1;


    Vector3 startPos;

    void Start()
    {
        // Cache our start position, which is really the only thing we need
        // (in addition to our current position, and the target).
        startPos = transform.position;
    }

    void Update()
    {
        // Compute the next position, with arc added in
        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
        Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

        // Rotate to face the next position, and then move there
        transform.rotation = LookAt2D(nextPos - transform.position);
        transform.position = nextPos;

        // Do something when we reach the target
        if (nextPos == targetPos) Arrived();
    }

    public void setPos(Vector3 pos)
    {
        startPos = pos;
    }
    void Arrived()
    {
  /*      Destroy(gameObject);*/
    }

    /// 
    /// This is a 2D version of Quaternion.LookAt; it returns a quaternion
    /// that makes the local +X axis point in the given forward direction.
    /// 
    /// forward direction
    /// Quaternion that rotates +X to align with forward
    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}
