using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("SoundOn")) {
			if (PlayerPrefs.GetString ("SoundOn") == "false") {
				GetComponent<AudioSource> ().volume = 0.0f;
			} else {
				GetComponent<AudioSource> ().volume = 1.0f;
			}
		}
	}
}
