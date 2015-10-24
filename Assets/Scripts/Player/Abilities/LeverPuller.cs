using UnityEngine;
using System.Collections;

public class LeverPuller : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        Lever lever = collider.gameObject.gameObject.GetComponent<Lever>();
        if (lever != null)
        {
            lever.Flip();
        }
    }
}
