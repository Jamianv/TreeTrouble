using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPower : MonoBehaviour {
    [SerializeField]
    private Stat power;
    private bool empty = false;

    public Stat Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }

    void Awake() {
        power.Initialize();
    }

    
    void tankAmount(int tank) {
        power.CurrentVal = tank;
    }

    //void DecreasePower(int decrease) {
        //power.CurrentVal -= decrease;
    //}
}
