using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float speed = 5;

	void Start () {
	
	}
	
	void Update () {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 target = -(mousePos.origin + (mousePos.direction * (mousePos.origin.z / mousePos.direction.z)));
           
        //mousePos.z = mousePos.y;
        //mousePos.y = 0;

        Vector3 distance = target - transform.position;

        Debug.DrawRay(mousePos.origin, mousePos.direction);
        Debug.DrawLine(mousePos.origin, target, Color.red);

        transform.rotation.SetAxisAngle(new Vector3(0, 0, 1), Vector3.Angle(distance, new Vector3(0, 1, 0)));

        Debug.DrawRay(transform.position, distance);
        Vector3 move = distance.normalized * speed * Time.deltaTime;

        transform.position += move;
	}
}
