using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

    public Power target;

    public MeshRenderer active;
    public MeshRenderer inactive;
    bool switchMeshes;

    float cooldown = 0.5f;
    float elapsedCooldown = 0;
    bool coolingDown = false;

    public bool powered = false;

    void Start()
    {
        switchMeshes = active != null && inactive != null;
    }

    void Update()
    {
        if (coolingDown)
        {
            elapsedCooldown += Time.deltaTime;
            if(elapsedCooldown >= cooldown)
            {
                coolingDown = false;
                elapsedCooldown = 0;
            }
        }
    }

    void SwitchMeshes()
    {
        if (active != null)
            active.enabled = powered;

        if (inactive != null)
            inactive.enabled = !powered;
    }

    public void Flip()
    {
        if (coolingDown)
            return;

        if (powered)
            Off();
        else
            On();

        transform.Rotate(Vector3.up, 180);
        
        coolingDown = true;
    }

    void On()
    {
        powered = true;
        target.power(true);
        SwitchMeshes();
    }

    void Off()
    {
        powered = false;
        target.power(false);
        SwitchMeshes();
    }
}
