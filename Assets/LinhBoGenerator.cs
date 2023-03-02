using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhBoGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab của đối tượng muốn tạo
    public int objectCount = 5; // Số lượng đối tượng cần tạo
    public float spacing = 0.2f; // Khoảng cách giữa các đối tượng
    public float speed = 2f; // Tốc độ di chuyển của đối tượng

    // Start is called before the first frame update
    void Start()
    {
        // Tạo ra các đối tượng
        for (int i = 0; i < objectCount; i++)
        {
            // Tạo ra một instance của prefab
            GameObject obj = Instantiate(objectPrefab, transform);

            // Đặt vị trí của đối tượng
            float xPos = -5f + i * spacing;
            float yPos = -3f; // Đặt vị trí Y tại đáy màn hình
            obj.transform.position = new Vector3(xPos, yPos, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển các đối tượng sang phải theo trục X với tốc độ được chỉ định
        foreach (Transform obj in transform)
        {
            obj.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
