using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLoop : MonoBehaviour
{
    private Rigidbody2D rb;

    private void OnTriggerExit2D(Collider2D other)
    {
        var lli = other.GetComponent<LightLoopInteracor>();
        if (lli != null)
        {
            Debug.Log("Trigger Exit");
            //Destroy(other.gameObject);   
        }
    }
}
