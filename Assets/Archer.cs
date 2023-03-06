using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Archer : MonoBehaviour
{
    private float damage = 5;
    private float basedmg = 5;
    private float speed = 1f;
    private float health = 0;

    public float Damage { get => damage; set => damage = value; }
    
    public float Speed { get => speed; set => speed = value; }
    public float Health { get => health; set => health = value; }
    public float Basedmg { get => basedmg; set => basedmg = value; }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
