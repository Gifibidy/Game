using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class resources : MonoBehaviour {
	GameObject Money;
	public string moneyString;
	public float currentMoney = 1000f;

	GameObject Staff;
	public string staffString;
	public float currentStaff = 10f;

	GameObject Patient;
	public string patientString;
	public float currentPatient = 50f;

	// Use this for initialization
	void Start () {
		Money = GameObject.Find ("moneyText");
		Staff = GameObject.Find ("staffText");
		Patient = GameObject.Find ("patientText");
	}

	// Update is called once per frame
	public void Update () {
		moneyString = currentMoney.ToString ();
		Money.GetComponent<Text>().text = moneyString;

		staffString = currentStaff.ToString ();
		Staff.GetComponent<Text> ().text = staffString;

		patientString = currentPatient.ToString ();
		Patient.GetComponent<Text> ().text = patientString;
	}

	public void AddMoney (float newMoney){
		currentMoney = currentMoney + newMoney;
		return;
	}

	public void TakeMoney (float newMoney){
		currentMoney = currentMoney - newMoney;
		return;
	}

	public void AddStaff (float newStaff){
		currentStaff = newStaff + currentStaff;
		return;
	}

	public void TakeStaff(float newStaff){
		currentStaff = currentStaff - newStaff;
		return;
	}

	public void AddPatients(float newPatient){
		currentPatient = newPatient + currentPatient;
		return;
	}

	public void TakePatients (float newPatient){
		currentPatient = currentPatient - newPatient;
		return;
	}
}
