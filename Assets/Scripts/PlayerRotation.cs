using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    private Vector3 mousePos;
    private Vector3 playerPos;
    private float angle;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {

        mousePos = Input.mousePosition;
        playerPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        mousePos.x = mousePos.x - playerPos.x;
        mousePos.y = mousePos.y - playerPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //Quaternion deltarotation =  Quaternion.Euler(new Vector3(0, 0, angle - 90));
        //rb.AddTorque(rb.rotation * deltarotation);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
