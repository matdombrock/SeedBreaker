using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FREEMONEY : MonoBehaviour {
	public int SKRILL = 100000;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("total_coins",SKRILL);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
