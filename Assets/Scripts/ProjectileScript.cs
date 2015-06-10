using UnityEngine;
using System.Collections;

public class ProjectileScript : Photon.MonoBehaviour {

	public float m_maxSpeed = 2.0f;

	public float m_rotationAngle = 0.0f;
	public Vector3 m_cardCenterColliderPosition = Vector3.zero;
	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){
		if(gameObject.activeSelf)
			rigidbody2D.velocity = this.transform.rotation*  new Vector3 (m_maxSpeed, 0,0) ;
	
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "ProjectileDestroyer"){
			gameObject.SetActive(false);
		}

		if(other.tag == "CardColliders"){
			CardColliderScript tmpCardColliderScript = other.gameObject.GetComponent<CardColliderScript>();
			CardScript tmpParentCardScript = other.gameObject.GetComponentInParent<CardScript>();

			if(tmpParentCardScript.m_cardType != CardScript.CardType.Mirror)
				return;

			// Only if mirror do the following checks
			switch(tmpCardColliderScript.m_cardColliderType){
			case CardColliderScript.CardColliderType.East:
				if(tmpParentCardScript.m_mirrorType == CardScript.MirrorType.One) {
					m_rotationAngle = 90.0f;
				}
				if(tmpParentCardScript.m_mirrorType == CardScript.MirrorType.Two) {
					m_rotationAngle = -270.0f;
				}
				if(tmpParentCardScript.m_mirrorType == CardScript.MirrorType.Three) {
					m_rotationAngle = 90.0f;
				}
				if(tmpParentCardScript.m_mirrorType == CardScript.MirrorType.Four) {
					m_rotationAngle = 90.0f;
				}
				break;
			case CardColliderScript.CardColliderType.South:
				if(tmpParentCardScript.m_mirrorType == CardScript.MirrorType.One) {
					m_rotationAngle = -90.0f;
				}
				if(tmpParentCardScript.m_mirrorType == CardScript.MirrorType.Two) {
					m_rotationAngle = -90.0f;
				}
				if(tmpParentCardScript.m_mirrorType == CardScript.MirrorType.Three) {
					m_rotationAngle = -90.0f;
				}
				if(tmpParentCardScript.m_mirrorType == CardScript.MirrorType.Four) {
					m_rotationAngle = -90.0f;
				}
				break;
			case CardColliderScript.CardColliderType.West:
				m_rotationAngle = 0.0f;
				break;
			case CardColliderScript.CardColliderType.North:
				m_rotationAngle = 0.0f;
				break;
			}
		}

		if (other.tag == "CardCenterCollider") {

			CardScript tmpParentCardScript = other.gameObject.GetComponentInParent<CardScript>();

			if(tmpParentCardScript.m_cardType != CardScript.CardType.Mirror)
				return;
			m_cardCenterColliderPosition = other.gameObject.GetComponent<BoxCollider2D>().bounds.center;
			ProjectileRotation();
		}
	}

	void ProjectileRotation(){
		Vector3 tmpRotation = transform.localEulerAngles;

		tmpRotation.z += m_rotationAngle;
		transform.localEulerAngles = tmpRotation;

		transform.position = m_cardCenterColliderPosition; 

		m_cardCenterColliderPosition = Vector3.zero;
		m_rotationAngle = 0.0f;
	}
}
