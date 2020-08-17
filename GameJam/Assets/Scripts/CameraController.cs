using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float z;
    
    private GameObject following;

    private Camera _camera;
    //private Rigidbody2D _rigidbody2D;

    public bool isFree;
    public float moveSpeed = 0.1f;
    
    //camera borders
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;
    [SerializeField] private Transform upBorder;
    [SerializeField] private Transform downBorder;

    private void Start()
    {
        //_rigidbody2D = GetComponent<Rigidbody2D>();
        _camera = GetComponent<Camera>();
        isFree = false;
        z = transform.position.z;
    }

    private bool IsInBorder(Vector2 pos, float width, float height)
    {
        float halfwidth = width; // 2;
        float halfheight = height; // 2;
        if (pos.x - halfwidth <= leftBorder.position.x)
            return false;
        if (pos.x + halfwidth >= rightBorder.position.x)
            return false;
        if (pos.y - halfheight <= downBorder.position.y)
            return false;
        if (pos.y + halfheight >= upBorder.position.y)
            return false;
        return true;
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

            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            Vector2 delta = new Vector2(deltaX, deltaY);
            float k = 0.005f;
            if (IsInBorder(pos + delta, _camera.pixelWidth * k, _camera.pixelHeight * k))
            {
                Debug.Log("true");
                transform.Translate(deltaX, deltaY, 0);
            }
            else
            {
                Debug.Log("false");
            }



            /*if (isInBorder)
            {
                _rigidbody2D.velocity = new Vector2(deltaX, deltaY);    
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.position = _rigidbody2D.position - 
                                        new Vector2(deltaX, deltaY);
                isInBorder = true;
            }*/
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
