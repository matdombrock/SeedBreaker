using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Back(){
		if(PlayerPrefs.GetString ("PlayerName")!="name"){
			Application.LoadLevel ("Start");
		}
	}
}
