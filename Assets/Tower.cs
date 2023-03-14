using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth =100;
    public int currentHealth;
    public int maxMana= 50;
    public int currentMana;
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
