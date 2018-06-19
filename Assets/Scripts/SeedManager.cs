using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour {
	//public bool customSeed = false;
	public int setSeed = 1;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("CustomSeed")) {
			Random.seed = PlayerPrefs.GetInt("CustomSeed");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
