using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource; 
    [Header("----------Audio Clip------------")]
    public AudioClip Background1;
    public AudioClip PacmanDeath;
    public AudioClip PacmanEaten;
    public AudioClip PowerPelletEaten;
    public AudioClip GhostEaten;
    public AudioClip Victory;
    public AudioClip Touch;
    private void Start()
    {
        musicSource.clip = Background1;
        musicSource.Play();
    }
    
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
