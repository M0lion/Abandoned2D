using UnityEngine;
using System.Collections;

public class Player: MonoBehaviour {

    public Light light;

    public float speed = 5;

    Rigidbody2D body;

    Vector3 target;

    bool hasTarget = false;

	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        target = transform.position;
	}
	
	void Update () {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 target = (mousePos.origin + (mousePos.direction * (-mousePos.origin.z / mousePos.direction.z)));

        Vector3 distance = target - transform.position;

        if (distance.magnitude < 0.1 || !hasTarget)
        {
            hasTarget = false;
            return;
        }
        
        if (Mathf.Abs(distance.x) < 0.01)
            distance.x = 0.01f;

        Vector3 direction = distance.normalized;
        direction.z = 0;

        float angle = Vector3.Angle(transform.up, direction);
        if (Vector3.Cross(transform.up, direction).z < 0)
        {
            angle *= -1;
        }
        
        transform.up = direction * 100;
        
        Debug.DrawRay(transform.position, distance);
        //float targetSpeed = Mathf.Min(1, distance.magnitude / 1));
        float targetSpeed = Mathf.Min(1, Mathf.Pow(distance.magnitude / 2, 2)) * speed;
        Vector3 move = direction * targetSpeed * Time.deltaTime;
        

        body.MovePosition(transform.position + move);
	}

    public void setTarget(Vector3 target)
    {
        this.target = target;
        hasTarget = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>().addPlayer(player);
            player.Enable();
        }
    }

    void Enable()
    {
        if(light != null)
        {
            light.enabled = true;
        }

        Material mat = GetComponent<MeshRenderer>().material;
        mat.SetColor("_EmissionColor", Mathf.LinearToGammaSpace(1) * mat.color);
        mat.EnableKeyword("_EMISSION");

    }
}
