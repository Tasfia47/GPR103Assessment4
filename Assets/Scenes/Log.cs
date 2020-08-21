using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Log : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public bool moveRight = true;

    private readonly float playAreaWidth = 120.0f;

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.localPosition;
        if (moveRight)
        {
            pos.x += moveSpeed * Time.deltaTime;
            if(pos.x >=((playAreaWidth/2)-1) + (playAreaWidth - 1) - GetComponent<SpriteRenderer>().size.x / 2)
            {
                pos.x = -playAreaWidth / 2 - GetComponent<SpriteRenderer>().size.x / 2;
            }
        }
        else
        {
            pos.x -= moveSpeed * Time.deltaTime;
            if (pos.x >= ((-playAreaWidth / 2) - 1) - (playAreaWidth - 1) - GetComponent<SpriteRenderer>().size.x / 2)
            {
                pos.x = playAreaWidth / 2 + GetComponent<SpriteRenderer>().size.x / 2;
            }
        }
        transform.localPosition = pos;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
            this.transform.parent = null;
    }
}
