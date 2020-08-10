using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float z;
    
    private GameObject following;

    private void Start()
    {
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(following.transform.position.x, following.transform.position.y, z);
    }

    public void SetFollowing(GameObject gameObject)
    {
        following = gameObject;
    }
}
