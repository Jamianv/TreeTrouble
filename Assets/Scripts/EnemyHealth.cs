using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField]
    private int health = 50;
    private Rigidbody2D rb2d;
    public GameObject woodPrefab;
    private bool isCreated = false;
    private bool empty = false;

    //Sound
    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .1f;
    private float volHighRange = .2f;


    public int Health
    {
        get
        {
            return health;
        }
    }

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            rb2d.velocity = Vector2.zero;
            Destroy(gameObject, .4f);
            if (!isCreated)
            {
                Instantiate(woodPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
            isCreated = true;
        }
	}

    private void applyDamage(int damage) {
        //play bullet sound
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(shootSound, vol);
        health -= damage;
    }
}
