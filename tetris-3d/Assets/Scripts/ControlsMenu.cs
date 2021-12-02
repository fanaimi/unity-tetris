using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
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

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void PlayHoverSound()
    {
        // FindObjectOfType<AudioManager>().Play("UiBuzzer");
    }
}