using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 5;
    public enum EnemyState {Dangerous, Vulnerable};
    public EnemyState state;
    public GameObject[] drops;
    public int dropNumber = 5;
    Quaternion spreadRotation;
    public Transform spreadPoint;
    public AudioSource plantExplosion;
    public AudioSource enemyHit;


    private void Start()
    {
        spreadRotation = Quaternion.identity;
        plantExplosion = GameObject.FindGameObjectWithTag("ExplosionSound").GetComponent<AudioSource>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            health -= 1;
            enemyHit.pitch = Random.Range(1, 1.5f);
            enemyHit.Play();
            if(health < 3)
            {
                state = EnemyState.Vulnerable;
            }
            if (health == 0)
            {
                for (int i = 0; i < dropNumber; i++)
                {
                    spreadRotation.eulerAngles = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
                    Instantiate(drops[Random.Range(0, drops.Length)], spreadPoint.position, spreadRotation);
                    
                }
                if(plantExplosion != null)
                plantExplosion.Play();
                transform.parent.GetComponent<Collider>().enabled = false;
                Destroy(gameObject);

            }

        }
    }
}
