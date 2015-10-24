using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public Transform left;
    public Transform right;

    public Vector3 leftClosedPos;
    public Vector3 rightClosedPos;

    bool open = false;
    bool closed = true;

    bool opening = false;
    bool closing = false;

    public float openingTime = 1.5f;
    float openingLength = 0.5f;
    float openingSpeed;
    float pos = 0;

	void Start () {
        openingSpeed = openingLength / openingTime;
        leftClosedPos = left.localPosition;
        rightClosedPos = right.localPosition;
	}
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (closed)
                Open();
            else if (open)
                Close();
        }

        if (opening)
        {
            float deltaPos = openingSpeed * Time.deltaTime;
            left.localPosition -= new Vector3(deltaPos, 0, 0);
            right.localPosition -= new Vector3(-deltaPos, 0, 0);
            pos += deltaPos;

            if (pos >= openingLength)
            {
                opening = false;
                open = true;
            }
        }
        if (closing)
        {
            float deltaPos = openingSpeed * Time.deltaTime;
            left.localPosition += new Vector3(deltaPos, 0, 0);
            right.localPosition += new Vector3(-deltaPos, 0, 0);
            pos -= deltaPos;

            if (pos <= 0)
            {
                closing = false;
                closed = true;

                left.localPosition = leftClosedPos;
                right.localPosition = rightClosedPos;
            }
        }
    }

    public void Open()
    {
        closed = false;
        opening = true;
    }

    public void Close()
    {
        open = false;
        closing = true;
    }
}
