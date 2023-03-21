using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{

    public float speed = 5f;
    public Transform target;
    public float attackDistance = 1f;

    private Rigidbody2D rb;
    int basehealth = 10;
    public int maxHealth = 10;
    private int currentHealth;
    public int basedamage = 10;
    public int damage = 10; // Lượng sát thương gây ra khi tấn công
    public float attackDelay = 2f; // Thời gian giữa hai lần tấn công
    private float attackTimer; // Thời gian từ lần tấn công cuối cùng
    public GameObject coinPrefab; // đối tượng tiền tệ
    public int baseCoin;
    public int coinCount = 1; // số lượng tiền tệ rơi ra
    private bool isDead = false; // kiểm tra quái đã chết hay chưa
    public bool hasFoundTower = false;
    public GameObject Towerbd;
	public bool allysPresent = false;



	void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!hasFoundTower)
        {
            // quái di chuyển sang trái
            transform.Translate(Vector3.left * 3f * Time.deltaTime);

        }
       
        /* GetComponent<Rigidbody2D>().AddForce(-transform.right * 0.5f);*/
        // Tính toán thời gian giữa hai lần tấn công
       
        
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            attackTimer = 0f;

            // Tấn công nếu người chơi ở trong vùng va chạm
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Tower" || collider.tag == "Ally")
                {
                    Tower tower = collider.GetComponent<Tower>();
					SoldierMoving ally = collider.GetComponent<SoldierMoving>();



					if (tower != null )
					{

						// Tower component được tìm thấy
						Debug.Log("Found Tower!");
						//StartCoroutine(RotateObject());
						tower.TakeDamage(damage);
                        /*       StartCoroutine(RotateObject());*/
                        StartCoroutine(RotateObject());
                    }
					else
					{
						// Tower component không tồn tại trên đối tượng
						Debug.Log("Tower component not found!");
					}
					if (ally != null)
					{

						// Tower component được tìm thấy
						Debug.Log("Found Tower!");
						//StartCoroutine(RotateObject());
						ally.TakeDamage(damage);
						/*       StartCoroutine(RotateObject());*/
						StartCoroutine(RotateObject());
					}
					else
					{
						// Tower component không tồn tại trên đối tượng
						Debug.Log("Ally component not found!");
					}
				}
            }
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
                Debug.Log("Finish turn " + numRotations);
            }
        }
    }

	void StopMoving()
	{
		if (allysPresent)
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
			rb.velocity = new Vector2(-2, 0); // Thiết lập vận tốc mới cho đối tượng, ví dụ vận tốc trên trục x là 1
            //rb.angularVelocity = 5f; // Thiết lập góc quay mới cho đối tượng, ví dụ góc quay là 5 độ/giây

        }




	}

	public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
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
		if (other.gameObject.CompareTag("Tower") || other.gameObject.CompareTag("Ally"))
		{
            hasFoundTower= true;
			allysPresent = true;

			StopMoving();
            StartCoroutine(RotateObject());


        }
        else
        {
			allysPresent = false;
			StopMoving();

		}

		if (other.gameObject.CompareTag("Ground"))
        {

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }

    public void SetLevel(int lv)
    {

        damage = basedamage + lv;
        maxHealth = basehealth + lv * 3;
        coinCount = baseCoin + lv;

        Debug.Log("DMG, Health of enemy: "+damage + ","+ maxHealth);
    }    
    
}

    






