using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingTips : MonoBehaviour {
	public List<string> tips = new List<string>();
	// Use this for initialization
	void Start () {
		tips.Add("Pro Mode removes unnecessary distractions");
		tips.Add("Pro Mode can also help performance");
		tips.Add("You can change the color scheme in settings");
		tips.Add("Come join us in Discord Chat!");
		tips.Add("Thanks for playing!");
		tips.Add("Make sure to hit as many super-seeds as possible");
		tips.Add("In arcade mode you will play a new 'seed' or level each time");
		tips.Add("Remember, it's just a game");
		tips.Add("Try taking a break at least every hour");
		tips.Add("Eat your veggies for max scores");
		tips.Add("Just one more game");
		tips.Add("Even if you are not great at high score you can still compete for speed and combos");
		tips.Add("Combos are the key to the ultimate high score");
		tips.Add("Stay on the track or you will die");
		tips.Add("Avatars do not affect game-play in any way");
		tips.Add("Your earned coins are roughly 1% of your high score");
		tips.Add("The best players plan their route way ahead of time");
		tips.Add("You can change the camera angle in the settings menu");
		tips.Add("Online challenge mode features a new 'seed' or level each day");
		tips.Add("Earn coins by playing");
		tips.Add("Coins can be used to unlock new avatars");
		tips.Add("You can pause the game while in the middle of a session if you need to");
		int roll = Random.Range( 0, tips.Count );
		gameObject.GetComponent<Text>().text ="TIP: "+ tips[roll];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
