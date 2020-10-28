using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        /* This function is used for movement of player. 
         * If you press Arrow Key, the player will move.*/

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * moveSpeed;
        float ySpeed = yInput * moveSpeed;

        Vector3 newVelocity = new Vector3(xSpeed, ySpeed, 0f);
        playerRigidbody.velocity = newVelocity;
        
    }
}
