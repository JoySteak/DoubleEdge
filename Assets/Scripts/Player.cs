using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Photon.MonoBehaviour {

	//public bool canPlace = true;
	public bool hasPlaced = false;

	public enum PlayerCount {
		One = 1,
		Two,
		Three,
		Four
	};

	bool isTopCard = false;

	public PlayerCount player;

	// Top
	public CardScript.CardType m_topcardType;
	public CardScript.ArrowType m_toparrowType;
	public CardScript.MirrorType m_topmirrorType;

	// Bottom
	public CardScript.CardType m_botcardType;
	public CardScript.ArrowType m_botarrowType;
	public CardScript.MirrorType m_botmirrorType;

	// Use this for initialization
	void Start(){
		player = (PlayerCount)photonView.instantiationData[0];
		SetUpPlayerPosition (player);

		GameObject[] tmpPlayers = GameObject.FindGameObjectsWithTag("Player");

		if (photonView.isMine) {
			GameManager.current.players.Add (this.gameObject);
		}
		else {
			for(int i = 0; i < tmpPlayers.Length; i++) {
				if(GameManager.current.players[i].GetHashCode() != this.gameObject.GetHashCode()){
					GameManager.current.players.Add(this.gameObject);
				}
			}
		}
	}

	void OnGUI(){
		if (photonView.isMine) {
			string tmpString = "";
			switch (m_topcardType) {
			case CardScript.CardType.Arrow:

				tmpString += "Arrow - ";

				if (m_toparrowType == CardScript.ArrowType.One) {
					tmpString += " One";
				} else if (m_toparrowType == CardScript.ArrowType.Two) {
					tmpString += " Two";
				} else if (m_toparrowType == CardScript.ArrowType.Three) {
					tmpString += " Three";
				} else if (m_toparrowType == CardScript.ArrowType.Four) {
					tmpString += " Four";
				}
				break;
			case CardScript.CardType.Mirror:

				tmpString += "Mirror - ";
			
				if (m_topmirrorType == CardScript.MirrorType.One) {
					tmpString += " One";
				} else if (m_topmirrorType == CardScript.MirrorType.Two) {
					tmpString += " Two";
				} else if (m_topmirrorType == CardScript.MirrorType.Three) {
					tmpString += " Three";
				} else if (m_topmirrorType == CardScript.MirrorType.Four) {
					tmpString += " Four";
				}
				break;
			}
			GUI.Label (new Rect (Screen.width * 0.7f, 5.0f, 200.0f, 50.0f),
		           tmpString);
		}
	}
	
	// Update is called once per frame
	void Update(){


		if (photonView.isMine) {
			//if looking at top or bottom card
			if(Input.GetKeyDown(KeyCode.Space) && isTopCard){
				isTopCard = false;
			}else if(Input.GetKeyDown(KeyCode.Space) && !isTopCard){
				isTopCard = true;
			}
			if(isTopCard){
				if (Input.GetKeyDown (KeyCode.C) && m_topcardType == CardScript.CardType.Arrow) {
					m_topcardType = CardScript.CardType.Mirror;
				} else if (Input.GetKeyDown (KeyCode.C) && m_topcardType == CardScript.CardType.Mirror) {
					m_topcardType = CardScript.CardType.Arrow;
				}
				
				if (Input.GetKeyDown (KeyCode.Alpha1) && m_topcardType == CardScript.CardType.Arrow) {
					m_toparrowType = CardScript.ArrowType.One;
				} else if (Input.GetKeyDown (KeyCode.Alpha2) && m_topcardType == CardScript.CardType.Arrow) {
					m_toparrowType = CardScript.ArrowType.Two;
				} else if (Input.GetKeyDown (KeyCode.Alpha3) && m_topcardType == CardScript.CardType.Arrow) {
					m_toparrowType = CardScript.ArrowType.Three;
				} else if (Input.GetKeyDown (KeyCode.Alpha4) && m_topcardType == CardScript.CardType.Arrow) {
					m_toparrowType = CardScript.ArrowType.Four;
				}
				if (Input.GetKeyDown (KeyCode.Alpha1) && m_topcardType == CardScript.CardType.Mirror) {
					m_topmirrorType = CardScript.MirrorType.One;
				} else if (Input.GetKeyDown (KeyCode.Alpha2) && m_topcardType == CardScript.CardType.Mirror) {
					m_topmirrorType = CardScript.MirrorType.Two;
				} else if (Input.GetKeyDown (KeyCode.Alpha3) && m_topcardType== CardScript.CardType.Mirror) {
					m_topmirrorType = CardScript.MirrorType.Three;
				} else if (Input.GetKeyDown (KeyCode.Alpha4) && m_topcardType == CardScript.CardType.Mirror) {
					m_topmirrorType = CardScript.MirrorType.Four;
				}
			}else{
				if (Input.GetKeyDown (KeyCode.C) && m_botcardType == CardScript.CardType.Arrow) {
					m_botcardType = CardScript.CardType.Mirror;
				} else if (Input.GetKeyDown (KeyCode.C) && m_topcardType == CardScript.CardType.Mirror) {
					m_botcardType = CardScript.CardType.Arrow;
				}
				
				if (Input.GetKeyDown (KeyCode.Alpha1) && m_botcardType == CardScript.CardType.Arrow) {
					m_botarrowType = CardScript.ArrowType.One;
				} else if (Input.GetKeyDown (KeyCode.Alpha2) && m_botcardType == CardScript.CardType.Arrow) {
					m_botarrowType = CardScript.ArrowType.Two;
				} else if (Input.GetKeyDown (KeyCode.Alpha3) && m_botcardType == CardScript.CardType.Arrow) {
					m_botarrowType = CardScript.ArrowType.Three;
				} else if (Input.GetKeyDown (KeyCode.Alpha4) && m_botcardType == CardScript.CardType.Arrow) {
					m_botarrowType = CardScript.ArrowType.Four;
				}
				if (Input.GetKeyDown (KeyCode.Alpha1) && m_topcardType == CardScript.CardType.Mirror) {
					m_botmirrorType = CardScript.MirrorType.One;
				} else if (Input.GetKeyDown (KeyCode.Alpha2) && m_topcardType == CardScript.CardType.Mirror) {
					m_botmirrorType = CardScript.MirrorType.Two;
				} else if (Input.GetKeyDown (KeyCode.Alpha3) && m_topcardType== CardScript.CardType.Mirror) {
					m_botmirrorType = CardScript.MirrorType.Three;
				} else if (Input.GetKeyDown (KeyCode.Alpha4) && m_topcardType == CardScript.CardType.Mirror) {
					m_botmirrorType = CardScript.MirrorType.Four;
				}
			}

		}

		if(hasPlaced == false){
		//0 is left click
		//1 is right click
			if(Input.GetMouseButtonDown(0)){
				Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				position.z = 0;
				position = new Vector3(Mathf.Round(position.x/3)*3,Mathf.Round(position.y/3)*3,0);
				if(photonView.isMine) {
					//spawn a bigcard
					photonView.RPC("MasterClientInstBigCard", PhotonTargets.MasterClient,new object[]{new Vector3(position.x,position.y-1.5f,position.z),
						(int)m_topcardType, (int)m_toparrowType, (int)m_topmirrorType, (int)m_botcardType, (int)m_botarrowType, (int)m_botmirrorType});
					//photonView.RPC("MasterClientInstantiateCard", PhotonTargets.MasterClient, new object[]{new Vector3(position.x,position.y+3f,position.z), (int)m_cardType, (int)m_arrowType, (int)m_mirrorType});
					//photonView.RPC("MasterClientInstantiateCard", PhotonTargets.MasterClient, new object[]{new Vector3(position.x,position.y,position.z), (int)m_cardType, (int)m_arrowType, (int)m_mirrorType});
					photonView.RPC("ToggleHasPlaced", PhotonTargets.AllBufferedViaServer, null);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//detect if other is a "laser"
		//if so, minus one hp
	}

	void SetUpPlayerPosition(PlayerCount player){
		GameObject tmpHorGridObj = GameObject.Find("HorGrid");
		GameObject tmpVerGridObj = GameObject.Find("VerGrid");

		Vector3 scale;
		Vector3 position;

		switch (player) {
		case PlayerCount.One:
			transform.name ="PlayerOne";
			scale = new Vector3(tmpHorGridObj.transform.localScale.x, 
	                            0.5f,
	                            tmpHorGridObj.transform.localScale.z);

			position = new Vector3(tmpHorGridObj.transform.position.x, 
	                               tmpVerGridObj.transform.localScale.y * -0.6f,
	                               tmpHorGridObj.transform.localScale.z);

			transform.localScale = scale;
			transform.position = position;
			break;
		case PlayerCount.Two:
			transform.name ="PlayerTwo";
			scale = new Vector3(0.5f, 
			                    tmpVerGridObj.transform.localScale.y,
			                    tmpVerGridObj.transform.localScale.z);
			
			position = new Vector3(tmpHorGridObj.transform.localScale.x * -0.6f, 
			                       tmpVerGridObj.transform.position.y,
			                       tmpVerGridObj.transform.localScale.z);
			
			transform.localScale = scale;
			transform.position = position;
			break;
		case PlayerCount.Three:
			transform.name ="PlayerThree";
			scale = new Vector3(tmpHorGridObj.transform.localScale.x, 
			                    0.5f,
			                    tmpHorGridObj.transform.localScale.z);
			
			position = new Vector3(tmpHorGridObj.transform.position.x, 
			                       tmpVerGridObj.transform.localScale.y * 0.6f,
			                       tmpHorGridObj.transform.localScale.z);
			
			transform.localScale = scale;
			transform.position = position;
			break;
		case PlayerCount.Four:
			transform.name ="PlayerFour";
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
	void ToggleHasPlaced(){
		hasPlaced = !hasPlaced; //tell GameManager that this player has placed
	}

	[RPC]
	void MasterClientInstantiateCard(Vector3 position, int cardType, int arrowType, int mirrorType){
		PhotonNetwork.InstantiateSceneObject("Card", 
		                                     position, 
		                                     Quaternion.identity, 
		                                     0, 
		                                     new object[]{cardType, arrowType, mirrorType});

	}

	[RPC]
	void MasterClientInstBigCard(Vector3 position, int topcardType, int toparrowType, int topmirrorType, int botcardType, int botarrowType, int botmirrorType){
		PhotonNetwork.InstantiateSceneObject("BigCard",position,Quaternion.identity,0, new object[]{
			topcardType, toparrowType, topmirrorType, // Top Card
			botcardType, botarrowType, botmirrorType // Bottom Card
		});
	
	}
}
