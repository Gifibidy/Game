using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rooms : MonoBehaviour {

	GameObject selected;

	GameObject room01; 
	GameObject room02; 
	GameObject room03; 
	GameObject room04; 
	GameObject room05; 
	GameObject room06; 
	GameObject room07; 
	GameObject room08; 
	GameObject room09; 
	GameObject room010; 

	GameObject info;
	public string blank;
	void Start () {
		info = GameObject.Find("textGuy");
		blank =  " ";

		room01 = GameObject.Find ("room1");
		room02 = GameObject.Find ("room2");
		room03 = GameObject.Find ("room3");
		room04 = GameObject.Find ("room4");
		room05 = GameObject.Find ("room5");
		room06 = GameObject.Find ("room6");
		room07 = GameObject.Find ("room7");
		room08 = GameObject.Find ("room8");
		room09 = GameObject.Find ("room9");
		room010 = GameObject.Find ("room10");
	}


	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonDown (0)) {							//this block of code can be replaced by an external script that causes the time of day to shift
			if (Physics.Raycast (ray, out hit)) {					//
				switch (hit.collider.tag) {
				case "room1":
						room01.GetComponent<openRoom> ().viewRoom ();
						Debug.Log (" room 1 clicked");
						selected = GameObject.Find ("room1");
					break;
				case "room2":
						room02.GetComponent<openRoom> ().viewRoom ();  ///this will open a window with a buy room button
						Debug.Log (" room 2 clicked ");
						selected = GameObject.Find ("room2");
					break;
				case "room3":
						room03.GetComponent<openRoom> ().viewRoom ();
						selected = GameObject.Find ("room3");
						Debug.Log (" room 3 clicked ");
					break;
				case "room4":
						room04.GetComponent<openRoom> ().viewRoom ();
						selected = GameObject.Find ("room4");
						Debug.Log (" room 4 clicked ");
					break;
				case "room5":
						room05.GetComponent<openRoom> ().viewRoom ();
						selected = GameObject.Find ("room5");
						Debug.Log (" room 5 clicked ");
					break;
				case "room6":
						room06.GetComponent<openRoom> ().viewRoom ();
						selected = GameObject.Find ("room6");
						Debug.Log (" room 6 clicked ");
					break;
				case "room7":
						room07.GetComponent<openRoom> ().viewRoom ();
						selected = GameObject.Find ("room7");
						Debug.Log (" room 7 clicked ");
					break;
				case "room8":					
						room08.GetComponent<openRoom> ().viewRoom ();
						selected = GameObject.Find ("room8");
						Debug.Log (" room 8 clicked "); 
					break;
				case "room9":			
						room09.GetComponent<openRoom> ().viewRoom ();
						selected = GameObject.Find ("room9");
						Debug.Log (" room 9 clicked "); 
					break;
				case "room10":
						room010.GetComponent<openRoom> ().viewRoom ();
						selected = GameObject.Find ("room10");
						Debug.Log (" room 10 clicked ");
					break;
				default: 
					info.GetComponent<Text>().text = blank;

					break;
				}
			
			}
		}
	}

	public void unlock (){
		selected.GetComponent<openRoom>().buyRoom();
		//Debug.Log (" button pressed ");
	}
	public void close(){
		selected.GetComponent<openRoom>().closeRoom();
	}
		
}
