using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWood : MonoBehaviour {

    public AudioClip dropOffSound;
    private AudioSource source;
    [SerializeField]
    private float volLowRange = .01f;
    [SerializeField]
    private float volHighRange = .1f;

    public int wood;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddWood(int newWood) {
        wood += newWood;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Generator") {
            if(wood!= 0) { 
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(dropOffSound, vol);
            }
            collision.gameObject.SendMessage("FillTank", wood);
            wood = 0;        
        }
    }
    
}
