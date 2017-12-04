using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class go : MonoBehaviour {

	public Text powerMeter;
	private float forceAmount;
	private bool launched = false;

	public bool turnOver = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<Rigidbody> ().velocity = transform.forward * speed;
		if (launched == false) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				forceAmount = 0f;
			}
			if (Input.GetKey (KeyCode.Space)) {
				//make the force continuous
				forceAmount = forceAmount + .5f;
				powerMeter.text = forceAmount.ToString ("FORCE AMOUNT: 0");
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				//				GetComponent<Rigidbody> ().AddForce (transform.forward * 25f, ForceMode.Acceleration);
				//one time hit
				GetComponent<Rigidbody> ().isKinematic = false;
				GetComponent<Rigidbody> ().AddForce (transform.forward * forceAmount, ForceMode.VelocityChange);
				Invoke ("ResetTrigger", 1);
				launched = true;
			}
		}
		else
		{
			if (GetComponent<Rigidbody> ().velocity == new Vector3 (0, 0, 0) && launched == true) {
				

				GetComponent<Collector> ().enabled = false;
				turnOver = true;

			}
			
		}
			
	}
}
