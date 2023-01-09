using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
   
    public int waveTime;
    int tempTime;

    public GameObject[] waves;

    public GameObject winPanel;
    public Camera cam;

    AudioSource audioSource;
    public AudioClip summerAmbient;
    public AudioClip fallAmbient;
    public AudioClip winterAmbient;
    public AudioClip springAmbient;

    public Color springColor;
    public Color summerColor;
    public Color fallColor;
    public Color winterColor;

    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI waveUI;
    public TextMeshProUGUI finalScoreUI;
    public TextMeshProUGUI highScoreUI;

    public GameObject wavePanel;


    string currentWave;

    int waveNum = 0;

    public bool win;








    private void Start()
    {
       
        
        audioSource = GetComponent<AudioSource>();

        tempTime = waveTime;
        //SetSeason();
        
        
        StartCoroutine(CountDown());
      
    }

    private void Update()
    {
        if (tempTime == 40)
        {



            // timeUI.text = tempTime.ToString();
            //SetSeason(); 
            waves[0].gameObject.SetActive(true);
            Debug.Log("wave 1");
           
        }
        if (tempTime == 120)
        {



            // timeUI.text = tempTime.ToString();
            //SetSeason(); 
            waves[1].gameObject.SetActive(true);
            Debug.Log("wave 2");

        }
        if (tempTime == 240)
        {

            Debug.Log("wave 3");

            // timeUI.text = tempTime.ToString();
            //SetSeason(); 
            waves[2].gameObject.SetActive(true);
            
        }
    }

    void SetSeason()
    {
        switch(waveNum)
        {
            case 0:
                waves[waveNum].gameObject.SetActive(true);
                //currentWave = "The Arrival";
                //audioSource.clip = summerAmbient;
                //cam.backgroundColor = summerColor;
                //StartCoroutine(SeasonInfo());
                waveTime += 10;
                break;
            case 1:
                waves[waveNum].gameObject.SetActive(true);
                //currentWave = "Seeding time";
                //audioSource.clip = fallAmbient;
                //waveUI.text = currentWave;
                //cam.backgroundColor = fallColor;
                //StartCoroutine(SeasonInfo());
                break;
            case 2:
                waves[waveNum].gameObject.SetActive(true);
                //currentWave = "Fight for your crops";
                //audioSource.clip = winterAmbient;

                //waveUI.text = currentWave;
                //cam.backgroundColor = winterColor;

                //StartCoroutine(SeasonInfo());
                break;
            case 3:
               // waves[waveNum].gameObject.SetActive(true);
                //currentWave = "Harvest Moon";
                //audioSource.clip = winterAmbient;

                //waveUI.text = currentWave;
                //cam.backgroundColor = winterColor;

                //StartCoroutine(SeasonInfo());
                break;
            case 4:
                win = true;
               
                //StopAllCoroutines();
                //Time.timeScale = 0;
                //audioSource.clip = springAmbient;
                //winPanel.SetActive(true);
                //finalScoreUI.text = "Nutrition saved: ";
                //highScoreUI.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
                break;

        }

        //audioSource.Play();



    }



    public IEnumerator CountDown()
    {
        //timeUI.text = tempTime.ToString();
        yield return new WaitForSeconds(1);
        tempTime++;
        
        StartCoroutine(CountDown());
    }

    public IEnumerator SeasonInfo()
    {
        
        wavePanel.SetActive(true);
        waveUI.text = currentWave;
        yield return new WaitForSeconds(1);
        wavePanel.SetActive(false);
        yield return new WaitForSeconds(1);
       

    }
}
