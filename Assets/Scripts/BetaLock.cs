using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BetaLock : MonoBehaviour {
	public bool BetaLocked = true;
	int LockNumber = 4;
	public Text status;
	public Text message;
	public Text updated;
	public CanvasGroup updatebutton;
	// Use this for initialization
	IEnumerator Start() {
		Debug.Log (LockNumber);
		//check version
		if (PlayerPrefs.HasKey ("Version")) {
			if (PlayerPrefs.GetInt ("Version") < LockNumber) {
				PlayerPrefs.DeleteAll();
				Debug.Log ("deleted all keys because of new version");
				updated.enabled = true;
			}
		} else {
			PlayerPrefs.DeleteAll();
			Debug.Log ("deleted all keys because of missing version");
		}
		PlayerPrefs.SetInt ("Version",LockNumber);
		yield return new WaitForSeconds(5);
		string url = "https://mzero.space/lab/LR/LB/api/sbapi.php?q=betalock";
		WWW www = new WWW(url);
		yield return www;
		if (int.Parse (www.text) <= LockNumber) {
			status.text = "unlocked";
			message.text = "Press anything to continue";
			BetaLocked = false;
		} else {
			status.text = "locked";
			message.text = "Please update the game";
			updatebutton.alpha = 1.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (BetaLocked == false && Input.anyKey) {
			Application.LoadLevel ("mycelium");
		}
	}
	public void UpdateGame(){
		Application.OpenURL("https://mycelium.itch.io/seedbreaker");
	}
}
