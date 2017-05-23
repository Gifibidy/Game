using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButtonDown(0)) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;


			if(Physics.Raycast (ray, out hit)) {
				if (hit.collider == this.gameObject.GetComponent<Collider>()) {
					this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				} else {
					this.gameObject.GetComponent<Renderer>().material.color = Color.black;
				}
			} 
		} 
			
	}
}
