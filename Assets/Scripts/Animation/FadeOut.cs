using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

    bool fade = false;
    bool exiting = false;
    public MeshRenderer target;

    float time = 0;
    public float InTime = 1;
    public float exitDelay = 2;

	void Start () {
	
	}
	
	void Update () {
	    if(fade)
        {
            Color color = target.material.color;
            color.a = Mathf.Lerp(0, 1, time / InTime);
            target.material.color = new Color(1, 1, 1, color.a);
            Debug.Log(color.a);

            target.material.SetColor("_EmissionColor", new Color(1, 1, 1, color.a));
            target.material.EnableKeyword("_EMISSION");

            if (time >= InTime)
            {
                fade = false;
                exiting = true;
                time -= InTime;
            }
            time += Time.deltaTime;
        }

        if(exiting)
        {
            time += Time.deltaTime;
            if(time >= exitDelay)
                Application.LoadLevel("Menu");
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        fade = true;
    }
}
