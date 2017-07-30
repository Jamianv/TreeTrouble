using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private GameObject target;
    private Transform targetTransform;
    public int moveSpeed;
    public int rotationSpeed;
    private Rigidbody2D rb2d;
    private float angle;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        targetTransform = target.transform;
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null) {
            Vector3 dir = targetTransform.position - transform.position;
            dir.z = 0.0f;
            if (dir != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            transform.position += (targetTransform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }
        rb2d.velocity = Vector3.zero;
	}

    
}
