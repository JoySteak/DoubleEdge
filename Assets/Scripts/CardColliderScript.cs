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

	// Use this for initialization
	void Start(){
	}
	
	// Update is called once per frame
	void Update(){
	
	}

	void OnTriggerExit2D(Collider2D other){

	}
}
