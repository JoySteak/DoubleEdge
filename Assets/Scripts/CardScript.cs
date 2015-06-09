using UnityEngine;
using System.Collections;

public class CardScript : Photon.MonoBehaviour {

	bool hasShot = false;
	public GameObject projectile = null;
	GameObject m_PoolManager = null;
	GameObject m_GameManager = null;

	public GameObject m_projectileRef;

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

	public float m_rotationAngle = 0.0f;

	// Use this for initialization
	void Start(){

		m_cardType = (CardType)photonView.instantiationData [0];
		m_arrowType = (ArrowType)photonView.instantiationData [1];
		m_mirrorType = (MirrorType)photonView.instantiationData [2];

		m_GameManager = GameObject.Find("GameManager");
		m_PoolManager = GameObject.Find("PoolManager");
	

		Vector3 tmpRotation = transform.localEulerAngles;


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
			photonView.RPC("RemoteSetupCard", PhotonTargets.AllViaServer, new object[]{0, tmpRotation});
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
			photonView.RPC("RemoteSetupCard", PhotonTargets.AllViaServer, new object[]{1, tmpRotation});
		}
	}
	
	// Update is called once per frame
	void Update(){

		if (m_GameManager.GetComponent<GameManager> ().m_turnEnd) {
			ShootProjectile ();
		} else {
			ToggleHasShot();
		}

		//if all players hasplaced
		//all arrow cards spawn object in x+ direction at same speed

	}

	void OnTriggerEnter2D(Collider2D other){
//		if (other.tag != "Projectile")
//			return;
//
//		if (m_projectileRef != other.gameObject)
//			return;
//
//		other.GetComponent<ProjectileScript>().RemoteProjectileRotation(m_rotationAngle);
//
//		m_projectileRef = null;

	}

	public void ShootProjectile(){
		if (m_cardType != CardType.Arrow)
			return;

		m_rotationAngle = 0.0f;

//		if(photonView.isMine)
//			photonView.RPC ("RemoteShootProjectile", PhotonTargets.AllViaServer, new object[]{});
		if(!hasShot){
			var projectile = m_PoolManager.GetComponent<PoolManager>().GetBullet();
			var tempRotation = Quaternion.Euler(0,0,this.transform.localEulerAngles.z);
			projectile.transform.position = this.transform.position;
			projectile.transform.rotation = tempRotation;
			projectile.GetComponent<ProjectileScript>().m_rotationAngle = 0.0f;
			projectile.SetActive(true);
			//PhotonNetwork.Instantiate("Projectile", transform.position, Quaternion.Euler(0, 0, this.transform.localEulerAngles.z), 0);
			hasShot = true;
		}

	}

	void ToggleHasShot(){
		hasShot = false;
	}



	[RPC]
	void RemoteSetupCard(int spriteType, Vector3 rotation){
		GetComponent<SpriteRenderer> ().sprite = m_sprites [spriteType];
		transform.localEulerAngles = rotation;
	}
}
