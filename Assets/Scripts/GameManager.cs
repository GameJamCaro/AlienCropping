using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    int playerScore;
    int seedScore;

    public ScoreDisplay[] scoreUIs;

    private void Start()
    {
        seed = 0;
        score = 0;
    }


    private void Awake()
    {
        // When this component is first added or activated, setup the global reference
        if (instance == null)
        {
            instance = this;
        }
        else
        {
           Destroy(this.gameObject);
        }
    }
    public static int score
    {
        get
        {
            return instance.playerScore;
        }
        set
        {
            instance.playerScore = value;
        }
    }

    public static int seed
    {
        get
        {
            return instance.seedScore;
        }
        set
        {
            instance.seedScore = value;
        }
    }

    public static void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        GameManager.UpdateUI();    
        
    }
    public static void AddSeed(int scoreAmount)
    {
        seed += scoreAmount;
        Debug.Log(seed);
        GameManager.UpdateUI();
       

    }

    public static void UseSeed(int scoreAmount)
    {
        seed -= scoreAmount;
        Debug.Log(seed);
        GameManager.UpdateUI();


    }


    public static void UpdateUI()
    {
       
        instance.scoreUIs[0].DisplayScore();
        instance.scoreUIs[1].DisplayScore();
    }

    
}
