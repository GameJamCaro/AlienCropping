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
    public ThirdPersonCam cam;

    public PlayerMovement player;

    public float camResetTime = 5;
    float timer;

    public Transform shotLocation;

    public AudioSource shotSound;


    private void Start()
    {
        timer = camResetTime;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }



    void Update()
    {
        if (shooterType == Type.Player)
        {
            
            if (Input.GetButtonDown("Fire1"))
            {

                target.GetComponentInChildren<Shooter>().CameraSwitch();

                player.Shoot();
                
                if (Time.time > fireRate + lastShot)
                {
                    shotSound.Play();
                    clone = Instantiate(projectile, transform.position, transform.rotation);

                    clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

                    lastShot = Time.time;
                }
                Destroy(clone.gameObject, 2);
                timer = camResetTime;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.position) < shootDistance)
            {
                //target.GetComponentInChildren<Shooter>().CameraSwitch();
            }



            if (/*Vector3.Distance(transform.position, target.position) < shootDistance && */ !doNotShoot)
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


            if (shotLocation != null)
            {
                clone = Instantiate(projectile, shotLocation.position, shotLocation.rotation);

                if (clone != null)
                {
                    clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed));


                    Destroy(clone.gameObject, 2);
                }
            }
        }


        

        IEnumerator WaitAndShoot() 
        {
            ShootAtTarget();
           
            yield return new WaitForSeconds(shotInterval);
            doNotShoot = false;
            StartCoroutine(WaitAndShoot());
        }
    }

    


    IEnumerator WaitAndResetCam()
    {
        yield return new WaitForSeconds(1);
        timer--;
        if (timer == 0)
        {
            cam.SwitchCamStyle(ThirdPersonCam.CameraStyle.Basic);
        }
        else
        {
            StartCoroutine(WaitAndResetCam());
        }
    }


    public void CameraSwitch()
    {
        if (cam.currentCamStyle != ThirdPersonCam.CameraStyle.Combat)
        {
            cam.SwitchCamStyle(ThirdPersonCam.CameraStyle.Combat);
            //StartCoroutine(WaitAndResetCam());
        }
    }
}
