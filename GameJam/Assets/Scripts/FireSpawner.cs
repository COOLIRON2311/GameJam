using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FireSpawner : MonoBehaviour
{

    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject Player;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject handFire;
    [SerializeField] private GameObject unlitFire;
    [SerializeField] private Light2D handFireLight;
    private GameObject _fire;
    private CameraController _cameraController;
    private bool _hasFire;
    private bool _isFireOnGround;
    
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
            if (_hasFire)
            {
                PlayerControl pc = GetComponent<PlayerControl>();
                if (pc.isOnGround)
                {
                    if (_fire == null)
                    {
                        _fire = Instantiate(fire);
                    }
                    handFire.GetComponent<SpriteRenderer>().enabled = false;
                    _fire.transform.position = transform.position;
                    _cameraController.SetFollowing(_fire);
                    _hasFire = false;
                    _isFireOnGround = true;
                    //Set sprite visible only inside the mask (the mask itself is in the fire prefab)
                    SpriteRenderer _playerRenderer = Player.GetComponent<SpriteRenderer>();
                    _playerRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    //Light
                    handFireLight.enabled = false;
                }
            }
            else if (!_isFireOnGround)
            {
                var fireObjects = GameObject.FindGameObjectsWithTag("Unlit Fire");

                foreach (GameObject fireObject in fireObjects)
                {
                    if (Vector2.Distance(transform.position, fireObject.transform.position) < 0.7)
                    {
                        Destroy(fireObject);
                        if (handFire)
                        {
                            handFire.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        _hasFire = true;
                        break;
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && _isFireOnGround)
        {
            if (_fire != null)
            {
                GameObject _unlitFire = Instantiate(unlitFire);
                _unlitFire.transform.position = _fire.transform.position;
                Destroy(_fire.gameObject);
                _fire = null;
            }
            _cameraController.SetFollowing(this.gameObject);
            _isFireOnGround = false;

            //Mask reversal
            //TO REVIEW: overall approach sucks, screen border should mask the sprite by itself 
            SpriteRenderer _playerRenderer = Player.GetComponent<SpriteRenderer>();
            _playerRenderer.maskInteraction = SpriteMaskInteraction.None;
            
            //Light
            handFireLight.enabled = true;
        }
    }
}
