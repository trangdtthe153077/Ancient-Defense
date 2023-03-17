using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoldierMoving : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        
    }
	//void StopMoving()
	//{
	//	Dừng di chuyển của quái
	//	rb.velocity = Vector2.zero;
	//	rb.angularVelocity = 0f;
	//	rb.Sleep();
	//}
	//IEnumerator RotateObject()
	//{
	//	while (true)
	//	{
	//		transform.Rotate(0, 0, 1);
	//		yield return null;
	//	}
	//}
	// Update is called once per frame
	void Update()
    {
		//foreach (Collider2D collider in colliders)
		//{
		//	if (collider.tag == "enemy")
		//	{
		//		Enemy enemy = collider.GetComponent<Enemy>();


		//		if (enemy != null)
		//		{

		//			StartCoroutine(RotateObject());
		//			tower.TakeDamage(damage);
		//			StopMoving();

		//		}
		//		else
		//		{
		//			Tower component không tồn tại trên đối tượng
		//			Debug.Log("Tower component not found!");
		//		}
		//	}
		//}
		transform.position += Vector3.right * speed * Time.deltaTime;
    }
	
}
