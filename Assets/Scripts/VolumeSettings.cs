using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    [SerializeField] private AudioMixer  myMixer;
    [SerializeField] private Slider  musicSlider;
    [SerializeField] private Slider  SFXSlider;

    private void Start()
    {   
        SetMusicVolume(); 
        SetSFXVolume();       
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        

    }
    public void Music()
    {
        audioManager.PlaySFX(audioManager.Touch);
    }

    

}  
