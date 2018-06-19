using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen : MonoBehaviour {
	
	public int lvlSize = 100;
	public GameObject floor;
	public GameObject outer;
	public GameObject seed;
	public GameObject SuperSeed;
	public GameObject end;
	private Vector3[] positions;
	// Use this for initialization
	void Start () {
		
		positions = new Vector3[lvlSize];
		positions [0] = transform.position;
		int i = 0;
		while(i <lvlSize){
			//print (i);
			int chance = Random.Range (0,4);
			switch (chance) {
			case (1):
				transform.position = transform.position + Vector3.forward * 5;
				break;
			case(2):
				transform.position = transform.position + Vector3.right * 5;
				break;
			case(3):
				transform.position = transform.position + -Vector3.right * 5;
				break;
			}
			bool occupied = false;
			bool mirrorOCcupied = false;
			bool superSeed = false;
			int neighbors = 0;
			foreach (Vector3 pos in positions) {
				if (transform.position==pos) {
					occupied = true;
				}
				if (new Vector3 (-transform.position.x, transform.position.y, transform.position.z) == pos) {
					mirrorOCcupied = true;
				}
				if (!superSeed) {
					
				

					if (transform.position + Vector3.forward * 5 == pos) {
						neighbors = neighbors + 1;
					}
					if (transform.position + -Vector3.forward * 5 == pos) {
						neighbors = neighbors + 1;
					}
					if (transform.position + Vector3.right * 5 == pos) {
						neighbors = neighbors + 1;
					}
					if (transform.position + -Vector3.right * 5 == pos) {
						neighbors = neighbors + 1;
					}
					if (neighbors > 1) {
						superSeed = true;
						//print ("SUPER SEEEEED!!!");
					}
				}

			}
			//remove 50% of super seeds for rarity
			if(Random.Range(0,11)>4){
				superSeed = false;
			}
			if (occupied == false) {
				Instantiate (floor, transform.position, transform.rotation);
				if (transform.position.x != 0 && mirrorOCcupied == false) {
					Instantiate (floor, new Vector3(-transform.position.x,transform.position.y,transform.position.z), transform.rotation);
				}
				if (!superSeed) {
					
					Instantiate (seed, transform.position + Vector3.up, transform.rotation);
					if (transform.position.x != 0 && mirrorOCcupied == false) {
						Instantiate (seed, new Vector3(-transform.position.x,transform.position.y+1,transform.position.z), transform.rotation);
					}
				} else {
					Instantiate (SuperSeed, transform.position + Vector3.up, transform.rotation);
					if (transform.position.x != 0 && mirrorOCcupied == false) {
						Instantiate (SuperSeed, new Vector3(-transform.position.x,transform.position.y+1,transform.position.z), transform.rotation);
					}
				}
				positions [i] = transform.position;

			} else {
				//transform.position = positions [i];
			}
			i = i + 1;
		}

		Instantiate (end, transform.position, transform.rotation);
		Instantiate (end, new Vector3(-transform.position.x,transform.position.y,transform.position.z), transform.rotation);
		
		float maxX = 0;
		foreach (Vector3 pos in positions) {
			print("pos: "+Mathf.Abs(pos.x));
			if(Mathf.Abs(pos.x) > maxX){
				maxX = Mathf.Abs(pos.x);
			}
		}
		print("max X: "+maxX);
		Vector3	outerPos = new Vector3(0,0,0);
		i=0;
		while(i <lvlSize){
			Instantiate (outer, outerPos+Vector3.right*(maxX+50)*Random.Range(1.0f,1.5f)+Vector3.up*Random.Range(1,25), transform.rotation);	
			Instantiate (outer, outerPos-Vector3.right*(maxX+50)*Random.Range(1.0f,1.5f)+Vector3.up*Random.Range(1,25), transform.rotation);	
			outerPos.z=outerPos.z+5;
			i=i+1;
		}

	}

	// Update is called once per frame
	void Update () {

	}

}
