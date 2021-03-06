using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    public Sprite wizardWithAss;
    public Sprite wizardWithSmile;
    public Sprite wizardStandard;

    public SpriteRenderer renderer;
    public Rigidbody2D entity;
    //----------------------------------------
    public Vector2 previousDirection;
    public float speed;
    //----------------------------------------
    public bool dashing;
    public bool stunned;
    //----------------------------------------
    public bool updated;

    public string keyUp = "player1_move_up";
    public string keyDown = "player1_move_down";
    public string keyRight = "player1_move_right";
    public string keyLeft = "player1_move_left";
    
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        entity = GetComponent<Rigidbody2D>();
        previousDirection = new Vector2(-1, 0);
    }

    void Update()
    {
        if (!dashing)
            StartCoroutine(Move());
    }

    public Vector2 GetPosition()
    {
        return entity.transform.position;
    }

    public void SetPosition(Vector2 position)
    {
        entity.transform.position = position;
    }

    public Vector2 GetNormalizedDirection()
    {
        return previousDirection;
    }

    public void SetVelocity(Vector2 velocity)
    {
        entity.velocity = velocity;
    }

    private Vector2 DetermineDirection()
    {
        Vector2 currentDirection = new Vector2(0, 0);
        
        // Movement along X-Axis
        if (Input.GetKey(KeyBindings.GetKeyBinding(keyLeft)))
        {
            currentDirection.x = -1;
            updated = true;

            renderer.flipX = false;
            renderer.sprite = wizardStandard;
        }
        else if (Input.GetKey(KeyBindings.GetKeyBinding(keyRight)))
        {
            currentDirection.x = 1;
            updated = true;

            renderer.flipX = true;
            renderer.sprite = wizardStandard;
        }

        // Movement along Y-Axis
        if (Input.GetKey(KeyBindings.GetKeyBinding(keyUp)))
        {
            currentDirection.y = 1;
            updated = true;

            renderer.sprite = wizardWithAss;
        }
        else if (Input.GetKey(KeyBindings.GetKeyBinding(keyDown)))
        {
            currentDirection.y = -1;
            updated = true;

            renderer.sprite = wizardWithSmile;
        }

        return currentDirection;
    }

    IEnumerator Move()
    {
        Vector2 currentDirection = DetermineDirection();

        // The wizard has been allowed to change looking direction
        // but must not move itself
        if (stunned)
            yield break;

        // Move entity in currentDirection
        SetVelocity(currentDirection * speed);

        // If no directional change has been suggested,
        // the previous direction shall not be overwritten
        if (!updated)
            yield break;

        // Update previous direction if current direction
        // points somewhere and hence indicates directional
        // changes
        currentDirection.Normalize();
        previousDirection = currentDirection;
        updated = false;
    }

}