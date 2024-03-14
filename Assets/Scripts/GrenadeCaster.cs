using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform grenadeSourseTransform;

    public float force = 10;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSourseTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSourseTransform.forward * force);

        }

    }
}
