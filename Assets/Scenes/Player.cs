using System.Collections.Specialized;
using System.Security.AccessControl;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Diagnostics;

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

    public bool moveRight = true;
    private GameManager myGameManager;// A reference to the GameManager in the scene.
    public Rigidbody2D rb;//asigning rigid body
   
    private HUD hud;
   // private Goal goal;

    // Start is called before the first frame update
    void Start()
    { 
        playerTotalLives = 4;
        print("player Total Lives" + playerTotalLives); 
        playerLivesRemaining = playerTotalLives;
        print("player Lives Remaining" + playerLivesRemaining);

        rb = GetComponent<Rigidbody2D>();

        hud = GameObject.Find("Canvas").GetComponent<HUD>();

      //  goal = GameObject.Find("Home").GetComponent<Goal>();

        myGameManager = GameObject.Find("Frog").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerName = "Tasfia";
        print("Player name" + playerName);

        //set keys to -1 and 1
        if (Input.GetKeyDown(KeyCode.RightArrow))
            rb.MovePosition(rb.position + Vector2.right);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            rb.MovePosition(rb.position + Vector2.left);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            rb.MovePosition(rb.position + Vector2.up);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            rb.MovePosition(rb.position + Vector2.down);
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.MovePosition(rb.position + (Vector2.up * 5));
            moveRight = false;
        }     

    }
   

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (playerIsAlive == true)
        {
              hud.UpdatePlayerLivesHUD(playerLivesRemaining);
            // vector2.pos = transform.localPosition;
            if (col.tag == "Car")
            {
                Debug.Log("YOU GOT HIT BY A CAR");
                Score.CurrentScore = 0;
                playerLivesRemaining -= 1;
                if (playerLivesRemaining == 3)
                {
                    hud.UpdatePlayerLivesHUD(playerLivesRemaining);
                    resetPosition();
                }
            }

            if (col.tag == "Walls")
            {
                Debug.Log("You Hit The Wall");
                Score.CurrentScore = 0;  
            }

            if (col.tag == "River")
            {
                Debug.Log("WE LOST!");
                Score.CurrentScore = 0;
                playerLivesRemaining -= 1;
                if (playerLivesRemaining == 0)
                {
                    hud.UpdatePlayerLivesHUD(playerLivesRemaining);
                    resetPosition();
                }
            }

            if (col.tag == "Goals")
            {
               // Destroy(goal);
                Debug.Log("YOU WON!");
                Score.CurrentScore += 100;
                resetPosition();
            }

            if (col.tag == "Log")
            {
                this.transform.parent = col.transform;

            }

             if(col.tag == "Finish")
            {
                resetPosition();
            }
        }
        else
            playerIsAlive = false;

        if(playerIsAlive != true)
        {
            resetPosition();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
        void resetPosition()
        {
            playerTotalLives = 4;
            playerLivesRemaining = playerTotalLives;
            hud.UpdatePlayerLivesHUD(playerLivesRemaining);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    { 
            if (col.tag == "Log")
             moveRight = false;
            this.transform.parent = null;
            // playerCanMove = true;
    }
       

   
}
