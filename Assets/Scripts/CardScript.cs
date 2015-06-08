using UnityEngine;
using System.Collections;

public class CardScript : Photon.MonoBehaviour {

	bool hasShot = false;
	public GameObject projectile = null;
	GameObject m_GameManager = null;

	public enum CardType{
		Arrow = 0,
		Mirror
	}

	public CardType m_type = CardType.Arrow;

	// Use this for initialization
	void Start(){
		m_GameManager = GameObject.Find("GameManager");
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
