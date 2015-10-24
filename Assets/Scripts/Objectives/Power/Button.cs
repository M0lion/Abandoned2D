using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    
    public Power target;

    public MeshRenderer active;
    public MeshRenderer inactive;
    bool switchMeshes;

    public bool powered = false; 

    int buttonPressers = 0;
    
	void Start () {
        switchMeshes = active != null && inactive != null;
	}
	
	void Update () {
	    if(buttonPressers > 0 && !powered)
        {
            powered = true;
            target.power(true);
            SwitchMeshes();
        }
        else if(buttonPressers <= 0 && powered)
        {
            powered = false;
            target.power(false);
            SwitchMeshes();
        }
	}

    void SwitchMeshes()
    {
        if(active != null)
            active.enabled = powered;

        if(inactive != null)
            inactive.enabled = !powered;
    }

    public void Press()
    {
        buttonPressers++;
    }

    public void Release()
    {
        buttonPressers--;
    }
}
