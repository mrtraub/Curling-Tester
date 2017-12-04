using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCalc : MonoBehaviour {
	public GameObject target;
	public Text dist;
	public float distance;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//distance = Mathf.Sqrt ((transform.position.x-target.transform.position.x) ^ 2 - (transform.position.z-target.transform.position.z) ^ 2);
		distance = Vector3.Distance(transform.position,target.transform.position);

		dist.text = "DIST: " + distance.ToString();
	}
}
