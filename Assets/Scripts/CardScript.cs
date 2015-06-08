using UnityEngine;
using System.Collections;

public class CardScript : Photon.MonoBehaviour {

	bool hasShot = false;
	public GameObject projectile = null;

	public enum CardType{
		Arrow = 0,
		Mirror
	}

	public CardType m_type = CardType.Arrow;

	// Use this for initialization
	void Start(){
		photonView.RPC ("ShootProjectile", PhotonTargets.AllViaServer, new object[]{});
	}
	
	// Update is called once per frame
	void Update(){
	
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
