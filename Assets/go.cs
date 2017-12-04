using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class go : MonoBehaviour {

	public Text powerMeter;
	public Slider slideMeter;
	private float forceAmount;
	private bool launched = false;
	private int plusmin = 1;
	private bool wait = false;
	public bool turnOver = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<Rigidbody> ().velocity = transform.forward * speed;
		if (launched == false) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z+1), .1f);
			}

			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1), .1f);
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Rotate (0, -.5f, 0);
			}

			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Rotate (0, .5f, 0);
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				forceAmount = 0f;
			}
			if (Input.GetKey (KeyCode.Space)) {
				//make the force continuous
				if (forceAmount > 80 || forceAmount < 0)
					plusmin = plusmin * -1;
				forceAmount = forceAmount + (plusmin*.5f);
				powerMeter.text = forceAmount.ToString ("FORCE AMOUNT: 0");
				slideMeter.value = forceAmount;
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
				
				if (wait == false)
					wait = true;
				else {
					GetComponent<Collector> ().enabled = false;
					turnOver = true;
					wait = false;
				}

			}
			
		}
			
	}
}
