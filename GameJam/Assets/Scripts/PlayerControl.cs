using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpSpeed = 25.0f;
    public bool isOnLadder;
    //SORRY
    public bool isOnGround;

    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform groundCheckR;
    [SerializeField] private Transform groundCheckL;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1<<LayerMask.NameToLayer("Ground"))
            || Physics2D.Linecast(transform.position, groundCheckR.position, 1<<LayerMask.NameToLayer("Ground"))
            || Physics2D.Linecast(transform.position, groundCheckL.position, 1<<LayerMask.NameToLayer("Ground")))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }

        

        Vector2 position = _rigidbody2D.position;
        //Debug.Log(position);
        
        //float deltaX = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float velosityX = _rigidbody2D.velocity.x;
        float velosityY = _rigidbody2D.velocity.y;
        if (isOnLadder)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                velosityY = speed;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                velosityY = -speed;
            }

        }
       
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            velosityX = speed;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            velosityX = -speed;
        }
        
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            velosityY = jumpSpeed;
        }

        
        //Debug.Log(velosityX);
        //position = new Vector2(position.x + deltaX, position.y);
        //_rigidbody2D.position = position;
        _rigidbody2D.velocity = new Vector2(velosityX, velosityY);
    }
}
