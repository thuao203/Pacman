using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    AudioManager audioManager;
    public Text pointsText;
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
        pointsText.text = "Score " + score.ToString();
        if (HighScore < score)
        PlayerPrefs.SetInt("HighScore", score);
    }
    
    public void Music()
    {
        audioManager.PlaySFX(audioManager.Touch);
    }
    
}
