﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class PhantomRoomController : MonoBehaviour
{
    [SerializeField] private LightLoop _lightLoop;
    [SerializeField] private GameObject FakeClone;

    private void SetRelativePosition(GameObject clone, Collider2D other)
    {
        //TODO: looks like shit OMG
        Vector2 _playerPosition = other.transform.position;
        Vector2 delta = new Vector2(_playerPosition.x - transform.position.x, _playerPosition.y - transform.position.y);
        Transform llTransform = _lightLoop.transform;
        Vector2 position = new Vector2(llTransform.position.x + delta.x, llTransform.position.y + delta.y);
        clone.transform.position = position;
    }

    private bool PreventCloneCollision(Collider2D other)
    {
        Collider2D[] colList = Physics2D.OverlapCircleAll(FakeClone.transform.position, 0.01f);
        if (colList.Any(x => x.gameObject.layer == 8))
        {
            BoxCollider2D[] roomColliders = GetComponents<BoxCollider2D>();
            foreach (var coll in roomColliders)
            {
                if (!coll.isTrigger)
                {
                    coll.enabled = true;
                }
            }
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        LightLoopInteracor lli = other.GetComponent<LightLoopInteracor>();
        if (lli != null && rb != null)
        {
            Debug.Log("Trigger enter");
            SpriteRenderer _playerRenderer = other.GetComponent<SpriteRenderer>();
            if (FakeClone == null)
            {
                FakeClone = new GameObject("FakeClone");
                FakeClone.AddComponent<SpriteRenderer>();
                SpriteRenderer _fakeRenderer = FakeClone.GetComponent<SpriteRenderer>();
                _fakeRenderer.sprite = _playerRenderer.sprite;
                _fakeRenderer.maskInteraction = _playerRenderer.maskInteraction;
                _fakeRenderer.sortingLayerName = _playerRenderer.sortingLayerName; //Sorting layer for light and such stuff
            }

            PreventCloneCollision(other);
            //SetRelativePosition(FakeClone, other);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (FakeClone)
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (PreventCloneCollision(other))
            {
                
            }
            else
            {
                SetRelativePosition(FakeClone, other);
                if (rb != null)
                {
                    Vector2 _roomPosition = transform.position;
                    //If player got too far into imaginary room, we swap the clone with real character
                    if (Vector2.Distance(rb.position, _roomPosition)
                        < Vector2.Distance(rb.position, _lightLoop.transform.position))
                    {
                        Vector2 _playerPos = rb.position;
                        rb.position = FakeClone.transform.position;
                        FakeClone.transform.position = _playerPos;
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (FakeClone)
        {
            Destroy(FakeClone);
            FakeClone = null;
        }
        BoxCollider2D[] roomColliders = GetComponents<BoxCollider2D>();
        foreach (var coll in roomColliders)
        {
            if (!coll.isTrigger)
            {
                coll.enabled = false;
            }
        }
    }
}
