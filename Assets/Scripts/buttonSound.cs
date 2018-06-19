using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonSound : MonoBehaviour {
	public AudioSource sound_2;
	public AudioSource sound_3;
	public void sound(){
		GetComponent<AudioSource>().Play();
	}
	public void sound2(){
		sound_2.GetComponent<AudioSource>().Play();
	}
	public void sound3(){
		sound_3.GetComponent<AudioSource>().Play();
	}
}
