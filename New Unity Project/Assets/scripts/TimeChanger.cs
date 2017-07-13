using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChanger : MonoBehaviour {

	GameObject resource;

	public Vector3 origin;
	public Vector3 temp; 
	private float speed = 150f;
	public int tracker = 1;
	public Light lt;
	public float dayNum = 1f;

 // permission to change stats
	bool dayCheck = false;
	bool nightCheck = false;
	bool scoreCheck = false; // permission to view score board at end of day

	public bool move = false; //permission to move
	public bool clickable = true; //prevent player from clicking while pointer is moving
	public bool changeTime;

	private Rigidbody rig;

	void Start () {

		resource = GameObject.Find ("Main Camera");

		rig = GetComponent<Rigidbody> ();
		origin = transform.position;
		temp = transform.position;
		lt = GetComponentInChildren<Light> ();
	}


	void Update () {

		transform.position = temp;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (clickable == true) {		
			if (changeTime == true) {					
				move = true;									
				temp = transform.position;
				clickable = false;
				changeTime = false;
			}
		}


		if((move == true) && (tracker == 1)) {
			temp.x += speed * Time.deltaTime;
			if (temp.x >= origin.x + (Screen.width / 26)) {
				move = false;
				clickable = true;
				tracker++;
				dayCheck = true;
			}
		}
		else if((move == true) && (tracker == 2)) {
			temp.x += speed * Time.deltaTime;
			if (temp.x >= origin.x + (Screen.width / 13)) {
				move = false;
				clickable = true;
				tracker = 3;

				nightCheck = true;
			}
		}
		if(dayCheck == true){
			MorningToDay (); //change stats
			dayCheck = false;
		}
		if(nightCheck == true){
			DayToNight ();  //change stats
			nightCheck = false;
		}



	}

			//all things taht change when u start a new day
	public void MorningToDay (){	
		resource.GetComponent<resources> ().treatPat ();

	}

	public void DayToNight(){
		resource.GetComponent<resources> ().treatPat ();
		resource.GetComponent<resources> ().PayStaff();
		resource.GetComponent<resources> ().payUpkeep();
	}
		

	public void endDay(){

		if (tracker == 1) {
			resource.GetComponent<resources> ().treatPat ();
			resource.GetComponent<resources> ().treatPat ();
			resource.GetComponent<resources> ().PayStaff ();
			resource.GetComponent<resources> ().payUpkeep ();

		} else if (tracker == 2) {
			resource.GetComponent<resources> ().treatPat ();
			resource.GetComponent<resources> ().PayStaff();
			resource.GetComponent<resources> ().payUpkeep();

		}

		resource.GetComponent<resources> ().scoreBorad ();
		clickable = false;
	}

	public void closeScore(){

		temp.x = origin.x;
		resource.GetComponent<resources> ().DayNumber ();
		resource.GetComponent<resources> ().newDay ();
		tracker = 1;
		clickable = true;
	}

	public void change(){
		changeTime = true;
	}
}


