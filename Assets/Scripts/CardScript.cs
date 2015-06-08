﻿using UnityEngine;
using System.Collections;

public class CardScript : Photon.MonoBehaviour {

	bool hasShot = false;
	public GameObject projectile = null;
	GameObject m_GameManager = null;

	public enum CardType{
		Arrow = 0,
		Mirror
	}

	public CardType m_type = CardType.Mirror;

	public Sprite[] m_sprites = new Sprite[2]; 

	// Use this for initialization
	void Start(){
<<<<<<< HEAD
		m_GameManager = GameObject.Find("GameManager");
=======
		Quaternion tmpRotation;
		switch (m_type) {
		case CardType.Arrow:
			GetComponent<SpriteRenderer>().sprite = m_sprites[0];
			tmpRotation = transform.rotation;
			tmpRotation.z = -90.0f;
			transform.rotation = tmpRotation;
			photonView.RPC ("ShootProjectile", PhotonTargets.AllViaServer, new object[]{});
			break;
		case CardType.Mirror:
			GetComponent<SpriteRenderer>().sprite = m_sprites[1];
			tmpRotation = transform.rotation;
			tmpRotation.z = -90.0f;
			transform.rotation = tmpRotation;
			break;
		}
>>>>>>> f4cc1674fd2254546cf4ebd65b48f3a9ca9631c4
	}
	
	// Update is called once per frame
	void Update(){
		if(m_GameManager.GetComponent<GameManager>().endTurn()){
			photonView.RPC ("ShootProjectile", PhotonTargets.AllViaServer, new object[]{});
		}

		//if all players hasplaced
		//all arrow cards spawn object in x+ direction at same speed

	}

	[RPC]
	void ShootProjectile(){
		if(!hasShot){
			Instantiate (projectile, this.transform.position, Quaternion.identity);
			hasShot = true;
		}
	}

}
