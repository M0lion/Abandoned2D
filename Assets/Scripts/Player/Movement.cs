using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float speed = 1;

	void Start () {
	
	}
	
	void Update () {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 target = 
            (mousePos.origin + (mousePos.direction * (-mousePos.origin.z / mousePos.direction.z)));
           
        //mousePos.z = mousePos.y;
        //mousePos.y = 0;

        Vector3 distance = target - transform.position;

        if (distance.magnitude < 0.1)
            return;

        Vector3 direction = distance.normalized;
        
        Debug.DrawRay(mousePos.origin, mousePos.direction);
        Debug.DrawLine(mousePos.origin, target, Color.red);

        float angle = Vector3.Angle(transform.up, direction);
        Vector2 a = new Vector2(transform.up.x, transform.up.y);
        Vector2 b = new Vector2(direction.x, direction.y);
        if (Vector3.Cross(transform.up, direction).z < 0)
        {
            angle *= -1;
        }
        transform.RotateAroundLocal(Vector3.forward,  Mathf.Deg2Rad * angle);
        
        Debug.DrawRay(transform.position, distance);
        Vector3 move = direction * speed * Time.deltaTime;

        transform.position += move;
	}
}
