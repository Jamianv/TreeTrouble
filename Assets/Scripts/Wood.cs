using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour {

    public AudioClip pickUpSound;
    private AudioSource source;
    [SerializeField]
    private float volLowRange = .5f;
    [SerializeField]
    private float volHighRange = 1f;
    private int amount;

	// Use this for initialization
	void Start () {
        amount = Random.Range(10, 20);
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(pickUpSound, vol);
            Destroy(gameObject);
            collision.gameObject.SendMessage("AddWood", amount);

        }
    }
}
