using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorMan : MonoBehaviour {
	public Color mainColor;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("color_R")){
			mainColor.r = PlayerPrefs.GetFloat("color_R");
		}else{
			mainColor.r = 1.0f;
		}
		if(PlayerPrefs.HasKey("color_G")){
			mainColor.g = PlayerPrefs.GetFloat("color_G");
		}else{
			mainColor.g = 0.0f;
		}
		if(PlayerPrefs.HasKey("color_B")){
			mainColor.b = PlayerPrefs.GetFloat("color_B");
		}
		else{
			mainColor.b = 0.0f;
		}
		//RenderSettings.ambientLight = mainColor	;
	}
	public void SaveColor(Color newColor){
		print(newColor);
		PlayerPrefs.SetFloat("color_R",newColor.r);
		PlayerPrefs.SetFloat("color_G",newColor.g);
		PlayerPrefs.SetFloat("color_B",newColor.b);
	}
}
