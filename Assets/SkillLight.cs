using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLight : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    void Start()
    {

        damage  = GetComponent<Archer>().Basedmg*2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Debug.Log("Take damage");
            enemy.TakeDamage((int)damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
