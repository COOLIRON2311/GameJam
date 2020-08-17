using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float z;
    
    private GameObject following;

    public bool isFree;
    public float moveSpeed = 0.1f;

    private void Start()
    {
        isFree = false;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFree)
        {
            float deltaX = 0;
            float deltaY = 0;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                deltaY = moveSpeed;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                deltaY = -moveSpeed;
            }
            
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                deltaX = moveSpeed;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                deltaX = -moveSpeed;
            }
            
            transform.Translate(deltaX, deltaY, 0);
        }
        else
        {
            transform.position = new Vector3(following.transform.position.x, following.transform.position.y, z);    
        }
    }

    public void SetFollowing(GameObject gameObject)
    {
        following = gameObject;
    }
}
