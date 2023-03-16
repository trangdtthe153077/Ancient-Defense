using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // Kéo và thả prefab của đối tượng vào đây trong Inspector
    public int numberOfObjects; // Số lượng đối tượng muốn spawn
    public float speed = 5.0f; // Tốc độ di chuyển của đối tượng
    private GameObject targetEnemy; // Đối tượng enemy gần nhất

    void Start()
    {
        // Tìm đối tượng enemy gần nhất
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                targetEnemy = enemy;
            }
        }

        // Spawn đối tượng và di chuyển chúng đến enemy gần nhất
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            StartCoroutine(MoveToObject(newObject, targetEnemy));
        }
    }

    IEnumerator MoveToObject(GameObject obj, GameObject target)
    {
        while (Vector3.Distance(obj.transform.position, target.transform.position) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target.transform.position, speed * Time.deltaTime);
            yield return null;
        }
    }

}
