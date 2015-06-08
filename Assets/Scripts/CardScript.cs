using UnityEngine;
using System.Collections;

public class CardScript : Photon.MonoBehaviour {

	bool hasShot = false;
	public GameObject projectile = null;

	public enum CardType{
		Arrow = 0,
		Mirror
	}

	public CardType m_type = CardType.Mirror;

	public Sprite[] m_sprites = new Sprite[2]; 

	// Use this for initialization
	void Start(){
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
