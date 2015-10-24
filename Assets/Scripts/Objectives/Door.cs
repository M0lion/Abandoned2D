using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Power))]

public class Door : MonoBehaviour {

    public Transform left;
    public Transform right;

    public Vector3 leftClosedPos;
    public Vector3 rightClosedPos;

    Power power;

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

        power = GetComponent<Power>();
	}
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ToggleOpen();
        }

        if(power.powered && !open)
        {
            Open();
        }
        else if(!power.powered && !closed)
        {
            Close();
        }

        UpdateDoors();
    }

    public void ToggleOpen()
    {
        if (closed || closing)
            Open();
        else if (open || opening)
            Close();
    }

    public void Open()
    {
        closed = false;
        opening = true;
        closing = false;
    }

    public void Close()
    {
        open = false;
        closing = true;
        opening = false;
    }

    void UpdateDoors()
    {
        if (opening)
        {
            if (open)
                return;
            
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
            if (closed)
                return;
            
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
}
