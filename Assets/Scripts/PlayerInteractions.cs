using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public HealthBar healthBar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Changer>() != null)
        {
            Changer changer = other.GetComponent<Changer>();
            if (changer.changeType == Changer.ChangeType.Health)
            {
                healthBar.ChangeHealth(changer.changeAmount);
            }
            if (changer.changeType == Changer.ChangeType.Score)
            {
                GameManager.AddScore(changer.changeAmount);
            }
            if (changer.changeType == Changer.ChangeType.Seed)
            {
                GameManager.AddSeed(1);
            }
            if (changer.destroyAfterCollsion)
            {
                Destroy(other.gameObject);
            }
        }
        if(other.GetComponent<ScoreChanger>() != null)
        {
            ScoreChanger scoreChanger = other.GetComponent<ScoreChanger>();
        }
        
    }
}
