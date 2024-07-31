using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    public Transform pellets;
    [SerializeField] GameManager GameManager;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    void Update ()
    {
        if (remainingTime > 5)
        {
            if (!HasRemainingPellets())
            {
                GameManager.GameWin();
            }
            else {
            remainingTime -= Time.deltaTime;
            }
            
        }
        else if (remainingTime <= 5)
        {
            if (!HasRemainingPellets())
            {
                GameManager.GameWin();
            }
            else if (HasRemainingPellets())
            {
            remainingTime -= Time.deltaTime;
            timerText.color = Color.red;
            if (remainingTime < 0)  
            {
                remainingTime = 0; 
                GameManager.GameOver();
            }
            }
            
            
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);

    }
    private bool HasRemainingPellets()
    {
        foreach( Transform pellet in this.pellets )
        {
            if(pellet.gameObject.activeSelf) { //activeSelf kiem tra gameobject pellet có con hien tren scene hay k 
                return true; //Hay kiem tra su hoạt dong vien thuoc con ton tai hay 0
            }
        }

        return false; 
    }
}
