using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hello : MonoBehaviour
{
    AudioManager audioManager;
    public Text scoreText;
    public Text HighScoreText;
    int HighScore = 0;
    private void Awake()
    {
        HighScore = PlayerPrefs.GetInt("HighScore",0);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        HighScoreText.text = "HighScore: " + HighScore.ToString() ;
    }
    
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score " + score.ToString() ;
        if (HighScore < score)
        PlayerPrefs.SetInt("HighScore", score);
 
    }
    public void Music()
    {
        audioManager.PlaySFX(audioManager.Touch);
    }
    
}

















