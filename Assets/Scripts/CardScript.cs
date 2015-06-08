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

	public enum MirrorType
	{
		One = 0,
		Two,
		Three,
		Four
	};

	public CardType m_cardType = CardType.Mirror;
	public MirrorType m_mirrorType = MirrorType.One;

	public Sprite[] m_sprites = new Sprite[2]; 

	// Use this for initialization
	void Start(){

		m_GameManager = GameObject.Find("GameManager");

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

	}
	
	// Update is called once per frame
	void Update(){
		if(m_GameManager.GetComponent<GameManager>().endTurn() && m_cardType == CardType.Arrow){
			photonView.RPC ("ShootProjectile", PhotonTargets.AllViaServer, new object[]{});
		}

		//if all players hasplaced
		//all arrow cards spawn object in x+ direction at same speed

	}

	[RPC]
	void ShootProjectile(){
		if(!hasShot){
			//Quaternion rotation = Quaternion.identity;
			//rotation.eulerAngles = transform.rotation.eulerAngles;
			PhotonNetwork.Instantiate("Projectile", transform.position, Quaternion.Euler(0, 0, this.transform.localEulerAngles.z), 0);
			hasShot = true;
		}
	}

}
