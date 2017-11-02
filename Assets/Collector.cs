using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {
	//public List<string> inventory;
	private float forceAmount = 5.0f;

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
			GetComponent<Rigidbody> ().AddForce (transform.forward * forceAmount, ForceMode.VelocityChange);
		}


		//GetComponent<LightUnlock> ().CheckInventory ();
	}

}