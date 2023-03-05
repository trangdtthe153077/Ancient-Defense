using System;
using UnityEngine;

public class AutoArcher : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float fireInterval;
    public float detectionRange = 10000f;
    private float timer;
    public float fireAngle = 5f;
    Archer archer;
    private void Start()
    {
        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2f)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2f)));
        detectionRange = distance;

         archer  = GetComponent<Archer>();
        fireInterval = archer.speed;
    
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
                Fire(targetPosition);
            }

            // Reset the timer
            timer = 0f;
        }
    }

    /*    void Update()
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

                    // Calculate the rotation needed to face the enemy
                    Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetDirection);

                    // Fire an arrow
                    Fire(targetRotation);
                }

                // Reset the timer
                timer = 0f;
            }
        }
    */
    /*    void Update()
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
        }*/

    GameObject FindClosestEnemy()
    {
        // Find all enemies within range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
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

    /*    void Fire()
        {
            // Create a new arrow and set its position and rotation
            GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);

            // Apply a force to the arrow to make it move forward
            arrow.GetComponent<Rigidbody2D>().AddForce(transform.right * 1500f);
            arrow.GetComponent<Arrow>().damage= Mathf.RoundToInt(archer.damage);
        }*/
    /*    void Fire()
        {
            // Create a new arrow and set its position and rotation
            GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);

            // Apply a force to the arrow to make it move forward and upward
            Vector2 forwardForce = transform.right * 1500f;
            Vector2 upwardForce = transform.up * 200f;
            arrow.GetComponent<Rigidbody2D>().AddForce(forwardForce + upwardForce);

            // Set the arrow damage
            arrow.GetComponent<Arrow>().damage = Mathf.RoundToInt(archer.damage);
        }*/




    /*   void Fire(Quaternion targetRotation)
       {
           // Create a new arrow and set its position and rotation
           GameObject arrow = Instantiate(arrowPrefab, transform.position, targetRotation);

           // Apply a force to the arrow to make it move forward
           arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * 1500f);
           arrow.GetComponent<Arrow>().damage = Mathf.RoundToInt(archer.damage);
       }*/

    /*    void Fire(Quaternion targetRotation)
        {
            // Create a new arrow and set its position and rotation
            GameObject arrow = Instantiate(arrowPrefab, transform.position, targetRotation);

            // Apply a force to the arrow to make it move forward and upward at an angle
            Vector2 forwardForce = arrow.transform.right * 1500f;
            Vector2 upwardForce = Quaternion.AngleAxis(30f, Vector3.forward) * arrow.transform.up * 100f;
            arrow.GetComponent<Rigidbody2D>().AddForce(forwardForce + upwardForce);

            arrow.GetComponent<Arrow>().damage = Mathf.RoundToInt(archer.damage);
        }*/

    /*    void Fire(Vector3 target)
        {
            // Calculate the initial velocity of the arrow
            Vector3 direction = target - transform.position;
            float h = direction.y;
            direction.y = 0;
            float distance = direction.magnitude;
            direction.y = distance;
            float v = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * fireAngle * Mathf.Deg2Rad));
            Vector3 velocity = v * direction.normalized;

            // Create a new arrow and set its position and rotation
            GameObject arrow = Instantiate(arrowPrefab, transform.position - direction.normalized * 1f, Quaternion.identity);
            *//*        arrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);*//*

            // Apply the initial velocity to the arrow
            arrow.GetComponent<Rigidbody2D>().velocity = velocity * 2f;
            arrow.GetComponent<Arrow>().damage = Mathf.RoundToInt(archer.damage);
        }*/



    void Fire(Vector3 target)
    {
        // Calculate the initial velocity of the arrow
     /*   Vector3 direction = target - transform.position;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        direction.y = distance;
        float v = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * 1 * Mathf.Deg2Rad));
        Vector3 velocity = v * direction.normalized;*/

        // Create a new arrow and set its position and rotation
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Arrow>().setPos(target);

        // Apply the initial velocity to the arrow
        /*  arrow.GetComponent<Rigidbody2D>().velocity = velocity;
          arrow.GetComponent<Arrow>().damage = Mathf.RoundToInt(archer.damage);*/
    }
}
