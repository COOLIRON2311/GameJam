using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLimiter : MonoBehaviour
{
    private MovingPlatform _movingPlatform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _movingPlatform = other.GetComponent<MovingPlatform>();
        if (_movingPlatform)
        {
            _movingPlatform.ChangeDirection();
        }
    }
}
