using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public CinemachineFreeLook thirdPersonCam;

    Animator anim;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity = 10;

    public bool stopWalking;
    bool isWalking;

    

    float targetAngle;
    
    float camSpeedX;
    float camSpeedY;

    float angle;




    void Start()
    {
        



        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;

      
            //// saves cam speed from inspector
            //camSpeedX = thirdPersonCam.m_XAxis.m_MaxSpeed;
            //camSpeedY = thirdPersonCam.m_YAxis.m_MaxSpeed;
            //// disables cam movement
            //thirdPersonCam.m_XAxis.m_MaxSpeed = 0;
            //thirdPersonCam.m_YAxis.m_MaxSpeed = 0;
       
    }

   
    void Update()
    {

        //// enables cam movement
        //thirdPersonCam.m_XAxis.m_MaxSpeed = camSpeedX;
        //thirdPersonCam.m_YAxis.m_MaxSpeed = camSpeedY;
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Vector3 mousePos = Input.mousePosition;
        //    mousePos.y = 0;
        //    transform.LookAt(mousePos);
        //}

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
        
           
                Vector3 direction = new Vector3(horizontal, 0f, vertical);
       
            if (!stopWalking)
            {
                if (direction.x != 0 || direction.z != 0)
                {
                    anim.SetBool("walking", true);
                    isWalking = true;
                    speed = 10;
                   
                }
                else
                {
                   
                        anim.SetBool("walking", false);
                        isWalking = false;
                    speed = 0;
                   
                    
                }



                if (isWalking)
                {
                    targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                    angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }
                else
                    targetAngle = 0;

                

            if (isWalking)
            {
                Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
                controller.Move(moveDir * speed * Time.deltaTime);
            }
        }
        }
           
        
        
        
    }

