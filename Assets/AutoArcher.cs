using System;
using UnityEngine;

public class AutoArcher : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float fireInterval;
    public float detectionRange = 100000f;
    private float timer;
    public float fireAngle = 5f;
    Archer archer;
    private void Start()
    {
       /* float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2f)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2f)));
        detectionRange = distance;*/

        archer = GetComponent<Archer>();
        fireInterval = archer.Speed;

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
                Vector3 targetPosition = closestEnemy.transform.position;
                // adjust for the height of the enemy
                Debug.Log("Fire");
                Fire(targetPosition);
            }

            // Reset the timer
            timer = 0f;
        }
    }



    GameObject FindClosestEnemy()
    {
        // Find all enemies within range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Found!");
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
                Debug.Log(enemy.transform.position.x + "," + enemy.transform.position.y);
            }
        }

        return closestEnemy;
    }

    void Fire(Vector3 target)
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        Vector3 direction = target - transform.position;

        arrow.GetComponent<Rigidbody2D>().velocity = direction * 3f;

    }
}
