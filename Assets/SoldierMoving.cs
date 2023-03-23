using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMoving : MonoBehaviour
{
	private Rigidbody2D rb;

	public float damage = 1;
	public int maxHealth = 10;
	private int currentHealth;
	public float attackSpeed = 1.0f;
	// Start is called before the first frame update
	public float speed;
	public bool hasFoundEnemy = false;
	public bool enemiesPresent = false;

	public float attackTimer=0f;


	public void setUp(int dmgMainArcher)
	{
		damage = dmgMainArcher/2;
        maxHealth = 3 * dmgMainArcher;
		currentHealth = maxHealth;

        Debug.Log("damage solider " + damage + " health solider" + currentHealth);
	}	
	void Start()
    {
		currentHealth = maxHealth;
		rb = GetComponent<Rigidbody2D>();


	}
	void StopMoving()
	{
		if (enemiesPresent)
		{
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
		rb.Sleep();

		}
		else
		{
			Debug.Log("tiep tuc di chuyen");
			rb.WakeUp(); // Kích hoạt tính toán vật lý cho Rigidbody
			rb.velocity = new Vector2(2, 0); // Thiết lập vận tốc mới cho đối tượng, ví dụ vận tốc trên trục x là 1
			rb.angularVelocity = 5f; // Thiết lập góc quay mới cho đối tượng, ví dụ góc quay là 5 độ/giây

		}




	}

	IEnumerator RotateObject()
	{
		int numRotations = 0;
		float totalRotation = 0f;
		while (numRotations < 1)
		{
			transform.Rotate(0, 0, 10);
			totalRotation += 10f;
			yield return null;
			if (totalRotation >= 360f)
			{
				numRotations++;
			}
		}
	}
	// Update is called once per frame
	void Update()
    {

		if (!hasFoundEnemy)
		{
			// triệu hồi đồng minh đi từ trái sang
			Vector3 movement = new Vector3(1, 0, 0) * speed * Time.deltaTime;
			transform.position += movement;
		}
        attackTimer += Time.deltaTime;
		if (attackTimer >= attackSpeed)
		{
			attackTimer = 0f;
			Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
			foreach (Collider2D collider in colliders)
			{
				if (collider.tag == "Enemy")
				{
					Enemy enemy = collider.GetComponent<Enemy>();


					if (enemy != null)
					{
						enemy.TakeDamage((int)damage);
						StartCoroutine(RotateObject());

					}
					else
					{

						//Tower component không tồn tại trên đối tượng
					}
				}
			}
		}
    }
	public void TakeDamage(int damage)
	{
		Debug.Log("Damage của lính :" + damage);
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
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.CompareTag("Enemy"))
		{
			hasFoundEnemy= true;
			enemiesPresent = true;
			StopMoving();
		}
		else
		{
			enemiesPresent = false;
			StopMoving();
		}



	}
}
