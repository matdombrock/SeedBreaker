using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour {
	//TRACK STATS
	//NODES COLLECTED & BEST
	//TOP SPEED & BEST
	//MAX COMBO & BEST
	//
	//DISPLAY SEED AT LAUNCH
	//
	//ADD SEED INPUT

	public CanvasGroup uiInGame;
	public CanvasGroup uiDeathScreen;
	public CanvasGroup uiHighScore;
	public CanvasGroup uiStartText;
	public CanvasGroup uiPause;

	public GameObject restartButton;

	public CanvasGroup loadingScreen;
	public CanvasGroup fadeout;
	//public string notificationSet = "none";//not really used

	//SET NEW RECORDS?
	public bool ScoreRecord = false;
	public bool SpeedRecord = false;
	public bool ComboRecord = false;


	public Text score;
	public Text bigScore;
	public Text highScore;
	//public Text HighScoreInfo;
	public Text combo;

	public Text coins;
	//public Text instruction;
	//public Text instructionRestart;
	//public Text TopSpeedInfo;
	public Text TopSpeedText;
	//public Text MaxComboInfo;
	public Text MaxComboText;
	//public Text HighSpeedInfo;
	public Text HighSpeedText;
	//public Text HighComboInfo;
	public Text HighComboText;
	public Text notification;

	public Text challengeMarker;

	//public Button restartButton;
	//public Text restartButtonText;
	//public Button mainMenuButton;
	//public Text mainMenuButtonText;
	//public Button settingsButton;
	//public Text settingsButtonText;
	//public Image bigBg;

	public Image comboStar;
	public Image speedStar;
	public Image scoreStar;

	public Text promarker;

	//public Image scoreDiv;

	public Control control;

	public bool saved_coins =false;

	public bool paused = false;

	// Use this for initialization
	void Start () {
		fadeout.alpha = 1.0f;
		InvokeRepeating("UpdateUI", 0.0f, 0.1f);
		StartCoroutine(FadeOut(fadeout));
		if (PlayerPrefs.GetString ("GameMode") == "challenge") {
			Destroy(restartButton);
		}
	}
	IEnumerator FadeIn(CanvasGroup	canvas) {
		while(canvas.alpha < 1.0f){
			canvas.alpha = canvas.alpha +Time.deltaTime;
			yield return null;
		}
	}
	IEnumerator FadeOut(CanvasGroup	canvas) {
		while(canvas.alpha > 0.0f){
			canvas.alpha = canvas.alpha -Time.deltaTime;
			yield return null;
		}
	}		
	public void Resume(){
		paused = false;
	}	
	void Update(){
		if(!control.dead){
			if(Input.GetButtonDown("Pause")){
					paused = !paused;
			}
			if(paused){
				uiPause.alpha = 0.8f;
				uiPause.interactable = true;
				uiPause.blocksRaycasts = true;
				Time.timeScale = 0.0000001f;
				Cursor.visible = true;
			}else{
				uiPause.alpha = 0.0f;
				uiPause.interactable = false;
				uiPause.blocksRaycasts = false;
				Time.timeScale = 1.0f;
				Cursor.visible = false;
			}
		}else{
				Cursor.visible = true;
		}
	}
	// Update is called once per frame
	void UpdateUI () {
		if(!control.dead){
			highScore.text = control.HighScore.ToString ();
			combo.text = control.comboAmt.ToString()+"X";
			score.text = Mathf.RoundToInt(control.Score).ToString ();
			bigScore.text = "";
			
			//notification.text = "";
			/*
			combo.enabled = true;
			instruction.enabled = true;
			scoreDiv.enabled = true;
			*/
			uiStartText.alpha = 1.0f;
			uiHighScore.alpha = 1.0f;
			uiDeathScreen.alpha = 0.0f;
			uiDeathScreen.blocksRaycasts = false;
			uiInGame.alpha = 0.0f;

			/*
			bigBg.enabled = false;
			instructionRestart.enabled = false;
			restartButton.image.enabled = false;
			restartButtonText.enabled = false;
			mainMenuButton.image.enabled = false;
			mainMenuButtonText.enabled = false;
			settingsButton.image.enabled = false;
			settingsButtonText.enabled = false;
			TopSpeedInfo.enabled = false;
			TopSpeedText.enabled = false;
			MaxComboInfo.enabled = false;
			MaxComboText.enabled = false;
			HighSpeedInfo.enabled = false;
			HighSpeedText.enabled = false;
			HighComboInfo.enabled = false;
			HighComboText.enabled = false;
		*/
			scoreStar.enabled = false;
			comboStar.enabled = false;
			speedStar.enabled = false;






			notification.text = "";

			//need to have online versions swap

			//calculates new records in real time

			//check new scores arcade
			if (PlayerPrefs.GetString ("GameMode") == "arcade") {
				if (PlayerPrefs.HasKey ("HighScore")) {
					if (PlayerPrefs.GetInt ("HighScore") < control.Score) {
						notification.text += "NEW HIGH SCORE \n";
						ScoreRecord = true;
					}
				} 
				if (PlayerPrefs.HasKey ("HighCombo")) {
					if (PlayerPrefs.GetInt ("HighCombo") < control.comboAmt || PlayerPrefs.GetInt ("HighCombo") < control.maxCombo) {
						notification.text += "NEW COMBO RECORD \n";
						ComboRecord = true;
					}
				}
				if (PlayerPrefs.HasKey ("HighSpeed")) {
					if (PlayerPrefs.GetFloat ("HighSpeed") < control.speed) {
						notification.text += "NEW Speed RECORD";
						SpeedRecord = true;
					}
				}
			}
			if (PlayerPrefs.GetString ("GameMode") == "challenge") {
				if (PlayerPrefs.HasKey ("OnlineHighScore")) {
					if (PlayerPrefs.GetInt ("OnlineHighScore") < control.Score) {
						notification.text += "NEW HIGH SCORE \n";
						ScoreRecord = true;
					}
				} 
				if (PlayerPrefs.HasKey ("OnlineHighCombo")) {
					if (PlayerPrefs.GetInt ("OnlineHighCombo") < control.comboAmt || PlayerPrefs.GetInt ("OnlineHighCombo") < control.maxCombo) {
						notification.text += "NEW COMBO RECORD \n";
						ComboRecord = true;
					}
				}
				if (PlayerPrefs.HasKey ("OnlineHighSpeed")) {
					if (PlayerPrefs.GetFloat ("OnlineHighSpeed") < control.speed) {
						notification.text += "NEW Speed RECORD";
						SpeedRecord = true;
					}
				}
			}

			//challenge marker
			if (PlayerPrefs.GetString ("GameMode") == "challenge") {
				challengeMarker.enabled = true;
			} else {
				challengeMarker.enabled = false;
			}

			//check pro mode
			if (PlayerPrefs.GetString ("ProModeOn") == "true") {
				promarker.enabled = true;
				notification.text = "";
			} else {
				promarker.enabled = false;
			}

			//gameplay has started
			if (control.direction != "") {
				uiInGame.alpha = 1.0f;
				uiHighScore.alpha = 0.0f;
				uiStartText.alpha = 0.0f;
				/*
				highScore.enabled = false;
				HighScoreInfo.enabled = false;
				instruction.enabled = false;
				promarker.enabled = false;
				*/
			}
			//player has died
		}
		if (control.dead) {
			if (ScoreRecord) {
				scoreStar.enabled = true;
			}
			if (ComboRecord) {
				comboStar.enabled = true;
			}
			if (SpeedRecord) {
				speedStar.enabled = true;
			}
			uiInGame.alpha = 0.0f;
			uiStartText.alpha = 0.0f;
			//uiDeathScreen.alpha = 1.0f;
			uiDeathScreen.blocksRaycasts = true;
			uiHighScore.alpha = 1.0f;
			/*
			scoreDiv.enabled = false;
			combo.enabled = false;

			TopSpeedInfo.enabled = true;
			TopSpeedText.enabled = true;
			MaxComboInfo.enabled = true;
			MaxComboText.enabled = true;
			HighSpeedInfo.enabled = true;
			HighSpeedText.enabled = true;
			HighComboInfo.enabled = true;
			HighComboText.enabled = true;
			restartButton.image.enabled = true;
			restartButtonText.enabled = true;
			mainMenuButton.image.enabled = true;
			mainMenuButtonText.enabled = true;
			settingsButton.image.enabled = true;
			settingsButtonText.enabled = true;
			bigBg.enabled = true;
			highScore.enabled = true;
			HighScoreInfo.enabled = true;
			instructionRestart.enabled = true;
			*/
			int earned_coins = Mathf.RoundToInt (control.Score/100);
			if(saved_coins == false){
				if (PlayerPrefs.GetString ("GameMode") == "arcade") {
					print("earned_coins="+earned_coins);
					int new_coins = PlayerPrefs.GetInt("total_coins")+earned_coins;
					PlayerPrefs.SetInt("total_coins",new_coins);
					print("new_coins="+PlayerPrefs.GetInt("total_coins"));
					coins.text = "+"+earned_coins.ToString ()+"c";
				}else{
					coins.text = "";
				}
				
				saved_coins = true;
				
				StartCoroutine(FadeIn(uiDeathScreen));
			}

			notification.text = "";
			score.text = "";

			TopSpeedText.text = control.speed.ToString();
			MaxComboText.text = control.maxCombo.ToString();
			HighSpeedText.text = control.HighSpeed.ToString ();
			HighComboText.text = control.HighCombo.ToString ();

			bigScore.text = Mathf.RoundToInt (control.Score).ToString ();
			
			highScore.text = control.HighScore.ToString ();

			
		}
	}

	//buttons
	public void Restart(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Time.timeScale = 1.0f;
		Application.LoadLevel (Application.loadedLevel);
	}
	public void MainMenu(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("Start");
	}
	public void Settings(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("settings");
	}
	public void Custom(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("custom");
	}
}
