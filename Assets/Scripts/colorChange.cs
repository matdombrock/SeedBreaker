using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class colorChange : MonoBehaviour {
	public ColorMan colman;
	public bool isText = false;
	public bool useOutline = false;
	public float outlineOffsetAmt = 0.1f;
	public float outlineMod = 0.0f;
	public bool isMaterial = false;
	public bool isImage = false;
	public bool isLight = false;
	public bool isTrail = false;

	public bool isParticle = false;
	public bool partTrail = false;
	public bool light = false;
	public bool dark = false;
	public float mod = 0.0f;
	public float alpha = 1.0f;
	public bool offset = false;
	public float offsetAmt = 0.1f;


	public Color offsetcolor;
	public Color outlineOffsetcolor;
	// Use this for initialization
	void Start () {
		colman = GameObject.Find("ColorMan").GetComponent<ColorMan>();
		Color color = colman.mainColor;
		Gradient grad = new Gradient();
        grad.SetKeys( new GradientColorKey[] { new GradientColorKey(color, 1.0f), new GradientColorKey(color, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 1.0f), new GradientAlphaKey(1.0f, 0.0f) } );
		if(light){
			color.r = color.r +0.25f;
			color.g= color.g +0.25f;
			color.b = color.b +0.25f;
		}
		if(dark){
			color.r = color.r -0.45f;
			color.g= color.g -0.45f;
			color.b = color.b -0.45f;
		}
		color.r = color.r +mod;
		color.g= color.g +mod;
		color.b = color.b +mod;
		color.a = alpha;
		if(color.r > 1.0f){
			color.r=1.0f;
		}
		if(color.r < 0.0f){
			color.r=0.0f;
		}
		if(color.g > 1.0f){
			color.g=1.0f;
		}
		if(color.g < 0.0f){
			color.g=0.0f;
		}
		if(color.b > 1.0f){
			color.b=1.0f;
		}
		if(color.b < 0.0f){
			color.b=0.0f;
		}
		//offset
		if(offset){
			float hue;
			float sat;
			float val;
			Color.RGBToHSV(color, out hue,out sat,out val);
			hue = hue - offsetAmt;
			if(hue<0){
				hue = 1.0f - hue;
			}
			if(hue >1){
				hue = hue - 1;
			}

			offsetcolor = Color.HSVToRGB(hue,sat,val);
		
			color.a = alpha;
			color = offsetcolor;
		}
		if(useOutline){
			float hue;
			float sat;
			float val;
			Color.RGBToHSV(color, out hue,out sat,out val);
			hue = hue - outlineOffsetAmt;
			if(hue<0){
				hue = 1.0f - hue;
			}
			if(hue >1){
				hue = hue - 1;
			}

			outlineOffsetcolor = Color.HSVToRGB(hue,sat,val);
			outlineOffsetcolor.r = outlineOffsetcolor.r +outlineMod;
			outlineOffsetcolor.g= outlineOffsetcolor.g +outlineMod;
			outlineOffsetcolor.b = outlineOffsetcolor.b +outlineMod;
			//color.a = alpha;
			//color = outlineOffsetcolor;
		}
		



		if(isText){		
			gameObject.GetComponent<Text>().color = color;
		}
		if(useOutline){
			gameObject.GetComponent<Shadow>().effectColor = outlineOffsetcolor;
		}
		if(isMaterial){
			gameObject.GetComponent<Renderer>().material.color = color;
		}
		if(isImage){
			gameObject.GetComponent<Image>().color = color;
		}
		if(isLight){
			gameObject.GetComponent<Light>().color = color;
		}
		if(isTrail){
			gameObject.GetComponent<TrailRenderer>().colorGradient = grad;
		}
		if(isParticle){
			gameObject.GetComponent<ParticleSystemRenderer>().material.color = color;
			var ps = gameObject.GetComponent<ParticleSystem>().main;
			ps.startColor= color;
			ParticleSystem pss = GetComponent<ParticleSystem>();
        	var col = pss.colorOverLifetime;
        	col.color = grad;
			
		}
		if(partTrail){
        	var trails = gameObject.GetComponent<ParticleSystem>().trails;
			trails.colorOverTrail = grad;
			trails.colorOverLifetime = grad;
		}



	}
	

}
