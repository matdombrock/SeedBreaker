using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NameInput : MonoBehaviour {
	public Button enter;
	public InputField input;
	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("PlayerName")) {
			PlayerPrefs.SetString ("PlayerName","name");
		}
		input.text = PlayerPrefs.GetString ("PlayerName");
	}
	
	// Update is called once per frame
	void Update () {
		if (input.text.Length > 7) {
			input.text = input.text.Substring (0, 7);
		}
	}
	public void Submit(){
		if (input.text != "name") {
			PlayerPrefs.SetString ("PlayerName", input.text);
			print ("Set Player name to " + PlayerPrefs.GetString ("PlayerName"));
			Application.LoadLevel ("start");
		} else {
			print ("failed to set player name");
		}
	}
}
