using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpSpeed = 5.0f;
    
    private Rigidbody2D _rigidbody2D;
    private bool isOnGround;

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
        Debug.Log(position);
        
        float deltaX = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float deltaY = 0;
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            deltaY = jumpSpeed;
        }
        position = new Vector2(position.x + deltaX, position.y);
        _rigidbody2D.position = position;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y + deltaY);
    }
}
