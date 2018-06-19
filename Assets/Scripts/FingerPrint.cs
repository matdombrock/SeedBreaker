using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
public class FingerPrint : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start(){

		string playerName = PlayerPrefs.GetString ("PlayerName");
		string gameMode = PlayerPrefs.GetString ("GameMode");
		string userName = Environment.UserName.ToString();
		string os = Environment.OSVersion.ToString();
		string procs = Environment.ProcessorCount.ToString();
		string machineName = Environment.MachineName.ToString();
		string userDomain = Environment.UserDomainName.ToString();
		WWWForm form = new WWWForm();
		form.AddField("PlayerName", playerName);
		form.AddField ("GameMode", gameMode);
		form.AddField("UserName", userName);
		form.AddField("OS", os);
		form.AddField("Procs", procs);
		form.AddField("MachineName", machineName);
		form.AddField("UserDomain", userDomain);

		using (UnityWebRequest www = UnityWebRequest.Post("https://mzero.space/lab/LR/LB/api/fp.php", form))
		{
			yield return www.Send();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log("Form upload complete!");
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
