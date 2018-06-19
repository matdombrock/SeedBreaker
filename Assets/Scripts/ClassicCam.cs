using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicCam : MonoBehaviour {
	public bool useClassic = false;
	public bool useSuper = false;
	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("camera")) {
			PlayerPrefs.SetString ("camera", "default");
		}
		if(PlayerPrefs.GetString("camera")=="classic" || useClassic==true){
			gameObject.transform.position = new Vector3(0,23,-3);
			gameObject.transform.eulerAngles = new Vector3(78,0,0);
		}
		if(PlayerPrefs.GetString("camera")=="super" || useSuper==true){
			gameObject.transform.position = new Vector3(0,3,-6);
			gameObject.transform.eulerAngles = new Vector3(0,0,0);
		}
	}
	
}
