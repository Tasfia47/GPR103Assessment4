using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
//using System.Media;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is to be attached to a game object called GameManager in the scene. Its is to be used to manager the settings.
/// </summary>
public class GameManager : MonoBehaviour
{
   
    [Header("Scoring")]
    public int currentScore = 0;//The current score is the round.
    public int highScore = 0;//The highest score acheived either in the session or over the lifetime of the game.

    [Header("Playable Area")]//edges of the map
    public float levelConstraintTop;//The maximum positive Y value of the playable space.
    public float levelConstraintBottom;//The maximum negative Y value of the playable space.
    public float levelConstraintLeft;//The maximum negative X value of the playable space.
    public float levelConstraintRight;//The maximum positive X value of the playable space.


    [Header("Gameplay Loop")]
    public bool isGameRunning;//is the gameplay part of the game current active?
    public float totalGameTime;//The maximum amount of time or the total time avialable to the player.
    public float gameTimeRemaining;//The current elapsed time
    public float gameTimer;
   



    // Start is called before the first frame update
    void Start()
    {
        totalGameTime = 60f;
        print("totalGameTime" + totalGameTime);
        //gameTimer += Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
       
        //if is game running; we care about frog
        if (isGameRunning == true)
        {
              gameTimer += Time.deltaTime;
            if(gameTimer < totalGameTime)
            {
                gameTimeRemaining = totalGameTime - gameTimer;
                print("gameTimeRemaining" + gameTimeRemaining);
            }
            else if(gameTimer >= totalGameTime)
            {
                gameTimer = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }



        }
       else
            //Application.Quit();
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

}
