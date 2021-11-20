using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public float cameraSpeed;
    void Update()
    {
        var targetPosition = target.transform.position;
        var position = gameObject.transform.position;
        var move = new Vector2(targetPosition.x-position.x,targetPosition.y-position.y); 
        GetComponent<Rigidbody2D>().velocity = move*cameraSpeed;
    }
}
