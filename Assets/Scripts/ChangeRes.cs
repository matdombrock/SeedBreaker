using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRes : MonoBehaviour {

	void Start()
    {
        // Switch to 640 x 480 fullscreen at 60 hz
        Screen.SetResolution(640, 480, true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
