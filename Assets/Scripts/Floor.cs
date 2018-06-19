using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
	bool dropping = false;
	public IEnumerator Drop(){
		//print ("DROP");
		yield return new WaitForSeconds (1);
		Destroy (gameObject, 5);
		GetComponent<Rigidbody> ().useGravity = true;
		GetComponent<Rigidbody> ().isKinematic = false;
		//Destroy (this);
	}
	public void StartDrop(){
		if (!dropping) {
			StartCoroutine (Drop ());
			dropping = true;
		}
	}
}
