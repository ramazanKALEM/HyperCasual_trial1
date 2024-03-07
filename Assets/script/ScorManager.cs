using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScorManager : MonoBehaviour
{
    public static ScorManager instance;
    [SerializeField] TextMeshProUGUI scoreText;
    //private Text scoreText;
    public int score;
    private void Awake()
    {
        scoreText.text = score.ToString();
        //scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        MakeSingleton();
        scoreText.text = score.ToString();
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<TextMeshProUGUI>();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        AddScore(0);
    }


    void Update()
    {   if (scoreText == null)
        {
            //scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<TextMeshProUGUI>();
            scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        }
    }
    public void AddScore(int deger)
    {
        score += deger;
        if (score > PlayerPrefs.GetInt("HighScore",0 ))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
            scoreText.text = score.ToString();
            
    }
    public void RessetScore()
    {
        score = 0;
    }
}

