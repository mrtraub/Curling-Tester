using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweep : MonoBehaviour {

	private float sweepSpeed = 1.0f;
	private float movementDist = 1.0f;


	private float startingX;

	private bool isMovingFor = true;

	public GameObject pellet;

	void Start()
	{
		startingX = transform.position.x;
	}

	void Update()
	{

		if (Input.GetKeyUp (KeyCode.RightShift)) {
			dropSpeedPellet ();
		}
	}

	void dropSpeedPellet()
	{
		GameObject p = (GameObject)Instantiate(pellet, transform.position, transform.rotation);
		//p.transform.position;
		p.SetActive (true);
	}

	private void sweeper()
	{
			float newX = transform.position.x + (isMovingFor ? 1 : -1) * 2 * movementDist * sweepSpeed * Time.deltaTime;

			if (newX > startingX + movementDist) {
				newX = startingX = movementDist;
				isMovingFor = false;
			} 
			else if (newX < startingX) {
				newX = startingX;
				isMovingFor = true;
			}

			transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}


}
