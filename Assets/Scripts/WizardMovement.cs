using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    public float speed;
    public Sprite WizardWithAss;
    public Sprite WizardWithSmile;

    public Sprite WizardStandard;

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = WizardStandard;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = WizardStandard;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = WizardWithAss;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = WizardWithSmile;
        }

        dir.Normalize();

        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}