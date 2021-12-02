using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float m_fallTime = 1;
    public float inclreaseLevelTimer = 10;
    
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
        Invoke("IncreaseDifficulty", inclreaseLevelTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    private void IncreaseDifficulty()
    {
        print(m_fallTime);
        if (m_fallTime >= .1f)
        {
            m_fallTime -= 0.01f;
        }

        if (inclreaseLevelTimer >= 3f)
        {
            inclreaseLevelTimer *= .99f;
        }

        Invoke("IncreaseDifficulty", inclreaseLevelTimer);
    } // IncreaseDifficulty
}
