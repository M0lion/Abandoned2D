using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Power))]
[RequireComponent(typeof(Collider2D))]
public class Forcefield : MonoBehaviour {

    public GameObject forcefield;
    Collider2D collider;
    Power power;

	public AudioClip sound;
	private AudioSource source;

	void Start () {
        power = GetComponent<Power>();
        collider = GetComponent<Collider2D>();
		source = GetComponent<AudioSource> ();
	}
	
	void Update () {
        forcefield.SetActive(!power.powered);
        collider.enabled = !power.powered;
	}
}
