using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class FlipSpriteOnMovement : MonoBehaviour
{
    public AIPath path;
    
    private SpriteRenderer _sprite;
    
    private void Start()
    {
        _sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (path.desiredVelocity.x < 0.01f)
        {
            _sprite.flipX = false;
        } 
        else if (path.desiredVelocity.x > 0.01f)
        {
            _sprite.flipX = true;
        }
    }
}
