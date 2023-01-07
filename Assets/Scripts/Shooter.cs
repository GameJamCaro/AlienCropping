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
    public enum Type {Player, Enemy };
    public Type shooterType;

    public Transform target;
    public float shotInterval = 1;
    bool doNotShoot;
    public float shootDistance = 10;


    private void Start()
    {
        
    }



    void Update()
    {
        if (shooterType == Type.Player)
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
        else
        {
            if (Vector3.Distance(transform.position, target.position) < shootDistance && !doNotShoot)
            {
                StartCoroutine(WaitAndShoot());
                doNotShoot = true;

            }
            else
            {
                StopCoroutine(WaitAndShoot());
            }
        }

        void ShootAtTarget() 
        {
            transform.LookAt(target);
            
                clone = Instantiate(projectile, transform.position, transform.rotation);

                clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

                
            Destroy(clone.gameObject, 3);
        }


        

        IEnumerator WaitAndShoot() 
        {
            ShootAtTarget();
           
            yield return new WaitForSeconds(shotInterval);
            
            doNotShoot = false;
            StartCoroutine(WaitAndShoot());
        }
    }
}
