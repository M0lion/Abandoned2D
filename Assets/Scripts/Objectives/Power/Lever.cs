using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

    public int key = 0;

    public Power target;

    public MeshRenderer active;
    public MeshRenderer inactive;
    bool switchMeshes;

    float cooldown = 0.5f;
    float elapsedCooldown = 0;
    bool coolingDown = false;

    public bool powered = false;

	public AudioClip sound;
	private AudioSource source;

    void Start()
    {
        switchMeshes = active != null && inactive != null;
		source = GetComponent<AudioSource> ();
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

    public void Flip(int key)
    {
        if (coolingDown || this.key != key)
            return;

        if (powered)
            Off();
        else
            On();

        transform.Rotate(Vector3.up, 180);
        
        coolingDown = true;

		source.PlayOneShot (sound);
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
