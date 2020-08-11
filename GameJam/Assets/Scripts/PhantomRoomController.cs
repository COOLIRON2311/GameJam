using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomRoomController : MonoBehaviour
{
    [SerializeField] private LightLoop _lightLoop;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        LightLoopInteracor lli = other.GetComponent<LightLoopInteracor>();
        if (lli != null && rb != null)
        {
            Debug.Log("Trigger enter");
            //GameObject clone = Instantiate(other.gameObject);
            //rb = clone.GetComponent<Rigidbody2D>();
            Vector2 possition = other.transform.position;
            Vector2 delta = new Vector2(possition.x - transform.position.x, possition.y - transform.position.y);
            Transform llTransform = _lightLoop.transform;
            Vector2 position = new Vector2( llTransform.position.x + delta.x, llTransform.position.y + delta.y);
            rb.position = position;    
        }
    }
}
