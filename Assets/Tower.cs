﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;


public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth =100;
    public int currentHealth;
    public int maxMana= 50;
    public int currentMana;
    public TextMeshProUGUI healthtext;
    public TextMeshProUGUI manatext;
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        healthtext.text = currentHealth.ToString();
        manatext.text = currentMana.ToString();
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
    public int getHealth()
    {
        return currentHealth;
    }
    public void setHealth(int health)
    {
        currentHealth = health;
    }
    public int getMana()
    {
        return currentMana;
    }
    public void setMana(int mana)
    {
        currentMana = mana;
    }
}
