using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

    bool fade = true;
    public MeshRenderer target;

    float time = 0;
    public float OutTime = 1;

	void Start () {
	
	}
	
	void Update () {
	    if(fade)
        {
            Color color = target.material.color;
            color.a = Mathf.Lerp(1, 0, time / OutTime);
            target.material.color = new Color(1, 1, 1, color.a);
            Debug.Log(color.a);

            target.material.SetColor("_EmissionColor", new Color(0, 0, 0, color.a));
            target.material.EnableKeyword("_EMISSION");

            if (time >= OutTime)
            {
                fade = false;
            }
            time += Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        fade = true;
    }
}
