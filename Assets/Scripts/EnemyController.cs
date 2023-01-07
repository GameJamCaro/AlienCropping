using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 5;
    public enum EnemyState {Dangerous, Vulnerable};
    public EnemyState state;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            health -= 1;
            if(health < 3)
            {
                state = EnemyState.Vulnerable;
            }
            if (health < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
