using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    public float delay = 9;
    float time = 0;

	void Start () {
	
	}
	
	void Update () {
        time += Time.deltaTime;

        if (time >= delay)
            Application.LoadLevel("Main");
	}
}
