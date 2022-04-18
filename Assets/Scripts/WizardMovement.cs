using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    public Sprite wizardWithAss;
    public Sprite wizardWithSmile;
    public Sprite wizardStandard;

    public Rigidbody2D entity;
    public Vector2 direction;
    public float speed;

    void Start()
    {
        entity = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyBindings.GetKeyBinding("player1_move_left")))
        {
            dir.x = -1;
            GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wizardStandard;
        }
        else if (Input.GetKey(KeyBindings.GetKeyBinding("player1_move_right")))
        {
            dir.x = 1;
            GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wizardStandard;
        }

        if (Input.GetKey(KeyBindings.GetKeyBinding("player1_move_up")))
        {
            dir.y = 1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wizardWithAss;
        }
        else if (Input.GetKey(KeyBindings.GetKeyBinding("player1_move_down")))
        {
            dir.y = -1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wizardWithSmile;
        }

        dir.Normalize();
        entity.velocity = speed * dir;

        if (dir.magnitude != 0)
            direction = dir;
    }

}