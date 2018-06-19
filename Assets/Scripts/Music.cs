using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		GameObject[] musics = GameObject.FindGameObjectsWithTag ("music");
		if (musics.Length > 1) {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("MusicOn")) {
			if (PlayerPrefs.GetString ("MusicOn") == "false") {
				GetComponent<AudioSource> ().volume = 0.0f;
			} else {
				GetComponent<AudioSource> ().volume = 1.0f;
			}
		}
	}
}
