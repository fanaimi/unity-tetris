using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    
    private AudioManager audioManager;

    private void Awake()
    {
        
        audioManager = FindObjectOfType<AudioManager>();
    }

    
    private void Start()
    {
        audioManager.Play("menu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    
    
    public void LoadControlsMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        print("quit");
        Application.Quit();
        
    }

    public void PlayHoverSound()
    {
        audioManager.Play("UiBuzzer");
    }
}