using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private CharacterCollisions moveScript;

	// Use this for initialization
	void Awake () {
        moveScript = GetComponent<CharacterCollisions>();
	}
	
	// Update is called once per frame
	void Update () {
        /* Player Input */
        // Retrieve axis information from keyboard
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        moveScript.Move(inputX, inputY);
    }
}
