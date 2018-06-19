using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProModeDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("ProModeOn") == "true") {
			Destroy (gameObject);
		}
	}

}
