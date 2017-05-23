using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interact : MonoBehaviour {


	GameObject info;
	public string text_info;

	void Start () {
		info = GameObject.Find("item_Info");

	}


	public void Update () {

		if (Input.GetMouseButtonDown(0)) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;


			if(Physics.Raycast (ray, out hit)){
				if (hit.collider == this.gameObject.GetComponent<Collider>()) {
					this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
					text_info = this.gameObject.GetComponent<Text>().text; 
					info.GetComponent<Text>().text = text_info;

				} else {
					this.gameObject.GetComponent<Renderer>().material.color = Color.black;
				}
			}
		} 
	}

}
