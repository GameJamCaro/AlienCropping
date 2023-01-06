using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 50;
    Rigidbody clone;

    float fireRate = 0.11f;
    private float lastShot = -10.0f;

     void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > fireRate + lastShot)
            {
                clone = Instantiate(projectile, transform.position, transform.rotation);
                
                clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

                lastShot = Time.time;
            }
            Destroy(clone.gameObject, 3);
        }
    }
}
