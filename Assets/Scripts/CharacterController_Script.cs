using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_Script : MonoBehaviour {

    float vertical, horizontal;

    
    public float speed = 3;

    private Vector3 currentDirection = Vector3.zero;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void GetInput() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

	// Update is called once per frame
	void Update () {
        GetInput();
        Move();
    }

    void FixedUpdate() {
        
        
    }

    void Move() {
        //control.Move(new Vector3(horizontal, vertical, 0.0f));
        if (currentDirection.Equals(Vector3.zero))
        {
            Vector3 inputDirection = new Vector3(horizontal, +vertical, 0.0f);
            if (!(inputDirection.Equals(Vector3.zero)))
            {

                //currentDirection = inputDirection;
                //rb2d.AddForce(currentDirection * speed);
                transform.position += inputDirection * speed * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //currentDirection = Vector3.zero;
        //rb2d.velocity = Vector3.zero;
       // transform.position = Vector3.zero;

    }
}
