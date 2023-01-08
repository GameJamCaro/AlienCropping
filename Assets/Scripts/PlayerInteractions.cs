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
    public GameObject deathPanel;


    private void Start()
    {
        //deathPanel.SetActive(false);
        Time.timeScale = 1;
    }

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
                info.text = "Growing Area - press G";
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
            info.text = "Growing Area" +
                " - press G";
        }
        if (other.GetComponent<Changer>() != null)
        {
            Changer changer = other.GetComponent<Changer>();
            if (changer.changeType == Changer.ChangeType.Health)
            {
                healthBar.ChangeHealth(changer.changeAmount);
                if(healthBar.currentHealth < 1)
                {
                    deathPanel.SetActive(true);
                    Cursor.visible = true;
                    //Time.timeScale = 0;
                    
                }
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
