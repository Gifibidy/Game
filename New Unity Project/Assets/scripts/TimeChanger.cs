using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChanger : MonoBehaviour {

	public Vector3 origin;
	public Vector3 temp; 
	private float speed = 150f;
	public int tracker = 1;
	public Light lt;


	public bool move = false; //permission to move
	public bool repeat = true; //go back to morning from night

	private Rigidbody rig;

	void Start () {
		rig = GetComponent<Rigidbody> ();
		origin = transform.position;
		temp = transform.position;

		lt = GetComponentInChildren<Light> ();
	}
	

	void Update () {

		transform.position = temp;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (repeat == true){
			if (Input.GetMouseButtonDown (0)) {							//this block of code can be replaced by an external script that causes the time of day to shift
				if (Physics.Raycast (ray, out hit)) {					//
					if (hit.collider.tag == "balls") {					//
						move = true;									//
						origin = transform.position;
						repeat = false;
					}
				}
			}
		}

		if((move == true) && (tracker < 3)) {
			temp.x += speed * Time.deltaTime;
				if (temp.x >= origin.x + 75f) {
					move = false;
					repeat = true;
					tracker++;
				}
		}
		else if ((move == true) && (tracker == 3)){
			temp.x -= (speed*2) * Time.deltaTime;
				if (temp.x <= origin.x - 150f) {
					move = false;
					repeat = true;
					tracker = 1;
				}
		}

		if (tracker == 3) {
			lt.intensity = 0.3f;
		} else {
			lt.intensity = 4.0f;
		}


	}
}
