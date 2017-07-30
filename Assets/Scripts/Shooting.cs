using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    private Vector2 direction;
    private Vector3 worldMousePos;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float speed = 2;
    private bool canShoot = true;
    [SerializeField]
    private float shootRate = 0.2f;
    // Use this for initialization

    //Sound
    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = 0.2f;
    private float volHighRange = 0.4f;
    void Awake () {
        source = GetComponent<AudioSource>();
    }
    void GetInput() {
        
    }
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            //play bullet sound
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(shootSound, vol);
            GetMouseDirection();
            //find bullet rotation
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, direction);
            //instantiate bullet with found rotation
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, rotation);
            //add velocity to bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
            canShoot = false;
            Invoke("ShootRate", shootRate);
        }
    }
    
    void ShootRate()
    {
        canShoot = true;
    }

    private void GetMouseDirection() {
        worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (Vector2)(worldMousePos - transform.position);
        direction.Normalize();
    }
}
