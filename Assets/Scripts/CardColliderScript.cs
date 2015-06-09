using UnityEngine;
using System.Collections;

public class CardColliderScript : MonoBehaviour
{
	public enum CardColliderType
	{
		East,
		South,
		West,
		North
	};
	public CardColliderType m_cardColliderType;
	private CardScript m_parentCardScript;

	// Use this for initialization
	void Start(){
		m_parentCardScript = gameObject.GetComponentInParent<CardScript>();
	}
	
	// Update is called once per frame
	void Update(){
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(m_parentCardScript.m_cardType == CardScript.CardType.Mirror && other.tag == "Projectile"){
			// Only if mirror do the following checks
			switch(m_cardColliderType){
			case CardColliderType.East:
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.One) {
					m_parentCardScript.m_rotationAngle = 90.0f;
				}
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.Two) {
					m_parentCardScript.m_rotationAngle = -270.0f;
				}
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.Three) {
					m_parentCardScript.m_rotationAngle = 90.0f;
				}
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.Four) {
					m_parentCardScript.m_rotationAngle = 90.0f;
				}
				break;
			case CardColliderType.South:
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.One) {
					m_parentCardScript.m_rotationAngle = -90.0f;
				}
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.Two) {
					m_parentCardScript.m_rotationAngle = -90.0f;
				}
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.Three) {
					m_parentCardScript.m_rotationAngle = -90.0f;
				}
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.Four) {
					m_parentCardScript.m_rotationAngle = -90.0f;
				}
				break;
			case CardColliderType.West:

				break;
			case CardColliderType.North:

				break;
			}

		}
	}
}
