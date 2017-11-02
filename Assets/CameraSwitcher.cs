using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {
	public Camera characterPerspective;
	public Camera overviewPerspective;

	// Use this for initialization
	void Start () {
		overviewPerspective.enabled = true;
		characterPerspective.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			overviewPerspective.enabled = true;
			characterPerspective.enabled = false;
		}
		if (Input.GetKeyDown ("2")) {
			overviewPerspective.enabled = false;
			characterPerspective.enabled = true;
		}

	}
}
