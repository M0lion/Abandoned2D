using UnityEngine;
using System.Collections;

public class Clicking : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        Application.LoadLevel("Intro");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
