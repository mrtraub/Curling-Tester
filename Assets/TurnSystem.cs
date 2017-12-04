using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour {

	public GameObject greenStone;
	public GameObject mauveStone;
	public GameObject[] stones = new GameObject[10];
	public Text pMeter;
	public Text dMeter;
	public Slider sMeter;
	public GameObject targ;
	public GameObject mainCam;
	private int curr = 0;
	private double[] distances;

	private bool timeForNextTurn;


	// Use this for initialization
	void Start () {
		init ();
		Inning ();
	}
	
	// Update is called once per frame
	void Update () {
		if (curr >= stones.Length)
			Inning ();
		else{
			timeForNextTurn = stones [curr].GetComponent<go> ().turnOver;
			Debug.Log (timeForNextTurn);
			if (timeForNextTurn == true) {
				GameObject br = GameObject.FindGameObjectWithTag ("Broom");
				if(br!=null)
					br.SetActive (false);
				GameObject sc = GameObject.FindGameObjectWithTag ("StoneCamera");
				sc.SetActive (false);
				curr += 1;
				Inning ();
			}
		}
	}

	void init()
	{
		Vector3 p = new Vector3 (-300, 1.15f, 0);
		for (int i = 0; i < 10; i++) {
			if (i % 2 == 0) {
				
				GameObject s = Instantiate (greenStone, p, greenStone.transform.rotation);
				s.GetComponent<go> ().powerMeter = pMeter;
				s.GetComponent<DistanceCalc> ().target = targ;
				s.GetComponent<DistanceCalc> ().dist = dMeter;
				s.GetComponent<go> ().slideMeter = sMeter;
				s.SetActive (false);
				stones[i] = s;
			} else {
				GameObject s = Instantiate (mauveStone, p, mauveStone.transform.rotation);
				s.GetComponent<go> ().powerMeter = pMeter;
				s.GetComponent<DistanceCalc> ().target = targ;
				s.GetComponent<DistanceCalc> ().dist = dMeter;
				s.GetComponent<go> ().slideMeter = sMeter;
				s.SetActive (false);
				stones[i] = s;
			}

		}
	}

	void Inning()
	{
		if (curr < stones.Length)
			stones [curr].SetActive (true);
		else
			getScore ();
	}

	void getScore()
	{
		mainCam.SetActive (true);
		int points = 1;
		GameObject[] SS = sortStones ();
		string winner = SS [0].tag;

		for(int i = 0; i<SS.Length-1; i++)
		{
			if (SS [i].tag== SS [i + 1].tag)
				points += 1;
			else
				break;
		}
		Debug.Log (winner);
		Debug.Log (points);


	}

	GameObject[] sortStones()
	{
		GameObject [] sortedStones = stones;
		GameObject selStone;
		int counter;
		//GameObject t;

		for (int i = 0; i < stones.Length; i++) {
			selStone = sortedStones [i];
			counter = i;
			for (int j = i+1; j < stones.Length-1; j++) {
				if ((float)(sortedStones [j].GetComponent<DistanceCalc> ().distance) < (float)(sortedStones [i].GetComponent<DistanceCalc> ().distance)) {
					selStone = sortedStones [j];
					counter = j;
				}
			}
			//t = sortedStones [counter];
			sortedStones [counter] = sortedStones [i];
			sortedStones [i] = selStone;
				
		}

		return sortedStones;
	}

}
