using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private Rigidbody2D rb2d;
    [SerializeField]
    private int damage = 10;
    //Sound
    public AudioClip impactSound;
    private AudioSource source;
    [SerializeField]
	private float volLowRange = .01f;
    [SerializeField]
    private float volHighRange = .1f;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Explode();
            collision.gameObject.SendMessage("applyDamage", damage);
        }
        if(collision.gameObject.tag == "SuperMarket")
        {
            Explode();
        }
        if (collision.gameObject.tag == "Default")
        {
            Explode();
        }
    }

    private void Explode() {
        rb2d.velocity = Vector2.zero;
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(impactSound, vol);
        Destroy(this.gameObject);
    }
}
