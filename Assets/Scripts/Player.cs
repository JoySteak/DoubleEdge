﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Photon.MonoBehaviour {

	public GameObject card = null;
	public bool canPlace = true;
	public bool hasPlaced = false;

	private int player = 1;

	//public Camera camera;
	// Use this for initialization
	void Start(){
		player = (int)photonView.instantiationData[0];
		SetUpPlayerPosition (player);
	}
	
	// Update is called once per frame
	void Update(){
		//check (from GameManager?) if it's at the placing phase
		if(canPlace){
		//0 is left click
		//1 is right click
			if(Input.GetMouseButtonDown(0)){
				Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				position.z = 0;
				position = new Vector3(Mathf.Round(position.x/3)*3,Mathf.Round(position.y/3)*3,0);
				PhotonNetwork.RPC(photonView, "MasterClientInstantiateCard", PhotonTargets.MasterClient, true, new object[]{position});
				hasPlaced = true; //tell GameManager that this player has placed
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//detect if other is a "laser"
		//if so, minus one hp
	}

	void SetUpPlayerPosition(int player){
		GameObject tmpHorGridObj = GameObject.Find("HorGrid");
		GameObject tmpVerGridObj = GameObject.Find("VerGrid");

		Vector3 scale;
		Vector3 position;

		switch (player) {
		case 0:
			scale = new Vector3(tmpHorGridObj.transform.localScale.x, 
	                            0.5f,
	                            tmpHorGridObj.transform.localScale.z);

			position = new Vector3(tmpHorGridObj.transform.position.x, 
	                               tmpVerGridObj.transform.localScale.y * -0.6f,
	                               tmpHorGridObj.transform.localScale.z);

			transform.localScale = scale;
			transform.position = position;
			break;
		case 1:
			scale = new Vector3(0.5f, 
			                    tmpVerGridObj.transform.localScale.y,
			                    tmpVerGridObj.transform.localScale.z);
			
			position = new Vector3(tmpHorGridObj.transform.localScale.x * -0.6f, 
			                       tmpVerGridObj.transform.position.y,
			                       tmpVerGridObj.transform.localScale.z);
			
			transform.localScale = scale;
			transform.position = position;
			break;
		case 2:
			scale = new Vector3(tmpHorGridObj.transform.localScale.x, 
			                    0.5f,
			                    tmpHorGridObj.transform.localScale.z);
			
			position = new Vector3(tmpHorGridObj.transform.position.x, 
			                       tmpVerGridObj.transform.localScale.y * 0.6f,
			                       tmpHorGridObj.transform.localScale.z);
			
			transform.localScale = scale;
			transform.position = position;
			break;
		case 3:
			scale = new Vector3(0.5f, 
			                    tmpVerGridObj.transform.localScale.y,
			                    tmpVerGridObj.transform.localScale.z);
			
			position = new Vector3(tmpHorGridObj.transform.localScale.x * 0.6f, 
			                       tmpVerGridObj.transform.position.y,
			                       tmpVerGridObj.transform.localScale.z);
			
			transform.localScale = scale;
			transform.position = position;
			break;
		}
	}

	[RPC]
	void MasterClientInstantiateCard(Vector3 position){
		PhotonNetwork.InstantiateSceneObject("Card", position, Quaternion.identity, 0, null);
	}
}
