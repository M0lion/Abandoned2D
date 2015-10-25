using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {

    public float startDelay = 0;
    public float outTime = 5;
    public float inDelay = 5;
    public float inTime = 5;

    float time = 0;
    int phase = 0;

    public MeshRenderer target;

	void Start () {
	
	}
	
	void Update () {
	    switch(phase)
        {
            case 0:
                {
                    if (time >= startDelay)
                    {
                        phase++;
                        time -= startDelay;
                    }
                }
                break;
            case 1:
                {
                    Color color = target.material.color;
                    color.a = Mathf.Lerp(1, 0, time / outTime);
                    target.material.color = new Color(0,0,0,color.a);
                    Debug.Log(target.material.color.a);

                    if (time >= outTime)
                    {
                        phase++;
                        time -= outTime;
                    }
                }
                break;
            case 2:
                {
                    if (time >= inDelay)
                    {
                        phase++;
                        time -= inDelay;
                    }
                }
                break;
            case 3:
                {
                    Color color = target.material.color;
                    color.a = Mathf.Lerp(0, 1, time / inTime);
                    target.material.color = new Color(0, 0, 0, color.a);
                    Debug.Log(target.material.color.a);

                    if (time >= inTime)
                    {
                        phase++;
                        time -= inTime;
                    }
                }
                break;

        }

        time += Time.deltaTime;
	}
}
