using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierGenerator : MonoBehaviour
{
    public int objectCount ; // Số lượng đối tượng cần tạo
    public float spacing ; // Khoảng cách giữa các đối tượng
    public float speed ; // Tốc độ di chuyển của đối tượng
    public GameObject walkAnimation;
    public GameObject attackAnimation;
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        // Tạo ra các đối tượng
        for (int i = 0; i < objectCount; i++)
        {
            // Tạo ra một instance của prefab
            GameObject obj = Instantiate(walkAnimation, transform);

            // Đặt vị trí của đối tượng
            float xPos = -5f + i * spacing;
            float yPos = -4f; // Đặt vị trí Y tại đáy màn hình
            obj.transform.position = new Vector3(xPos, yPos, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển các đối tượng sang phải theo trục X với tốc độ được chỉ định
        if (!isAttacking)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            isAttacking = true;
            speed = 0f;
            walkAnimation.SetActive(false);
            attackAnimation.SetActive(true);
        }
    }
}
