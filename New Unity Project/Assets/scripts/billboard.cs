using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		transform.LookAt (Camera.main.transform.position, -Vector3.up);
	}
}
