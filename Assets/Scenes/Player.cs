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

    private GameManager myGameManager;// A reference to the GameManager in the scene.

    public Rigidbody2D rb;//asigning rigid body
    float dirX, moveSpeed = 5f;

    private HUD hud;
   private Goal goal;

    // Start is called before the first frame update
    void Start()

    {  playerTotalLives = 4;
        print(playerTotalLives); 
      playerLivesRemaining = playerTotalLives;
        print(playerLivesRemaining);
        rb = GetComponent<Rigidbody2D>();

        hud = GameObject.Find("Canvas").GetComponent<HUD>();
        goal = GameObject.Find("Home").GetComponent<Goal>();
        myGameManager = GameObject.Find("Frog").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
        //set keys to -1 and 1
        if (Input.GetKeyDown(KeyCode.RightArrow))
            rb.MovePosition(rb.position + Vector2.right);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            rb.MovePosition(rb.position + Vector2.left);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            rb.MovePosition(rb.position + Vector2.up);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            rb.MovePosition(rb.position + Vector2.down);
       else if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * 10f;
            rb.MovePosition(rb.position + rb.velocity);
        }
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
       
           

    }
    void fixedUpdate ()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
       // rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
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
                if (playerLivesRemaining == 0)
                {
                    PlayerDied();
                   
                } 
            }
            if (col.tag == "River")
            {
                Debug.Log("WE LOST!");
                Score.CurrentScore = 0;
                playerLivesRemaining -= 1;
                if (playerLivesRemaining == 3)
                {
                    PlayerDied();

                }
            }
            if (col.tag == "Goals")
            { 
               goal.ShowFrog(true);
                Debug.Log("YOU WON!");
                Score.CurrentScore += 100;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (col.tag == "Log")
             this.transform.parent = col.transform;
        }
        else
            playerIsAlive = false;
        if(playerIsAlive != true)
        {
            resetPosition();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        void PlayerDied()
        {
           // playerLivesRemaining -= 1;
           // hud.UpdatePlayerLivesHUD(playerLivesRemaining);
            resetPosition();

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
        if(col.tag == "Log")
            this.transform.parent = null;
    }

   
}
