using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{

    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject Player;
    [SerializeField] private Camera _camera;
    private GameObject _fire;
    private CameraController _cameraController;
    
    // Update is called once per frame

    void Start()
    {
        _cameraController = _camera.GetComponent<CameraController>();
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

            //Set sprite visible only inside the mask (the mask itself is in the fire prefab)
            SpriteRenderer _playerRenderer = Player.GetComponent<SpriteRenderer>();
            _playerRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (_fire != null)
                Destroy(_fire.gameObject);
            _cameraController.SetFollowing(this.gameObject);

            //Mask reversal
            //TO REVIEW: overall approach sucks, screen border should mask the sprite by itself 
            SpriteRenderer _playerRenderer = Player.GetComponent<SpriteRenderer>();
            _playerRenderer.maskInteraction = SpriteMaskInteraction.None;
        }
    }
}
