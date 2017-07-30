using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SuperMarket : MonoBehaviour {

    public Sprite dark;
    public Sprite lite;
    private SpriteRenderer spriteRender;
    private GameObject doors;
    [SerializeField]
    private AudioClip powerDown;
    [SerializeField]
    private AudioClip powerOn;
    private AudioSource source;
    private bool played = false;

    // Use this for initialization
    void Start () {
        doors = GameObject.FindGameObjectWithTag("Doors");
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
     
    }

    void PowerOn(bool on) {
        if (on) {
            if (spriteRender != null)
            {
                if (played) { 
                    source.PlayOneShot(powerOn);
                }
                doors.gameObject.SendMessage("openDoors", false);
                spriteRender.sprite = lite;
                played = false;
            }
        }
        if (!on)
        {
            if (spriteRender != null)
            {
                if (!played)
                {
                    source.PlayOneShot(powerDown);
                }
                played = true;
                doors.gameObject.SendMessage("openDoors", true);
                spriteRender.sprite = dark;
            }
        }
    }
}
