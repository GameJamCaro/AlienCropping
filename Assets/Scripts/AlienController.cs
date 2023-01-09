using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienController : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public int health = 3;
    Quaternion spreadRotation;
    public GameObject[] drops;
    public int dropNumber;
    public Animator anim;
    public AudioSource deathSound;
    bool isDead;

    public Transform spreadSpot;
    public AudioSource enemyHit;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        spreadRotation = Quaternion.identity;

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(transform.position, player.transform.position) < 30)
        {
            //player.GetComponentInChildren<Shooter>().CameraSwitch();
        }
    }


    bool once;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            health -= 1;
            enemyHit.pitch = Random.Range(1, 1.5f);
            enemyHit.Play();
            if (health < 1)
            {
               
                if (!once)
                {
                    for (int i = 0; i < dropNumber; i++)
                    {
                        spreadRotation.eulerAngles = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
                        Instantiate(drops[Random.Range(0, drops.Length)], spreadSpot.position, spreadRotation);
                    }
                    anim.SetTrigger("death");

                    deathSound.Play();
                    once = true;
                    isDead = true;
                }
                Destroy(gameObject, 1);
            }
            


        }
    }
}
