using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public GameObject card = null;
	//public Camera camera;
	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){
		//0 is left click
		//1 is right click
		if(Input.GetMouseButtonDown(0)){
			Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			position.z = 0;
			position = new Vector3(Mathf.Round(position.x/3)*3,Mathf.Round(position.y/3)*3,0);
			Instantiate(card,position,Quaternion.identity);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//detect if other is a "laser"
		//if so, minus one hp
	}
}
