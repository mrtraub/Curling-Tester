using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGun : MonoBehaviour {
	public GameObject projectile;
	public float speed;
	public float timeBetweenShots;
	private float lastShotTime;
	// Use this for initialization
	void Start () {
		lastShotTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Shoot ();
	}

	void Shoot() {
		if(Input.GetAxis("Fire1") == 1) {
			if (lastShotTime + timeBetweenShots <= Time.time) {
				// Create the Bullet from the Bullet Prefab
				GameObject bullet = (GameObject)Instantiate (projectile, transform.position, Camera.main.transform.rotation);

				// Add velocity to the bullet
				bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * speed;

				// Destroy the bullet after 5 seconds
				Destroy (bullet, 5.0f);
				lastShotTime = Time.time;
			}
		}

	}


}
