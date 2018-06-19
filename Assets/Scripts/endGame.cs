using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class endGame : MonoBehaviour {
	public Text t;
	private List<string> info = new List<string>();
	public int i =0;
	
	// Use this for initialization
	void Start () {
		info.Add("You were never supposed to get this far");
		info.Add("...");
		info.Add("Well...");
		info.Add("Hmm...");
		info.Add("I guess you should email me?");
		info.Add("I mean, I don't know. You are really good at this game...");
		info.Add("I just... I guess you win?");
		info.Add("This should not have happened. I mean really, this is a bit of an easter egg here of course but you were honestly never supposed to see this. The levels are not infinite but I always figured that by the time anyone got anywhere near the end of the level they would be going way to fast to actually finish. If you are reading this please let me know so I can increase the level size and prevent this in the future. The special code phrase to let me know you saw this screen is 'I beat the game'");
		info.Add("I hope you were not playing online...");
		info.Add("Well, goodbye.");
		info.Add("");
		info.Add("");
		info.Add("");
		info.Add(".");
		info.Add("");
		info.Add("");
		info.Add("");
		info.Add("Oh you are still here?");
		info.Add("Ok then...");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown){
			t.text = info[i];
			i = i+1;
		}
		if(i>18){
			i=9;
		}
	}
}
