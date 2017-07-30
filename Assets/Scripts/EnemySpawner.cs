using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private bool canSpawn = true;
    [SerializeField]
    private GameObject enemyPrefab;
    public float spawnRate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canSpawn)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            canSpawn = false;
            Invoke("SpawnRate", spawnRate);
        }
	}

    void SpawnRate() {
        canSpawn = true;
    }
}
