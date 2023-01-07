using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    public enum CameraStyle {Basic, Combat, Topdown };
    public CameraStyle currentCamStyle;
    public CameraStyle newCamStyle;

    public Transform combatLookAt;

    public GameObject basicCam;
    public GameObject combatCam;
    public GameObject topDownCam;

    public MusicManager musicManager;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SwitchCamStyle(currentCamStyle);
    }


    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCamStyle(CameraStyle.Basic);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCamStyle(CameraStyle.Combat);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchCamStyle(CameraStyle.Topdown);

        if (currentCamStyle == CameraStyle.Basic || currentCamStyle == CameraStyle.Topdown)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
            if (musicManager.clipIndex != 0)
            {
                musicManager.MusicSwitch(0);
            }

        }
        else if(currentCamStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
            if (musicManager.clipIndex == 0)
            {
                int random = Random.Range(1, 3);
                musicManager.MusicSwitch(random);
                Debug.Log(random);
            }
        }
    }

    public void SwitchCamStyle(CameraStyle cameraStyle)
    {
        newCamStyle = cameraStyle;

        basicCam.SetActive(false);
        combatCam.SetActive(false);
        topDownCam.SetActive(false);

        if(newCamStyle == CameraStyle.Basic) basicCam.SetActive(true);
        if (newCamStyle == CameraStyle.Combat) combatCam.SetActive(true);
        if (newCamStyle == CameraStyle.Topdown) topDownCam.SetActive(true);

        currentCamStyle = newCamStyle;
    }

}
