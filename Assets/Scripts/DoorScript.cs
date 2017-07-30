using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    private BoxCollider2D[] colliders;

	// Use this for initialization
	void Start () {
        colliders = GetComponents<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void openDoors(bool open) {
        if (open)
        {
            for (int i = 0; i < 3; i++) {
                colliders[i].enabled = false;
            }
        }
        if (!open)
        {
            for (int i = 0; i < 3; i++)
            {
                colliders[i].enabled = true;
            }
        }
    }
}
