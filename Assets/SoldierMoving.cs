using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMoving : MonoBehaviour
{
	private Rigidbody2D rb;

	public int damage = 1;
	// Start is called before the first frame update
	public float speed;
    void Start()
    {
        
    }
	void StopMoving()
	{
		// Dừng di chuyển của quái
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
		rb.Sleep();
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
				Debug.Log("Finish turn " + numRotations);
			}
		}
	}
	// Update is called once per frame
	void Update()
    {
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
					StopMoving();

				}
				else
				{
					//Tower component không tồn tại trên đối tượng
					Debug.Log("Tower component not found!");
				}
			}
		}
		transform.position += Vector3.right * speed * Time.deltaTime;
    }
	
}
