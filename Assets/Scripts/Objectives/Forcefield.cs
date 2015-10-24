using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Power))]
[RequireComponent(typeof(Collider2D))]
public class Forcefield : MonoBehaviour {

    public GameObject forcefield;
    Collider2D collider;
    Power power;

	void Start () {
        power = GetComponent<Power>();
        collider = GetComponent<Collider2D>();
	}
	
	void Update () {
        forcefield.SetActive(!power.powered);
        collider.enabled = !power.powered;
	}
}
