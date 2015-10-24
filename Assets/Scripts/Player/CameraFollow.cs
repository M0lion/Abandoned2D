using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;

	void Start () {
	
	}
	
	void Update () {
        Vector3 tar = target.position;
        tar.z = transform.position.z;
        transform.position = tar;
	}
}
