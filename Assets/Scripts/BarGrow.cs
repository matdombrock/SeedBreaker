using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGrow : MonoBehaviour {
	public float size = 100.0f;
	public float max = 120.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (size < max) {
			
			GetComponent<RectTransform> ().sizeDelta = Vector2.Lerp (GetComponent<RectTransform> ().sizeDelta , new Vector2(max,100), Time.deltaTime*0.5f);
			size = GetComponent<RectTransform> ().sizeDelta.x;
		}
		//transform.localScale = new Vector3 (transform.localScale.x*size, transform.localScale.y, transform.localScale.z);
	}
}
