using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 2f; // Tốc độ di chuyển của đối tượng
    public GameObject targetObject;
    public GameObject walkAnimation;
    public GameObject attackAnimation;

    private bool isAttacking = false;

    // Update is called once per frame
    void Update()
    {
        // Di chuyển object sang phải theo trục X với tốc độ được chỉ định
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Nếu object gặp targetObject thì chuyển sang trạng thái tấn công
        if (Vector3.Distance(transform.position, targetObject.transform.position) < 1f && !isAttacking)
        {
            isAttacking = true;
            speed = 0f;
            walkAnimation.SetActive(false);
            attackAnimation.SetActive(true);
        }
    }
}

