using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
    [SerializeField]
    public float tank = 100;
    [SerializeField]
    private float incrementTime = 1f;
    [SerializeField]
    private float incrementBy = 2;
    private double time = 0;
    private bool empty = false;
    public GameObject lightPrefab;
    private GameObject child;

    [SerializeField]
    private AudioClip powerDown;
    public AudioClip music;
    private AudioSource source;
    

    void Start () {
        child = GameObject.FindGameObjectWithTag("SuperMarket");
        source = GetComponent<AudioSource>();
        
        source.Play();
    }

    
    void Update() {
        if (!empty) {
            EmptyTank();
        }
        if (tank <= 0)
        {

            //yield return new WaitForSeconds(source.clip.length);
            //source.clip = music;
            //source.PlayOneShot(powerDown);
            source.Stop();
            
            child.gameObject.SendMessage("PowerOn", false);
            empty = true;
            /*if (transform.GetChild(0).gameObject != null)
            {
                Destroy(transform.GetChild(0).gameObject);
            }*/
        }
	}
  

    void EmptyTank() {
        time += Time.deltaTime;
        while (time > incrementTime) {
            time -= incrementTime;
            tank -= incrementBy;
            gameObject.SendMessage("tankAmount", tank);
        }
    }
    void FillTank(int wood) {
        if (empty)
        {   
            source.Play();
            //GameObject newLight = Instantiate(lightPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //newLight.transform.parent = gameObject.transform;
            //spriteRender.sprite = lite;
            child.gameObject.SendMessage("PowerOn", true);
            empty = false;
        }
        tank += wood;
        if (tank > 100)
            tank = 100;
        gameObject.SendMessage("tankAmount", tank);
    }

}
