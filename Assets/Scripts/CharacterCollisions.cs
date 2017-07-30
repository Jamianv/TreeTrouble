using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisions : MonoBehaviour {

    // Speed of object
    [Range(0, 1000)]
    public float speed = 400;

    // Direction of object
    internal Vector2 direction = new Vector2(0, 0);
    internal Vector2 facing = new Vector2(0, 0);

    // Actual movement
    internal Vector2 movement = new Vector2(0, 0);
    private bool isMoving = false;

    private Rigidbody2D rb2d;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (rb2d.velocity.normalized.x != 0 || rb2d.velocity.normalized.y != 0)
        {
            // Store the direction the player is facing in case they stop moving
            facing = rb2d.velocity.normalized;
            isMoving = true;
        }

        movement = direction * speed;
    }

    void FixedUpdate()
    {
        // Apply the movement to the rigidbody
        rb2d.AddForce(movement);
        //transform.position += (Vector3)movement;
    }

    /* Moves the object in a direction by a small amount (used for player input)
	 	float input_X: Input for X-axis movement (b/t -1 and 1)
	 	float input_Y: Input for Y-axis movement (b/t -1 and 1)
	 */
    internal void Move(float input_X, float input_Y)
    {
        direction = new Vector2(input_X, input_Y);
    }

}
