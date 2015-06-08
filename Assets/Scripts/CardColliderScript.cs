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
		Debug.Log (" collided");
		if(m_parentCardScript.m_cardType == CardScript.CardType.Mirror && other.tag == "Projectile"){
			Debug.Log ("Projectile collided");
			// Only if mirror do the following checks
			switch(m_cardColliderType){
			case CardColliderType.East:
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.One
				   || m_parentCardScript.m_mirrorType == CardScript.MirrorType.Four) {
					other.GetComponent<PhotonView>().RPC("RemoteProjectileRotation", 
					                                     PhotonTargets.AllViaServer, 
					                                     new object[]{90});
				}
				break;
			case CardColliderType.South:
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.One
				   || m_parentCardScript.m_mirrorType == CardScript.MirrorType.Four) {
					
				}
				break;
			case CardColliderType.West:
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.One
				   || m_parentCardScript.m_mirrorType == CardScript.MirrorType.Four) {
					
				}
				break;
			case CardColliderType.North:
				if(m_parentCardScript.m_mirrorType == CardScript.MirrorType.One
				   || m_parentCardScript.m_mirrorType == CardScript.MirrorType.Four) {
					
				}
				break;
			}

		}
	}
}
