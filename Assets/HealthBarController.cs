using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public Tower tower;
    public float maxHealthbarLength;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateHealthbar()
    {
        float healthPercentage = tower.currentHealth / tower.maxHealth;
        transform.localScale = new Vector3(healthPercentage * maxHealthbarLength, transform.localScale.y, transform.localScale.z);
    }
    void Update()
    {
    }
}
