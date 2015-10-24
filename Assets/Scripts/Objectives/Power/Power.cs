using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {

    public bool powered = false;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void power(bool power)
    {
        powered = power;
    }
}
