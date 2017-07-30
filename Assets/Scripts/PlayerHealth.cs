using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private Stat health;
    private bool dead = false;

    public Stat Health
    {
        get
        {
            return health;
        }
    }

    // Use this for initialization
    void Start () {
        health.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        if (health.CurrentVal <= 0) {
            if (!dead) {
                death();
                dead = true;
            }
            if (dead) {
                health.CurrentVal = health.MaxVal;
                dead = false;
            }
        }
	}

    void ApplyDamage(int damage) {
        health.CurrentVal -= damage;
    }

    void death() {
        SceneManager.LoadScene("DeathScreen");
    }
}
