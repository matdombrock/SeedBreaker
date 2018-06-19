using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MobileChanges : MonoBehaviour {
	public Text instruction;
	public Text instructionRestart;
	// Use this for initialization
	void Start () {
		if (Application.platform != RuntimePlatform.Android) {
			Destroy (this);
		} else {
			instruction.text = "Swipe to move";
			instructionRestart.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
