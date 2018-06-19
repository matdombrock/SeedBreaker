using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
public class DeathEffect : MonoBehaviour {
	public Control control;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(control.dead){
		 gameObject.GetComponent<VignetteAndChromaticAberration>().chromaticAberration=gameObject.GetComponent<VignetteAndChromaticAberration>().chromaticAberration+50*Time.deltaTime;
		}
	}
}
