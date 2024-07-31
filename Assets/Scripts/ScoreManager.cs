using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
    public static ScoreManager instance;
    public GameOverScreen GameOverScreen;
    //
    public Text scoreText;
    public Text livesText;
    public Text HighScoreText;
     
    int score = 0;
    int lives = 3;
    int HighScore = 0;

    private void Awake()
    {
        instance = this;
       
    }
    public void Start()
    {   
        HighScore = PlayerPrefs.GetInt("HighScore",0);
        //score = PlayerPrefs.GetInt("Score");
        
        scoreText.text = "SCORE: " + score.ToString() ;
        livesText.text = " X " + lives.ToString() ;
        HighScoreText.text = "HIGHSCORE: " + HighScore.ToString() ;
    }
    
    public void AddPointLives()
    {
        lives -= 1;
        livesText.text = " X " + lives.ToString();
        
        
    }
          
    public void AddPointScore(int score)
    {
        scoreText.text = "SCORE: " + score.ToString()  ;
        //PlayerPrefs.SetInt("Score", score);
        if (HighScore < score){
        PlayerPrefs.SetInt("HighScore", score);
        }
    }
    
    }

