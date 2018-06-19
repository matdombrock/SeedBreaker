using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//kind of a strange script, not exactly sure what I was thinking here but it works for
//loading the models both in the selection screen and in game. 

//lock happens on selection screen, cant move forward if asset is locked
public class ModelManager : MonoBehaviour {
	public bool isSelectScreen = false;
	public CanvasGroup locked;
	public Text costText;
	public Text coins;

	public int ua_cost;
	public string ua_string;

	public string model = "cube";

	public int avatarNum;

	public GameObject cube;
	public GameObject chicken;
	public GameObject packdude;
	public GameObject ship1;
	public GameObject ship2;
	public GameObject ship3;
	public GameObject ship4;
	public GameObject ship5;
	public GameObject ship6;
	public GameObject ship7;
	public GameObject ufo;
	public GameObject unicorn;


	public GameObject explosion;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("PlayerAvatar")){
			model = PlayerPrefs.GetString("PlayerAvatar");
			avatarNum = PlayerPrefs.GetInt("AvatarNum");
			Debug.Log("PLAYER AVATAR: "+PlayerPrefs.GetString("PlayerAvatar"));
		}else{
			Debug.Log("No player avatar set");
			PlayerPrefs.SetString("PlayerAvatar","ship1");
			model = "ship1";
			avatarNum = 1;
		}
		if(isSelectScreen){
			//selection.value = avatarNum;
		}
		SelectModel();
		print("STARTING avatarNum: "+avatarNum);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void NextModel(){
		avatarNum = avatarNum+1;
		if(avatarNum >11){//needs to match total number of avatars
			avatarNum = 0;
		}
		SelectModel();
		print("avatarNum: "+avatarNum);
	}

	public void Unlock(){
		print("unlock: "+ua_cost);
		if(ua_cost <= PlayerPrefs.GetInt("total_coins")){
			PlayerPrefs.SetString(ua_string,"unlocked");
			
			Instantiate(explosion,transform.position, transform.rotation);
			int new_coins = PlayerPrefs.GetInt("total_coins") - ua_cost;
			PlayerPrefs.SetInt("total_coins",new_coins);
			SelectModel();
		}
		
	}
	public void ShowLock(int item_cost,string model_name){
		locked.alpha = 1.0f;
		locked.interactable = true;
		locked.blocksRaycasts = true;
		costText.text = "-"+item_cost.ToString()+"c-";
		ua_cost=item_cost;
		ua_string="ua_"+model_name;
	}
	public void SelectModel(){
		//SELECTSCREEN
		
		if(isSelectScreen){
			locked.alpha = 0.0f;
			locked.interactable = false;
			locked.blocksRaycasts = false;
			switch(avatarNum){
				case 0:
					model = "cube";
					PlayerPrefs.SetString("PlayerAvatar","cube");
					PlayerPrefs.SetInt("AvatarNum",0);
					break;
				case 1:
					model = "ship1";
					PlayerPrefs.SetString("PlayerAvatar","ship1");
					PlayerPrefs.SetInt("AvatarNum",1);
					break;
				case 2:
					model = "packdude";
					if(PlayerPrefs.GetString("ua_packdude")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","packdude");
						PlayerPrefs.SetInt("AvatarNum",2);
					}else{
						ShowLock(450,model);
					}
					break;
				case 3:
					model = "ufo";
					if(PlayerPrefs.GetString("ua_ufo")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","ufo");
						PlayerPrefs.SetInt("AvatarNum",3);
					}else{
						ShowLock(100,model);
					}
					break;
				case 4:
					model = "ship3";
					if(PlayerPrefs.GetString("ua_ship3")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","ship3");
						PlayerPrefs.SetInt("AvatarNum",4);
					}else{
						ShowLock(10000,model);
					}
					break;
				case 5:
					model = "ship4";
					if(PlayerPrefs.GetString("ua_ship4")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","ship4");
						PlayerPrefs.SetInt("AvatarNum",5);
					}else{
						ShowLock(5000,model);
					}
					break;
				case 6:
					model = "unicorn";
					if(PlayerPrefs.GetString("ua_unicorn")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","unicorn");
						PlayerPrefs.SetInt("AvatarNum",6);
					}else{
						ShowLock(6000,model);
					}
					break;
				case 7:
					model = "ship5";
					if(PlayerPrefs.GetString("ua_ship5")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","ship5");
						PlayerPrefs.SetInt("AvatarNum",7);
					}else{
						ShowLock(8000,model);
					}
					break;
				case 8:
					model = "ship2";
					if(PlayerPrefs.GetString("ua_ship2")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","ship2");
						PlayerPrefs.SetInt("AvatarNum",8);
					}else{
						ShowLock(10000,model);
					}
					break;
				case 9:
					model = "chicken";
					if(PlayerPrefs.GetString("ua_chicken")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","chicken");
						PlayerPrefs.SetInt("AvatarNum",9);
					}else{
						ShowLock(100000,model);
					}
					break;
				case 10:
					model = "ship6";
					if(PlayerPrefs.GetString("ua_ship6")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","ship6");
						PlayerPrefs.SetInt("AvatarNum",10);
					}else{
						ShowLock(8000,model);
					}
					break;
				case 11:
					model = "ship7";
					if(PlayerPrefs.GetString("ua_ship7")=="unlocked"){
						PlayerPrefs.SetString("PlayerAvatar","ship7");
						PlayerPrefs.SetInt("AvatarNum",11);
					}else{
						ShowLock(8000,model);
					}
					break;
			}
			coins.text = PlayerPrefs.GetInt("total_coins").ToString()+"c";
		}
		GameObject mod;
		foreach (Transform child in transform)
         {
             if(child.gameObject.tag!="light"){
             		Destroy(child.gameObject);
         	}
         }
		switch(model){
			case "cube":
				mod = Instantiate(cube,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "chicken":
				mod = Instantiate(chicken,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "packdude":
				mod = Instantiate(packdude,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "ship1":
				mod = Instantiate(ship1,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "ufo":
				mod = Instantiate(ufo,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;

			case "ship3":
				mod = Instantiate(ship3,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "ship4":
				mod = Instantiate(ship4,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "unicorn":
				mod = Instantiate(unicorn,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "ship5":
				mod = Instantiate(ship5,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "ship6":
				mod = Instantiate(ship6,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "ship7":
				mod = Instantiate(ship7,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
			case "ship2":
				mod = Instantiate(ship2,transform.position,transform.rotation);
				mod.transform.parent = gameObject.transform;
				break;
		}
	}
}
