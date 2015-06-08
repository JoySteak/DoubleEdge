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

	public enum ArrowType
	{
		One = 0,
		Two,
		Three,
		Four
	};

	public enum MirrorType
	{
		One = 0,
		Two,
		Three,
		Four
	};

	public CardType m_cardType = CardType.Mirror;
	public ArrowType m_arrowType = ArrowType.One;
	public MirrorType m_mirrorType = MirrorType.One;

	public Sprite[] m_sprites = new Sprite[2]; 

	// Use this for initialization
	void Start(){

		m_GameManager = GameObject.Find("GameManager");

<<<<<<< HEAD
		Vector3 tmpRotation;
		switch (m_cardType) {
		case CardType.Arrow:
			GetComponent<SpriteRenderer>().sprite = m_sprites[0];
			tmpRotation = transform.localEulerAngles;
			tmpRotation.z = -90.0f;
			transform.localEulerAngles = tmpRotation;
			photonView.RPC ("ShootProjectile", PhotonTargets.AllViaServer, new object[]{});
			break;
		case CardType.Mirror:
			GetComponent<SpriteRenderer>().sprite = m_sprites[1];
			tmpRotation = transform.localEulerAngles;
			tmpRotation.z = -90.0f;
			transform.localEulerAngles = tmpRotation;
			break;
		}
=======
		Vector3 tmpRotation = transform.localEulerAngles;
>>>>>>> 6a7f957fdba771c7298c14ef97f271824e04df3b

		if (m_cardType == CardType.Arrow) {
			switch (m_arrowType) {
			case ArrowType.One:
				tmpRotation.z = 0.0f;
				break;
			case ArrowType.Two:
				tmpRotation.z = 90.0f;
				break;
			case ArrowType.Three:
				tmpRotation.z = 180.0f;
				break;
			case ArrowType.Four:
				tmpRotation.z = -90.0f;
				break;
			}
			photonView.RPC("RemoteSetupCard", PhotonTargets.AllBufferedViaServer, new object[]{0, tmpRotation});
			ShootProjectile();
		} else {
			switch (m_mirrorType) {
			case MirrorType.One:
				tmpRotation.z = 0.0f;
				break;
			case MirrorType.Two:
				tmpRotation.z = 90.0f;
				break;
			case MirrorType.Three:
				tmpRotation.z = 180.0f;
				break;
			case MirrorType.Four:
				tmpRotation.z = -90.0f;
				break;
			}
			photonView.RPC("RemoteSetupCard", PhotonTargets.AllBufferedViaServer, new object[]{1, tmpRotation});
		}
	}
	
	// Update is called once per frame
	void Update(){
		if(m_GameManager.GetComponent<GameManager>().endTurn() && m_cardType == CardType.Arrow){
			ShootProjectile();
		}

		//if all players hasplaced
		//all arrow cards spawn object in x+ direction at same speed

	}

	void ShootProjectile(){
		if(photonView.isMine)
			photonView.RPC ("RemoteShootProjectile", PhotonTargets.AllViaServer, new object[]{});
	}

	[RPC]
	void RemoteShootProjectile(){
		if(!hasShot){
			//Quaternion rotation = Quaternion.identity;
			//rotation.eulerAngles = transform.rotation.eulerAngles;
			PhotonNetwork.Instantiate("Projectile", transform.position, Quaternion.Euler(0, 0, this.transform.localEulerAngles.z), 0);
			hasShot = true;
		}
	}

	[RPC]
	void RemoteSetupCard(int spriteType, Vector3 rotation){
		GetComponent<SpriteRenderer> ().sprite = m_sprites [spriteType];
		transform.localEulerAngles = rotation;
	}
}
