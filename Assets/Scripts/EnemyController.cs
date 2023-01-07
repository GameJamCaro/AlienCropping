using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 5;
    public enum EnemyState {Dangerous, Vulnerable};
    public EnemyState state;
    public GameObject crop;
    public int cropNumber = 5;
    Quaternion spreadRotation;


    private void Start()
    {
        spreadRotation = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            health -= 1;
            if(health < 3)
            {
                state = EnemyState.Vulnerable;
            }
            if (health == 0)
            {
                for (int i = 0; i < cropNumber; i++)
                {
                    spreadRotation.eulerAngles = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
                    Instantiate(crop, transform.position, spreadRotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
