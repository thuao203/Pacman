using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Music()
    {
        audioManager.PlaySFX(audioManager.Touch);
    }
}
