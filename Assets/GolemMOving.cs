using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMOving : MonoBehaviour
{
	// Start is called before the first frame update
	private Rigidbody2D rb;

	public int damage = 10;
	public int maxHealth = 150;
	private int currentHealth;
	public float attackSpeed = 1.0f;
	public float speed;
	public bool hasFoundEnemy = false;
	public bool enemiesPresent = false;


	void Start()
    {
		currentHealth = maxHealth;
		rb = GetComponent<Rigidbody2D>();

	}
	void StopMoving()
	{
		if (enemiesPresent)
		{
			// Dừng di chuyển của quái
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
			transform.position += Vector3.right * speed * Time.deltaTime;


		}
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
		foreach (Collider2D collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
				Enemy enemy = collider.GetComponent<Enemy>();


				if (enemy != null)
				{
					enemy.TakeDamage(damage);
					StartCoroutine(RotateObject());

				}
				else
				{
					//Tower component không tồn tại trên đối tượng
				}
			}
		}
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
	void OnDestroy()
	{
		if (GameObject.FindGameObjectWithTag("Enemy") == null)
		{
			enemiesPresent = false;
			rb.WakeUp();
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			hasFoundEnemy = true;
			StopMoving();

			enemiesPresent = true;

		}
		else
		{
			enemiesPresent = false;
			StopMoving();
		}

		

	}
}
