using UnityEngine;
using System.Collections;

public class ButtonPresser : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        Button button = collider.gameObject.gameObject.GetComponent<Button>();
        if (button != null)
        {
            button.Press();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Button button = collider.gameObject.gameObject.GetComponent<Button>();
        if (button != null)
        {
            button.Release();
        }
    }
}
