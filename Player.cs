﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script must be used as the core player script for managing the player charecter is the game.
/// </summary>
/// 
public class Player : MonoBehaviour
{
    public string playerName = "";// The players name for the purpose of  storing the high score

    public int playerTotalLives;//Players total possible lives.
    public int playerLivesRemaining;//Players actual lives remaining

    public bool playerIsAlive = true;//Is the player currently alive?
    public bool playerCanMove = false;//Can the player currently move?

    private GameManager myGameManager;// A reference to the GameManager in the scene.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
