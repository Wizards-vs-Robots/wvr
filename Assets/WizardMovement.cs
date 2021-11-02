using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float axisRawX = Input.GetAxisRaw("Horizontal");
        float axisRawY = Input.GetAxisRaw("Vertical");
   
        gameObject.transform.position = new Vector2 (transform.position.x + (axisRawX * speed*Time.deltaTime), 
            transform.position.y + (axisRawY * speed*Time.deltaTime));  
    }
}
