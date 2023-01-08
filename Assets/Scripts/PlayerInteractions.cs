using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    public HealthBar healthBar;
    public GameObject moleHill;
    public TextMeshProUGUI info;
    bool inGrowingArea;


    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.G) && inGrowingArea)
        {
            if (GameManager.seed < 1)
            {
                info.text = "You do not have any seeds";
            }
            else
            {
                info.text = "Growing Area";
                Instantiate(moleHill, transform.position, Quaternion.identity);
                GameManager.UseSeed(1);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GrowingArea"))
        {
            inGrowingArea = true;
            info.text = "Growing Area";
        }
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GrowingArea"))
        {
            inGrowingArea = false;
            info.text = "";
        }
    }
}
