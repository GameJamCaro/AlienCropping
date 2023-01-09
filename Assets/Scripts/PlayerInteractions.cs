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
    bool atPlant;
    public GameObject deathPanel;

    public AudioSource plantSound;
    public AudioSource hurtSound;
    public AudioSource collectSound;

    private void Start()
    {
        deathPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.G) && inGrowingArea && !atPlant)
        {
            if (GameManager.seed < 1)
            {
                info.text = "You need seeds to plant";
            }
            else
            {
                info.text = "Growing Area \n press (g) to grow plant";
                Instantiate(moleHill, transform.position, Quaternion.identity);
                GameManager.UseSeed(1);
                plantSound.Play();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("GrowingArea"))
        {
            inGrowingArea = true;
            if (GameManager.seed < 1)
            {
                info.text = "You need seeds to plant";
            }
            else
            {
                info.text = "Growing Area \n press (g) grow to plant";
            }
           
        }
        


        if(other.CompareTag("Plant"))
        {
            atPlant = true;
        }
        if (other.GetComponent<Changer>() != null)
        {
            Changer changer = other.GetComponent<Changer>();
            if (changer.changeType == Changer.ChangeType.Health)
            {
                if(changer.changeAmount < 0) 
                {
                    hurtSound.Play();
                }
                else
                {
                    collectSound.pitch = 1.2f;
                    collectSound.Play();
                }
                
                healthBar.ChangeHealth(changer.changeAmount);
                if(healthBar.currentHealth < 1)
                {
                    deathPanel.SetActive(true);
                    Cursor.visible = true;
                    Time.timeScale = 0;
                    
                }
            }
            if (changer.changeType == Changer.ChangeType.Score)
            {
                GameManager.AddScore(changer.changeAmount);
                collectSound.pitch = 1.3f;
                collectSound.Play();
            }
            if (changer.changeType == Changer.ChangeType.Seed)
            {
                GameManager.AddSeed(1);
                collectSound.Play();
                collectSound.pitch = 1.1f;
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
        if (other.CompareTag("Plant"))
        {
            atPlant = false;
        }
    }
}
