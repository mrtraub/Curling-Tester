﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {
	//public List<string> inventory;
	private float forceAmount = 5.0f;
	private float forceAmount2 = .5f;

	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Collectable") {
			other.GetComponent<Collectable> ().Collect ();
			//inventory.Add (other.GetComponent<Collectable> ().description);
			//Debug.Log ("collect");
			forceAmount = Random.value;
			forceAmount = (2*forceAmount)+2;
			Debug.Log (forceAmount);
			GetComponent<Rigidbody> ().AddForce (transform.forward * forceAmount, ForceMode.VelocityChange);
			if (Input.GetKey (KeyCode.LeftArrow)) {
				GetComponent<Rigidbody> ().AddForce (transform.right * -forceAmount2, ForceMode.VelocityChange);
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				GetComponent<Rigidbody> ().AddForce (transform.right * forceAmount2, ForceMode.VelocityChange);
			}




			//GetComponent<LightUnlock> ().CheckInventory ();
		}

	}

}