//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// This script must be utilised as the core component on the 'vehicle' obstacle in the frogger game.
/// </summary>
public class Vehicle : MonoBehaviour
{
    /// <summary>
    /// -1 = left, 1 = right
    /// </summary>
    public Rigidbody2D rb;
    public int moveDirection = 0; //this variable is used to indicate the direction of the veichle is moving in.
    public float speed;//This variable is used to control the seed of the vehicle.
    public float minSpeed = 8f;
    public float maxSpeed = 12f;
   
    public Vector2 startingPosition;//This variable is to be used to indicate where on the map the vehicle starts(or spawn).
    public Vector2 endPosition;//This variable is to be used to indicate  the final destination of the vehicle.


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }
}
