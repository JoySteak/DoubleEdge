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

	public PlayerCount player;

	public CardScript.CardType m_cardType;
	public CardScript.ArrowType m_arrowType;
	public CardScript.MirrorType m_mirrorType;

	//public Camera camera;
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
			switch (m_cardType) {
			case CardScript.CardType.Arrow:

				tmpString += "Arrow - ";

				if (m_arrowType == CardScript.ArrowType.One) {
					tmpString += " One";
				} else if (m_arrowType == CardScript.ArrowType.Two) {
					tmpString += " Two";
				} else if (m_arrowType == CardScript.ArrowType.Three) {
					tmpString += " Three";
				} else if (m_arrowType == CardScript.ArrowType.Four) {
					tmpString += " Four";
				}
				break;
			case CardScript.CardType.Mirror:

				tmpString += "Mirror - ";
			
				if (m_mirrorType == CardScript.MirrorType.One) {
					tmpString += " One";
				} else if (m_mirrorType == CardScript.MirrorType.Two) {
					tmpString += " Two";
				} else if (m_mirrorType == CardScript.MirrorType.Three) {
					tmpString += " Three";
				} else if (m_mirrorType == CardScript.MirrorType.Four) {
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
		//check (from GameManager?) if it's at the placing phase

		if (photonView.isMine) {
			if (Input.GetKeyDown (KeyCode.C) && m_cardType == CardScript.CardType.Arrow) {
				m_cardType = CardScript.CardType.Mirror;
			} else if (Input.GetKeyDown (KeyCode.C) && m_cardType == CardScript.CardType.Mirror) {
				m_cardType = CardScript.CardType.Arrow;
			}
		
			if (Input.GetKeyDown (KeyCode.Alpha1) && m_cardType == CardScript.CardType.Arrow) {
				m_arrowType = CardScript.ArrowType.One;
			} else if (Input.GetKeyDown (KeyCode.Alpha2) && m_cardType == CardScript.CardType.Arrow) {
				m_arrowType = CardScript.ArrowType.Two;
			} else if (Input.GetKeyDown (KeyCode.Alpha3) && m_cardType == CardScript.CardType.Arrow) {
				m_arrowType = CardScript.ArrowType.Three;
			} else if (Input.GetKeyDown (KeyCode.Alpha4) && m_cardType == CardScript.CardType.Arrow) {
				m_arrowType = CardScript.ArrowType.Four;
			}
			if (Input.GetKeyDown (KeyCode.Alpha1) && m_cardType == CardScript.CardType.Mirror) {
				m_mirrorType = CardScript.MirrorType.One;
			} else if (Input.GetKeyDown (KeyCode.Alpha2) && m_cardType == CardScript.CardType.Mirror) {
				m_mirrorType = CardScript.MirrorType.Two;
			} else if (Input.GetKeyDown (KeyCode.Alpha3) && m_cardType == CardScript.CardType.Mirror) {
				m_mirrorType = CardScript.MirrorType.Three;
			} else if (Input.GetKeyDown (KeyCode.Alpha4) && m_cardType == CardScript.CardType.Mirror) {
				m_mirrorType = CardScript.MirrorType.Four;
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
					photonView.RPC("MasterClientInstantiateCard", PhotonTargets.MasterClient, new object[]{position, (int)m_cardType, (int)m_arrowType, (int)m_mirrorType});
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
}
