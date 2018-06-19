using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {
	public Text motd;
	public Text name;
	public Text coins;
	public CanvasGroup loadingScreen;
	// Use this for initialization
	IEnumerator Start(){
		Time.timeScale = 1.0f;
		//init some prefs
		if (PlayerPrefs.HasKey ("CustomSeed")) {
			PlayerPrefs.DeleteKey ("CustomSeed");
		}
		if(PlayerPrefs.HasKey("total_coins")){
			print("total coins: "+PlayerPrefs.GetInt("total_coins"));
		}else{
			PlayerPrefs.SetInt("total_coins",0);
		}
		coins.text = PlayerPrefs.GetInt("total_coins").ToString()+"c";
		PlayerPrefs.SetString ("GameMode","arcade");

		//GET MOTD
		string url = "https://mzero.space/lab/LR/LB/api/sbapi.php?q=motd";
		WWW www = new WWW(url);
		yield return www;
		motd.text = www.text;

		name.text = PlayerPrefs.GetString ("PlayerName");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartGame(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("main");
	}
	public void Settings(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("settings");
	}
	public void Help(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("help");
	}
	public void Challenge(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("challenge");
	}
	public void Quit(){
		Application.Quit ();
	}
	public void Custom(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("custom");
	}
	public void NameChange(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("name");
	}
	public void Avatar(){
		loadingScreen.alpha = 1.0f;
		loadingScreen.blocksRaycasts = true;
		Application.LoadLevel ("avatar");
	}
	public void Feedback(){
		Application.OpenURL("https://mycelium.itch.io/seedbreaker");
	}
	public void Discord(){
		Application.OpenURL("httpss://discord.gg/5TuEhQG");
	}
}
