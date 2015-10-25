using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    
    public Power target;

    public MeshRenderer active;
    public MeshRenderer inactive;
    bool switchMeshes;

    public int key = 0;

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

    public void Press(int key)
    {
        if(this.key == key)
            buttonPressers++;
    }

    public void Release(int key)
    {
        if (this.key == key)
            buttonPressers--;
    }
}
