using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumpsound : MonoBehaviour {
	private AudioSource source;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter()
	{
		source.Play();
	}
}
