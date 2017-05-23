using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour {

	public float Boundary = 50f;
	public float speed = 15f;
	public Vector3 temp;

	public bool zoomInRange;
	public bool zoomOutRange;
	public bool moveXLeft;
	public bool moveXRight;
	public bool moveZLeft;
	public bool moveZRight;

	private float ScreenWidth;
	private float ScreenHeight;
	private Rigidbody rig;

	// Use this for initialization
	void Start () {
		ScreenWidth = Screen.width;
		ScreenHeight = Screen.height;
		rig = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {


		//camera movement
		temp = transform.position;
		//left and right
		if (transform.position.x > 0f) {
			moveXLeft = true;
		} else {
			moveXLeft = false; }

		if (transform.position.x < 35f) {
			moveXRight = true;
		} else {
			moveXRight = false;	}

		if (transform.position.z > 0f) {
			moveZLeft = true;
		} else {
			moveZLeft = false;	}

		if (transform.position.z < 35f) {
			moveZRight = true;
		} else {
			moveZRight = false;	}

		if((Input.mousePosition.x > ScreenWidth - Boundary) && (moveXRight == true)){
			temp.x += speed * Time.deltaTime; } 

		if((Input.mousePosition.x < 0f + Boundary) && (moveXLeft == true)){
			temp.x-= speed * Time.deltaTime; }

		//forward and backwards
		if((Input.mousePosition.y > ScreenHeight - Boundary) && (moveZRight == true)){
			temp.z += speed * Time.deltaTime; }

		if((Input.mousePosition.y < 0f + Boundary) && (moveZLeft == true)){
			temp.z -= speed * Time.deltaTime; }
		
		transform.position = temp;



		//camera zoom
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
