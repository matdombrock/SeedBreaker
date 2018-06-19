using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class colorPicker : MonoBehaviour {
	public Slider red;
	public Slider green;
	public Slider blue;
	//public Image preview;
	public Color color;

	public Dropdown presets;

	public ColorMan colman;
	// Use this for initialization
	void Start () {
		
		colman = GameObject.Find("ColorMan").GetComponent<ColorMan>();
		color = colman.mainColor;
		red.value = colman.mainColor.r;
		green.value = colman.mainColor.g;
		blue.value = colman.mainColor.b;
		color.a = 1.0f;
		UpdateColor();
	}
	public void change_slider(){
		presets.value = 0;
		UpdateColor();
	}
	// Update is called once per frame
	public void UpdateColor () {
		
		color.r = red.value;
		color.g = green.value;
		color.b = blue.value;

		gameObject.GetComponent<Image>().color = color;
		colman.SaveColor(color);
		//presets.value = 0;
	}
	public void randomize(){
		red.value = Random.Range(0.0f,1.0f);
		green.value = Random.Range(0.0f,1.0f);
		blue.value = Random.Range(0.0f,1.0f);
		UpdateColor	();
	}

	public void preset_change(){
		print("preset: "+presets.value);
		int cache_val = presets.value;
		if(presets.value ==0){

		}
		if(presets.value ==1){//red
			red.value = 1.0f;
			green.value = 0.0f;
			blue.value = 0.0f;
		}
		if(presets.value ==2){//green
			red.value = 0.0f;
			green.value = 1.0f;
			blue.value = 0.0f;
		}
		if(presets.value ==3){//blue
			red.value = 0.0f;
			green.value = 0.0f;
			blue.value = 1.0f;
		}
		if(presets.value ==4){//cyan
			red.value = 0.0f;
			green.value = 1.0f;
			blue.value = 1.0f;
		}
		if(presets.value ==5){//purple
			red.value = 1.0f;
			green.value = 0.0f;
			blue.value = 1.0f;
		}
		if(presets.value ==6){//yellow
			red.value = 1.0f;
			green.value = 1.0f;
			blue.value = 0.0f;
		}
		if(presets.value ==7){//white
			red.value = 0.8f;
			green.value = 0.8f;
			blue.value = 0.8f;
		}
		UpdateColor	();
		presets.value = cache_val;
	}
}
