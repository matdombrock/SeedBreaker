using System.Collections;
//using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChallengeMenu : MonoBehaviour {
	public Text seed;
	public int setSeed = 0;
	public Text scores;
	public Text coins;
	public Text pay;
	public Dropdown dataSelection;

	public Text playerBestText;
	// Use this for initialization
	IEnumerator Start(){
		if (PlayerPrefs.HasKey ("CustomSeed")) {
			PlayerPrefs.DeleteKey ("CustomSeed");
		}
		coins.text = PlayerPrefs.GetInt("total_coins")+"c";
		PlayerPrefs.SetString ("GameMode","arcade");

		string url = "https://mzero.space/lab/LR/LB/api/sbapi.php?q=seed";
		WWW www = new WWW(url);
		yield return www;
		seed.text = www.text;
		setSeed = int.Parse(www.text);
		StartCoroutine ("getScores");
		if (PlayerPrefs.HasKey ("LastChallengeSeed")) {
			if (PlayerPrefs.GetInt ("LastChallengeSeed") != setSeed) {
				PlayerPrefs.DeleteKey ("OnlineHighScore");
				PlayerPrefs.DeleteKey ("OnlineHighSpeed");
				PlayerPrefs.DeleteKey ("OnlineHighCombo");
			}
		} else {
			PlayerPrefs.DeleteKey ("OnlineHighScore");
			PlayerPrefs.DeleteKey ("OnlineHighSpeed");
			PlayerPrefs.DeleteKey ("OnlineHighCombo");
		}
		PlayerPrefs.SetInt ("LastChallengeSeed",setSeed);


	}
	public IEnumerator getScores(){
		string url = "https://mzero.space/lab/LR/LB/api/sbapi.php?q=scores&s="+setSeed.ToString();
		WWW www = new WWW(url);
		yield return www;
		scores.text = www.text;
		playerBestText.text = PlayerPrefs.GetInt ("OnlineHighScore").ToString ();
	}
	public IEnumerator getCombos(){
		string url = "https://mzero.space/lab/LR/LB/api/sbapi.php?q=combos&s="+setSeed.ToString();
		WWW www = new WWW(url);
		yield return www;
		scores.text = www.text;
		playerBestText.text = PlayerPrefs.GetInt ("OnlineHighCombo").ToString ()+"X";
	}
	public IEnumerator getSpeeds(){
		string url = "https://mzero.space/lab/LR/LB/api/sbapi.php?q=speeds&s="+setSeed.ToString();
		WWW www = new WWW(url);
		yield return www;
		scores.text = www.text;
		playerBestText.text = PlayerPrefs.GetFloat ("OnlineHighSpeed").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		//print (Environment.UserName);E
		//Environment.
	}
	public void StartGame(){
		if(100 <= PlayerPrefs.GetInt("total_coins")){
			int new_coins = PlayerPrefs.GetInt("total_coins") - 100;
			PlayerPrefs.SetInt("total_coins",new_coins);
			PlayerPrefs.SetInt ("CustomSeed", setSeed);
			PlayerPrefs.SetString ("GameMode", "challenge");
			Application.LoadLevel ("main");
		}else{
			pay.text = "You don't have enough coins!\n It costs 100 coins to play online!";
		}

	}

	public void SelectData(){
		switch (dataSelection.value) {
		case (0):
			StartCoroutine ("getScores");
			break;
		case (1):
			StartCoroutine ("getSpeeds");
			break;
		case (2):
			StartCoroutine ("getCombos");
			break;
		}
	}
}
