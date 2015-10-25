using UnityEngine;
using System.Collections;

public class LeverPuller : MonoBehaviour {

    public int key = 0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Lever lever = collider.gameObject.gameObject.GetComponent<Lever>();
        if (lever != null)
        {
            lever.Flip(key);
        }
    }
}
