using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    private AudioManager audioManager;

    private void Awake()
    {
        
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        print("yeah");
        audioManager.Stop("menu");
        audioManager.Play("game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
