using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField]
    GameObject arrowPrefab;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        void Start()
        {
            StartCoroutine(AutoShoot());
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1000))
        {
            Debug.Log("AAAA11");
            if (hit.collider.tag == "Enemy")
            {
                target = hit.collider.transform;
            }
        }
    }
    void Shoot()
    {
        Debug.Log("AAAA11");
        GameObject arrow = Instantiate(arrowPrefab) as GameObject;
        arrow.transform.position = transform.position + transform.forward * 2;
        arrow.transform.rotation = transform.rotation;
        arrow.AddComponent<Rigidbody>();
        arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
    }
    IEnumerator AutoShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (target != null)
            {
                Shoot();
            }
        }
    }
}
