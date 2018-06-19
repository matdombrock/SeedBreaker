using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Next",2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Next(){
		if (PlayerPrefs.HasKey ("PlayerName") && PlayerPrefs.GetString("PlayerName")!="name") {
			Application.LoadLevel ("start");
		} else {
			Application.LoadLevel ("name");
		}
	}
}
