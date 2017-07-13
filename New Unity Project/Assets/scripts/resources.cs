using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class resources : MonoBehaviour {

	public float roomCap = 1;
	GameObject timey;
	GameObject score;

	public float treated;
	public float notTreated;
	public float totalTreated = 0;

	GameObject Money;
	public string moneyString;
	public float currentMoney = 10f;
	public float moneyDiff; 							//amount of money gained/lost at end of the day
	public float moneyOrigin;							 //money at start of the day
	public string plusOrMinus;

	public float payment;

	GameObject Staff;
	public string staffString;
	public float currentStaff = 3f;

	GameObject Patient;
	public string patientString;
	public float currentPatient = 15f; 					 // tracks current number of patients
	public float patOrigin = 15f; 						 //number of patients the previos day
	public float patientTotal; 								 //total number of patients for the new day

	public float DayNum = 1f;
	public float upKeep;


	void Start () {
		timey = GameObject.Find ("pointer");

		Money = GameObject.Find ("moneyText");
		Staff = GameObject.Find ("staffText");
		Patient = GameObject.Find ("patientText");

		score = GameObject.Find ("scoreBoard");
	}


	public void Update () {
		moneyString = ("$ " + (currentMoney.ToString ()));
		Money.GetComponent<Text>().text = moneyString;

		staffString = (currentStaff.ToString () + " Staff");
		Staff.GetComponent<Text> ().text = staffString;

		patientString = (currentPatient.ToString () + " Patients");
		Patient.GetComponent<Text> ().text = patientString;
	}

	public void DayNumber (){															//keep track of day number
		DayNum ++;
	}

	public void newDay (){ 																	//new day patient number

		totalTreated = 0;

		//new number of patients
		int rand = Random.Range(1, 10);									

		float rand1 = (float)rand;
		patientTotal = (20f+rand1) + roomCap * 10f;
		//patientTotal = patOrigin + (DayNum * rand1);
		patOrigin = patientTotal;
		currentPatient = patientTotal;

		//set money origin
		moneyOrigin = currentMoney;
		Debug.Log (" "+ payment);
	}

	public void payUpkeep(){
		double percent = (currentMoney / 100) * 10;   //10 % of current money
		double roomPercent = (currentMoney / 100) * roomCap; //1 percent for every room unlocked
		percent =+ roomPercent;
		percent = System.Math.Round (percent, 0);
		upKeep = (float)percent;
		currentMoney = currentMoney - upKeep; 
	}

	public void PayStaff(){
		payment = currentStaff * 100f;
		currentMoney = currentMoney - payment;	
	}

	public void treatPat(){												
		if ((currentStaff * 5f)  > currentPatient) {
			treated = currentPatient;
			currentPatient = 0;
		} else {
			treated = currentStaff * 5f;
			notTreated = currentPatient - treated;
		}
		currentPatient = notTreated;

		float payment1 = treated * 15f;
		currentMoney = currentMoney + payment1;
		totalTreated += treated;
	}

	public void moneyDifference(){
		moneyDiff = currentMoney - moneyOrigin;
		if (moneyDiff > 0f) {
			plusOrMinus = "+ ";
		} else {
			plusOrMinus = " ";
		}
	}

	public void scoreBorad(){
		moneyDifference ();
		score.GetComponent<ScoreBoard> ().getStats(currentStaff, patOrigin, totalTreated, moneyDiff, plusOrMinus);
		
	}

	public void newRoom(){
		roomCap++;
	}




	public void AddMoney (float newMoney){												//add money
		currentMoney = currentMoney + newMoney;
	}

	public void TakeMoney (float newMoney){
		currentMoney = currentMoney - newMoney;
	}

	public void AddStaff (float newStaff){													//add staff
		currentStaff = newStaff + currentStaff;
		timey.GetComponent<TimeChanger> ().change ();
	}

	public void TakeStaff(float newStaff){
		currentStaff = currentStaff - newStaff;
	}

	public void AddPatients(float newPatient){
		currentPatient = newPatient + currentPatient;
	}

	public void TakePatients (float newPatient){
		currentPatient = currentPatient - newPatient;
	}
}
