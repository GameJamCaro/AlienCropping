using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public HealthBar healthBar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NiceCrop"))
        {
            Destroy(other.gameObject);
            healthBar.ChangeHealth(1);
        }
        if (other.CompareTag("BadCrop"))
        {
            healthBar.ChangeHealth(-1);
            Debug.Log("au");
        }
    }
}
