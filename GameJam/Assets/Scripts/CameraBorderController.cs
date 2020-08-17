using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorderController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"{other} trigger exit");
        CameraController cameraController = other.GetComponent<CameraController>();
        if (cameraController != null)
        {
            cameraController.isInBorder = false;
        }
    }
}
