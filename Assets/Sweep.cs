using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweep : MonoBehaviour {

	private float sweepSpeed = 1.5f;
	private float movementDist = 1.0f;
	private bool isSweeping = false;
	private AudioSource source;
	private float startingZ;

	private bool isMovingFor = true;

	public GameObject pellet;

	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	void Update()
	{
		
		if (Input.GetKeyUp (KeyCode.RightShift)) {
			if (!isSweeping) {
				startingZ = transform.parent.position.z;
				dropSpeedPellet ();
				isSweeping = true;
			}
		}
		if (isSweeping) {
			sweeper ();
		}
	}

	void dropSpeedPellet()
	{
		GameObject p = (GameObject)Instantiate(pellet, transform.position, transform.rotation);
		//p.transform.position;
		p.SetActive (true);

		source.Play ();
	}

	private void sweeper()
	{
		float newZ = transform.position.z + ((isMovingFor ? 1 : -1) * 2 * movementDist * sweepSpeed * Time.deltaTime);
		startingZ = transform.parent.position.z;

			if (newZ > startingZ + movementDist) {
				newZ = startingZ + movementDist;
				isMovingFor = false;
			} 
			else if (newZ < startingZ) {
				newZ = startingZ;
				isMovingFor = true;
				isSweeping = false;
			}

		transform.position = new Vector3 (transform.position.x, transform.position.y, newZ);
	}


}
