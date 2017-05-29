using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openRoom : MonoBehaviour {
	GameObject resource;
	GameObject info;
	GameObject timey;
	public Vector3 offScreenPos;
	public string notBought;
	public string bought;
	public string buying;

	public bool isBought = false;

	// Use this for initialization
	void Start () {
		info = GameObject.Find("textGuy");
		resource = GameObject.Find ("Main Camera");
		timey = GameObject.Find ("pointer");

		buying = "you bought the room! You can now have up to 20 more patients visit everyday!";
		bought = "you have already bought this room";
		notBought = "Unlocking this room will make your hospital able to" +
			" hold an additional 10 patients per day. Patients, when treated, " +
			" will pay you $10.";
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void viewRoom(){
		offScreenPos.y = Screen.height / 8;
		offScreenPos.x = Screen.width / 4;
		info.transform.position = offScreenPos;
		if(this.isBought == false){
			info.GetComponent<Text> ().text = notBought; 
			//display button
		}else{
			info.GetComponent<Text> ().text = bought;
		}
		

	}

	public void buyRoom(){
		if (this.isBought == false) {
			this.isBought = true;  //so u cant buy the same room twice
			resource.GetComponent<resources> ().TakeMoney (200f);
			resource.GetComponent<resources> ().newRoom ();
			info.GetComponent<Text> ().text = buying;
			timey.GetComponent<TimeChanger> ().change ();
		} else {
			viewRoom ();
		}
		Debug.Log (" button pressed");
	}

	public void roomOwned(){
		//bought = this.gameObject.GetComponent<Text>().text; 
		info.GetComponent<Text> ().text = bought;
		this.isBought = true;
		Debug.Log (" button pressed");

	}

	public void closeRoom(){
		offScreenPos.y = Screen.height * 6;
		offScreenPos.x = Screen.width * 6;
		info.transform.position = offScreenPos;
	}
}
