using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour {

	public GameObject greenStone;
	public GameObject mauveStone;

//	public GameObject[] stones = new GameObject[10];
	public List<GameObject> stones;
	public Text[] greenScore = new Text[11];
	public Text[] mauveScore = new Text[11];
	public Text pMeter;
	public Text dMeter;
	public Slider sMeter;
	public GameObject targ;
	public GameObject mainCam;
	public GameObject scoreboard;
	private int curr;
	private double[] distances;
	private int roundcounter = 0;
	private int greentotal = 0;
	private int mauvetotal = 0;
	private int rounds = 1;
	public Text win;
	private int stonelength = 10;
	private AudioSource source;

	private bool timeForNextTurn;


	// Use this for initialization
	void Start () {
		rounds = (int)GetComponent<UISlider>().roundslide.value;
		stonelength = (int)GetComponent<UISlider>().stoneslide.value;
		stonelength = 2 * stonelength;
		init ();
		Inning ();
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("escape"))
			Application.Quit();

		timeForNextTurn = stones [curr].GetComponent<go> ().turnOver;
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

	void init()
	{
		for (int i = 0; i < stones.Count; i++) {
			if(stones[i]!=null)
				stones [i].SetActive(false);
		}
		stones.Clear();


		Vector3 p = new Vector3 (-300, 1.15f, 0);
		for (int i = 0; i < stonelength; i++) {
			if (i % 2 == 0) {
				
				GameObject s = Instantiate (greenStone, p, greenStone.transform.rotation);
				s.GetComponent<go> ().powerMeter = pMeter;
				s.GetComponent<DistanceCalc> ().target = targ;
				s.GetComponent<DistanceCalc> ().dist = dMeter;
				s.GetComponent<go> ().slideMeter = sMeter;
				s.SetActive (false);
//				stones[i] = s;
				stones.Add (s);
			} else {
				GameObject s = Instantiate (mauveStone, p, mauveStone.transform.rotation);
				s.GetComponent<go> ().powerMeter = pMeter;
				s.GetComponent<DistanceCalc> ().target = targ;
				s.GetComponent<DistanceCalc> ().dist = dMeter;
				s.GetComponent<go> ().slideMeter = sMeter;
				s.SetActive (false);
//				stones[i] = s;
				stones.Add (s);
			}

		}
		curr = 0;
	}

	void Inning()
	{
		if (curr < stones.Count && stones [curr] != null)
			stones [curr].SetActive (true);
		else {
			getScore ();
		}
	}

	void endGame()
	{
		if (greentotal > mauvetotal)
			win.text = "P1 Wins!";
		else if (greentotal < mauvetotal)
			win.text = "P2 Wins!";
		else {
			win.text = "Tie game!";
		}
	}

	void getScore()
	{
		source.Play ();
		mainCam.SetActive (true);
		int points = 0;
		List<GameObject> SS = sortStones ();
		string winner = "nobody";

		if (SS [0].GetComponent<DistanceCalc> ().distance < 26) {
				winner = SS[0].tag;
				points = 1;
		}
			

		for(int i = 0; i<stonelength; i++)
		{
			if (SS [i].tag== SS [i + 1].tag && SS [i + 1].GetComponent<DistanceCalc> ().distance < 26)
				points += 1;
			else
				break;
		}
		if (winner == "GreenStone") {
			greenScore [roundcounter].text = points.ToString ();
			greentotal += points;
			greenScore [10].text = greentotal.ToString ();
		} else if (winner == "MauveStone") {
			mauveScore [roundcounter].text = points.ToString ();
			mauvetotal += points;
			mauveScore [10].text = mauvetotal.ToString ();
		}

		scoreboard.SetActive (true);

		roundcounter += 1;
		if (roundcounter < rounds) {
			init ();
			Inning ();
		}
		else {
			endGame ();
		}

	}

	List<GameObject> sortStones()
	{
		List<GameObject> sortedStones = stones;
		GameObject selStone;
		int counter;

		for (int i = 0; i < stonelength; i++) {
			selStone = sortedStones [i];
			counter = i;
			for (int j = i+1; j < stonelength-1; j++) {
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
