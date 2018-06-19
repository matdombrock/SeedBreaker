using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour {
	public Text music;
	public Text sound;
	public Text promode;

	public Image block_default;
	public Image block_super;
	public Image block_classic;

	public bool pmodetest = false;
	// Use this for initialization
	void Start () {
		
		if (!PlayerPrefs.HasKey ("camera")) {
			PlayerPrefs.SetString ("camera", "default");
			block_classic.enabled = false;
			block_super.enabled = false;
			block_default.enabled = true;
		}else{
			if(PlayerPrefs.GetString("camera")=="default"){
				block_classic.enabled = false;
				block_super.enabled = false;
				block_default.enabled = true;
			}
			if(PlayerPrefs.GetString("camera")=="super"){
				block_classic.enabled = false;
				block_super.enabled = true;
				block_default.enabled = false;
			}
			if(PlayerPrefs.GetString("camera")=="classic"){
				block_classic.enabled = true;
				block_super.enabled = false;
				block_default.enabled = false;
			}
		}

		if (!PlayerPrefs.HasKey ("MusicOn")) {
			PlayerPrefs.SetString ("MusicOn", "true");
		}
		if (!PlayerPrefs.HasKey ("SoundOn")) {
			PlayerPrefs.SetString ("SoundOn", "true");
		}
		if (!PlayerPrefs.HasKey ("ProModeOn")) {
			PlayerPrefs.SetString ("ProModeOn", "false");
		}
		if (PlayerPrefs.GetString ("MusicOn") == "true") {
			//PlayerPrefs.SetString ("MusicOn", "false");
			music.text = "Turn off music";
		} else {
			music.text = "Turn on music";
		}
		if (PlayerPrefs.GetString ("SoundOn") == "true") {
			//PlayerPrefs.SetString ("SoundOn", "false");
			sound.text = "turn off sound";
		} else {
			sound.text = "turn on sound";
		}
		if (PlayerPrefs.GetString ("ProModeOn") == "true") {
			//PlayerPrefs.SetString ("SoundOn", "false");
			promode.text = "turn off pro-mode";
		} else {
			promode.text = "turn on pro-mode";
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetString ("ProModeOn") == "true") {
			pmodetest = true;
		} else {
			pmodetest = false;
		}
		
	}
	public void CamDefault(){
		PlayerPrefs.SetString("camera","default");
		block_classic.enabled = false;
		block_super.enabled = false;
		block_default.enabled = true;
	}
	public void CamSuper(){
		PlayerPrefs.SetString("camera","super");
		block_classic.enabled = false;
		block_default.enabled = false;
		block_super.enabled = true;
	}
	public void CamClassic(){
		PlayerPrefs.SetString("camera","classic");
		block_super.enabled = false;
		block_default.enabled = false;
		block_classic.enabled = true;
	}
	public void RenderCamButtons(){
		string key = PlayerPrefs.GetString("camera");
		if(key=="default"){

		}
	}
	public void ToggleMusic(){
		if (PlayerPrefs.GetString ("MusicOn") == "true") {
			PlayerPrefs.SetString ("MusicOn", "false");
			music.text = "Turn on music";
		} else {
			PlayerPrefs.SetString ("MusicOn", "true");
			music.text = "Turn off music";
		}
	}
	public void ToggleSound(){
		if (PlayerPrefs.GetString ("SoundOn") == "true") {
			PlayerPrefs.SetString ("SoundOn", "false");
			sound.text = "turn on sound";
		} else {
			PlayerPrefs.SetString ("SoundOn", "true");
			sound.text = "turn off sound";
		}
	}
	public void ToggleProMode(){
		print (PlayerPrefs.GetString ("ProModeOn"));
		if (PlayerPrefs.GetString ("ProModeOn") == "true") {
			PlayerPrefs.SetString ("ProModeOn", "false");
			promode.text = "turn on pro-mode";
		} else {
			PlayerPrefs.SetString ("ProModeOn", "true");
			promode.text = "turn off pro-mode";
		}
	}
	public void Back(){
		Application.LoadLevel ("Start");
	}
	public void Colors(){
		Application.LoadLevel ("color");
	}
	public void Clear(){
		PlayerPrefs.DeleteAll ();
		Application.LoadLevel ("beta");
	}
}
