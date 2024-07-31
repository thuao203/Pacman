using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void OpenLevel (int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
        
    }
    public void Music()
    {
        audioManager.PlaySFX(audioManager.Touch);
    }
}
