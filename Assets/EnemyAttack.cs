using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float fireInterval;
    public float detectionRange = 10000f;
    private float timer;

    Enemy enemy;

    private void Start()
    {
        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2f)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2f)));
        detectionRange = distance;

        enemy = GetComponent<Enemy>();
        fireInterval = enemy.speed;

    }
    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to fire
        if (timer >= fireInterval)
        {
            // Find the closest enemy within range
            GameObject closestEnemy = FindClosestEnemy();

            // Aim the archer towards the enemy
            if (closestEnemy != null)
            {
                Vector3 targetDirection = closestEnemy.transform.position - transform.position;
                transform.right = targetDirection.normalized;

                // Fire an arrow
                Fire();
            }

            // Reset the timer
            timer = 0f;
        }
    }

    GameObject FindClosestEnemy()
    {
        // Find all enemies within range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // Find the closest enemy
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance && distance <= detectionRange)
            {
                closestEnemy = enemy;
                closestDistance = distance;
                //Debug.Log(enemy.transform.position.x + "," + enemy.transform.position.y);
            }
        }

        return closestEnemy;
    }

    void Fire()
    {
        // Create a new arrow and set its position and rotation
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);

        // Apply a force to the arrow to make it move forward
        arrow.GetComponent<Rigidbody2D>().AddForce(transform.right * 1500f);
        arrow.GetComponent<Arrow>().damage = Mathf.RoundToInt(enemy.damage);
    }
}
