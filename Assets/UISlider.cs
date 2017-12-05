using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour {

	public Slider stoneslide;
	public Slider roundslide;
	public Text stoneText;
	public Text roundText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		stoneText.text = stoneslide.value.ToString();
		roundText.text = roundslide.value.ToString();
	}
}
