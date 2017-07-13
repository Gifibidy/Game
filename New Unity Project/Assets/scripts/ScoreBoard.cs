using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

	GameObject pointer; 
	GameObject resource;

	GameObject staffText;
	GameObject patDayText;
	GameObject treatedText;
	GameObject moneyText;

	public Vector3 offScreenPos;

	string staff;
	string patDayNo;
	string patTreated;
	string moneyMade;
	string plusMinus;

	void Start () {
		
		pointer = GameObject.Find ("pointer");
		resource = GameObject.Find ("Main Camera");

		staffText = GameObject.Find ("staffNo");
		patDayText = GameObject.Find ("patDayNo");
		treatedText = GameObject.Find ("patTreated");
		moneyText = GameObject.Find ("moneyMade");
	}


	void Update () {
		
	}


	//get the values from resources script
	public void getStats(float staffNum, float patDayNum, float treatedNum, float moneyNum, string plusOrMinus){
		staff = staffNum.ToString ();
		patDayNo = patDayNum.ToString ();
		patTreated = treatedNum.ToString ();
		moneyMade = moneyNum.ToString ();	
		plusMinus = plusOrMinus + moneyNum;
		setStats ();

	}

	//set the text on the board
	public void setStats(){


		moneyText.GetComponent<Text>().text = plusMinus;
		treatedText.GetComponent<Text> ().text = patTreated;
		patDayText.GetComponent<Text> ().text = patDayNo;
		staffText.GetComponent<Text> ().text = staff;
		offScreenPos.y = Screen.height/2;
		offScreenPos.x = Screen.width/2;
		transform.position = offScreenPos;

	}
		

	public void offScreen(){
		offScreenPos.y = Screen.height*3;
		transform.position = offScreenPos;
	}
}
