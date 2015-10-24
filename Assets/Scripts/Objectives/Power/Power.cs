using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {

    public bool powered = false;
    int powerLevel = 0;
    
	void Start () {
	
	}
	
	void Update () {
        powered = powerLevel > 0;
	}

    public void power(bool power)
    {
        if (power)
            powerLevel++;
        else
            powerLevel--;
    }
}
