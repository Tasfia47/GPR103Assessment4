using UnityEngine;
using UnityEngine.SceneManagement;


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

  


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        else if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.velocity = Vector2.up * 10;
            rb.MovePosition(rb.position + rb.velocity);
            
        }
           

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Car")
        {
            Debug.Log("WE LOST!");
            Score.CurrentScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }   
 
       if(col.tag == "Log")
        this.transform.parent = col.transform;
    }

    void OnTriggerExit2D(Collider2D col)
    {
       if (col.tag == "Log")
            this.transform.parent = null;
    }
}
