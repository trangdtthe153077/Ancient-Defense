using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public int objectCount = 5; // Số lượng đối tượng cần tạo
    public float spacing = 0.5f; // Khoảng cách giữa các đối tượng
    public float speed = 2f; // Tốc độ di chuyển của đối tượng
    public GameObject targetObject;
    public GameObject walkAnimation;
    public GameObject attackAnimation;

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

            // Thêm component ObjectMovement và truyền tốc độ cho nó
            ObjectMovement objMovement = obj.AddComponent<ObjectMovement>();
            objMovement.speed = speed;
            objMovement.targetObject = targetObject;
            objMovement.walkAnimation = walkAnimation;
            objMovement.attackAnimation = attackAnimation;
        }
    }
}
