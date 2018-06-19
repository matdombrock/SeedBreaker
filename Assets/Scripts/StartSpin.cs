using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody>().AddTorque(transform.right * 1);
		gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * 6);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
