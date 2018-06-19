using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Control : MonoBehaviour {
	public float speed = 1.0f;
	public string direction = "";
	public float speedIncrease = 1.01f;
	public float Score = 0.0f;
	public int HighScore;
	public int HighCombo;
	public float HighSpeed;
	public bool dead = false;

	public float comboTimer = 1.0f;
	public int comboAmt=0;
	public int maxCombo =0;

	public GameObject explosion;
	public GameObject pointexplosion;

	public AudioSource pointSound;
	public AudioSource superSound;
	public AudioSource moveSound;
	public AudioSource deathSound;

	public GameObject Model;

	public CanvasManager canvas;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("GameMode") == "arcade") {
			if (PlayerPrefs.HasKey ("HighScore")) {
				HighScore = PlayerPrefs.GetInt ("HighScore");
			} else {
				HighScore = 0;
			}
		}
		if (PlayerPrefs.GetString ("GameMode") == "challenge") {
			if (PlayerPrefs.HasKey ("OnlineHighScore")) {
				HighScore = PlayerPrefs.GetInt ("OnlineHighScore");
			} else {
				HighScore = 0;
			}
		}
		if (!PlayerPrefs.HasKey ("ProModeOn")) {
			PlayerPrefs.SetString("ProModeOn", "false");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (dead) {
			if (Input.GetButton ("Restart")) {
				Restart ();
			}
			return;
		}
		if(canvas.paused){
			return;
		}
		if (Input.GetButtonDown ("Up")) {
			direction = "up";
			moveSound.Play ();
		}
		if (Input.GetButtonDown ("Down")) {
			direction = "down";
			moveSound.Play ();
		}
		if (Input.GetButtonDown ("Right")) {
			direction = "right";
			moveSound.Play ();
		}
		if (Input.GetButtonDown ("Left")) {
			direction = "left";
			moveSound.Play ();
		}
		switch (direction) {
		case ("up"):
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
			Model.transform.eulerAngles = new Vector3(0,0,0);
			break;
		case ("down"):
			transform.Translate (-Vector3.forward * Time.deltaTime * speed);
			Model.transform.eulerAngles = new Vector3(0,180.0f,0);
			break;
		case ("right"):
			transform.Translate (Vector3.right * Time.deltaTime * speed);
			Model.transform.eulerAngles = new Vector3(0,90.0f,0);
			break;
		case ("left"):
			transform.Translate (-Vector3.right * Time.deltaTime * speed);
			Model.transform.eulerAngles = new Vector3(0,-90.0f,0);
			break;
		}


	}
	void ScoreUp(int amt){
		if (!dead) {
			Score = (Score + amt * (speed / 100));
		}
	}
	void FixedUpdate(){
		if (comboTimer > 0) {
			comboTimer = comboTimer - Time.deltaTime* (speed/10);
		} else {
			if (comboAmt > maxCombo) {
				maxCombo = comboAmt;
			}
			comboAmt = 0;

		}
		if (direction != "" && !dead) {//play has started
			speed = speedIncrease * speed;
			ScoreUp (1);
			//Score = Score + 1;
		}
		if (dead) {
			return;
		}
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if (!Physics.Raycast (transform.position, Vector3.down,out hit, 10)) {
			/*
			 * 
			 * 
			 * PLAYER IS DEAD
			 * 
			 */

			//print ("There is something in front of the object!");
			//Application.LoadLevel(Application.loadedLevel);
			dead = true;
			deathSound.Play ();
			Instantiate (explosion,transform.position,transform.rotation);
			if (comboAmt > maxCombo) {
				maxCombo = comboAmt;
			}
			Time.timeScale = 0.4f;

			//calculates new records for saving on death
			if (PlayerPrefs.GetString ("GameMode") == "challenge") {
				
				bool shouldUpload = false;
				if (PlayerPrefs.HasKey ("OnlineHighScore")) {
					if (PlayerPrefs.GetInt ("OnlineHighScore") < Score) {
						PlayerPrefs.SetInt ("OnlineHighScore", Mathf.RoundToInt (Score));
						shouldUpload = true;
					}
				} else {
					PlayerPrefs.SetInt ("OnlineHighScore", Mathf.RoundToInt (Score));
					shouldUpload = true;
				}
				if (PlayerPrefs.HasKey ("OnlineHighCombo")) {
					if (PlayerPrefs.GetInt ("OnlineHighCombo") < maxCombo) {
						PlayerPrefs.SetInt ("OnlineHighCombo", maxCombo);
						shouldUpload = true;
					}
				} else {
					PlayerPrefs.SetInt ("OnlineHighCombo", maxCombo);
					shouldUpload = true;
				}
				if (PlayerPrefs.HasKey ("OnlineHighSpeed")) {
					if (PlayerPrefs.GetFloat ("OnlineHighSpeed") < speed) {
						PlayerPrefs.SetFloat ("OnlineHighSpeed", speed);
						shouldUpload = true;
					}
				} else {
					PlayerPrefs.SetFloat ("OnlineHighSpeed", speed);
					shouldUpload = true;
				}
				HighScore = PlayerPrefs.GetInt ("OnlineHighScore");
				HighSpeed = PlayerPrefs.GetFloat ("OnlineHighSpeed");
				HighCombo = PlayerPrefs.GetInt ("OnlineHighCombo");
				if (shouldUpload == true) {
					StartCoroutine (UploadScore());
				}
			}

			if (PlayerPrefs.GetString ("GameMode") == "arcade") {
				if (PlayerPrefs.HasKey ("HighScore")) {
					if (PlayerPrefs.GetInt ("HighScore") < Score) {
						PlayerPrefs.SetInt ("HighScore", Mathf.RoundToInt (Score));
					}
				} else {
					PlayerPrefs.SetInt ("HighScore", Mathf.RoundToInt (Score));
				}
				if (PlayerPrefs.HasKey ("HighCombo")) {
					if (PlayerPrefs.GetInt ("HighCombo") < maxCombo) {
						PlayerPrefs.SetInt ("HighCombo", maxCombo);
					}
				} else {
					PlayerPrefs.SetInt ("HighCombo", maxCombo);
				}
				if (PlayerPrefs.HasKey ("HighSpeed")) {
					if (PlayerPrefs.GetFloat ("HighSpeed") < speed) {
						PlayerPrefs.SetFloat ("HighSpeed", speed);
					}
				} else {
					PlayerPrefs.SetFloat ("HighSpeed", speed);
				}
				HighScore = PlayerPrefs.GetInt ("HighScore");
				HighSpeed = PlayerPrefs.GetFloat ("HighSpeed");
				HighCombo = PlayerPrefs.GetInt ("HighCombo");
			}

		}else{
			if (direction != "" && hit.transform.gameObject.tag == "floor") {//play has started
				hit.transform.gameObject.GetComponent<Floor>().StartDrop();
			}
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "end"){
			Application.LoadLevel("theend");
		}
		if (collision.gameObject.tag == "Point" || collision.gameObject.tag == "superSeed") {
			pointSound.Play ();
			if (comboTimer >= 0) {
				comboAmt = comboAmt + 1;
			} else {
				comboAmt = 0;
			}
			ScoreUp (comboAmt);
			if(collision.gameObject.tag == "superSeed"){
				ScoreUp (comboAmt*2);
				superSound.Play();
			}



			if (PlayerPrefs.GetString ("ProModeOn") == "false") {
				Destroy (collision.gameObject,0.5f);
				GameObject boom = Instantiate (pointexplosion,transform.position,transform.rotation);
				Destroy (boom,0.75f);
				collision.gameObject.tag = "Untagged";
				collision.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				collision.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * ((speed / 10) + 1.5f));
				collision.gameObject.GetComponent<Collider> ().enabled = false;
			} else {
				Destroy (collision.gameObject);
			}

			comboTimer = 1.0f;
		}
	}
	public void Restart(){
		canvas.Restart ();
	}
	IEnumerator UploadScore()
	{
		WWWForm form = new WWWForm();
		form.AddField("score", Mathf.RoundToInt(Score).ToString());
		Debug.Log ("Score: "+Mathf.RoundToInt(Score).ToString());
		form.AddField("combo", maxCombo.ToString());
		Debug.Log ("Combo: "+maxCombo.ToString());
		form.AddField("speed", speed.ToString());
		Debug.Log ("Speed: "+speed.ToString());
		form.AddField("playername", PlayerPrefs.GetString("PlayerName"));
		Debug.Log ("Player Name: "+PlayerPrefs.GetString("PlayerName"));
		form.AddField("seed", PlayerPrefs.GetInt("CustomSeed"));
		Debug.Log ("Seed: "+PlayerPrefs.GetInt("CustomSeed"));

		using (UnityWebRequest www = UnityWebRequest.Post("https://mzero.space/lab/LR/LB/api/sbapi.php?q=submit", form))
		{
			yield return www.Send();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log("upload worked");
			}
		}
		Debug.Log ("UPLOADED SCORE!");
	}
}
