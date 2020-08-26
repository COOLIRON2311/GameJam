using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Interactable
{
    private bool isMoving;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    private Rigidbody2D _rigidbody2D;
    private Vector2 movement;
    
    public float speed = 1.0f;
    
    void Start()
    {
        //transform.position = start.position;
        isMoving = false;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        movement = new Vector2(end.position.x - start.position.x, end.position.y - start.position.y);
        movement *= speed * Time.deltaTime;
    }
    public override bool Activate(GameObject player)
    {
        Lever lever = player.GetComponent<Lever>();
        if (lever)
        {
            isMoving = !isMoving;
        }

        return (lever != null);
    }

    public void ChangeDirection()
    {
        movement = -movement;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector2 pos = _rigidbody2D.position;
            _rigidbody2D.MovePosition(pos + movement);
        }
    }
}
