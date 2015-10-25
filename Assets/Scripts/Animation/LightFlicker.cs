using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Light))]
public class LightFlicker : MonoBehaviour {

    public float maxIntensity = 8;
    public float minIntensity = 5;

    public float cycleTime = 1;

    float time = 0;

    Light target;

	void Start () {
        target = GetComponent<Light>();
	}
	
	void Update () {
        time += Time.deltaTime;
        target.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(time / cycleTime, 1));
	}
}
