using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{

    [SerializeField] private GameObject fire;
    [SerializeField] private Camera camera;
    private GameObject _fire;
    private CameraController _cameraController;
    
    // Update is called once per frame

    void Start()
    {
        _cameraController = camera.GetComponent<CameraController>();
        _cameraController.SetFollowing(this.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_fire == null)
                _fire = Instantiate(fire);
            _fire.transform.position = transform.position;
            _cameraController.SetFollowing(_fire);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (_fire != null)
                Destroy(_fire.gameObject);
            _cameraController.SetFollowing(this.gameObject);
        }
    }
}
