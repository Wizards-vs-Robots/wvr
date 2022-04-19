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
    
    public Vector2 direction;
    public float speed;

    public Vector2 dash;
    public bool dashing;

    public bool updated;
    public bool blocked;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        entity = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!blocked)
            StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Vector2 direction = new Vector2(0, 0);
        
        if (dashing)
        {
            direction = this.direction * 10F;
            blocked = true;
            updated = true;
        }
        else
        {
            // Movement along X-Axis
            if (Input.GetKey(KeyBindings.GetKeyBinding("player1_move_left")))
            {
                direction.x = -1;
                updated = true;

                renderer.flipX = false;
                renderer.sprite = wizardStandard;
            }
            else if (Input.GetKey(KeyBindings.GetKeyBinding("player1_move_right")))
            {
                direction.x = 1;
                updated = true;

                renderer.flipX = true;
                renderer.sprite = wizardStandard;
            }

            // Movement along Y-Axis
            if (Input.GetKey(KeyBindings.GetKeyBinding("player1_move_up")))
            {
                direction.y = 1;
                updated = true;

                renderer.sprite = wizardWithAss;
            }
            else if (Input.GetKey(KeyBindings.GetKeyBinding("player1_move_down")))
            {
                direction.y = -1;
                updated = true;

                renderer.sprite = wizardWithSmile;
            }

            // Normalize movement vector
            direction.Normalize();

            // Store normalized direction vector
            this.direction = direction;

            // Bring entity up to speed
            direction *= speed;
        }

        // Only if any update exists, the entity is moved.
        if (!updated)
            yield return null;

        // Apply movement vector
        entity.velocity = direction;

        // Wait if dashing
        if (dashing)
        {
            yield return new WaitForSeconds(1);
            blocked = false;
            dashing = false;
        }

        updated = false;
    }

}