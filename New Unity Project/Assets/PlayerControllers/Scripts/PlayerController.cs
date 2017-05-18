using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 18;

    private Rigidbody rig;

	public bool zoomInRange;
	public bool zoomOutRange;

	void Start () 
    {
        rig = GetComponent<Rigidbody>();
	}
	

	void Update () 
    {
		//move stuff
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;

        rig.MovePosition(transform.position + movement);

		//zoom stuff

		if (GetComponent<Camera> ().fieldOfView <= 15) { //how far u can zoom in
			zoomInRange = false;
		} else {
			zoomInRange = true;
		}
		 
		if (GetComponent<Camera> ().fieldOfView >= 55) { //how far u can zoom out
			zoomOutRange = false;
		} else {
			zoomOutRange = true;
		}

		if ((Input.GetAxis ("Mouse ScrollWheel") > 0) && (zoomInRange == true)) 
		{
			GetComponent<Camera> ().fieldOfView--;
			
		}

		if ((Input.GetAxis ("Mouse ScrollWheel") < 0) && (zoomOutRange == true))
		{
			GetComponent<Camera> ().fieldOfView++;

		}

	}
}
