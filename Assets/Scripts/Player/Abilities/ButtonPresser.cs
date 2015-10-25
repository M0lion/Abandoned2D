using UnityEngine;
using System.Collections;

public class ButtonPresser : MonoBehaviour {

    public int key = 0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Button button = collider.gameObject.gameObject.GetComponent<Button>();
        if (button != null)
        {
            button.Press(key);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Button button = collider.gameObject.gameObject.GetComponent<Button>();
        if (button != null)
        {
            button.Release(key);
        }
    }
}
