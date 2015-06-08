using UnityEngine;
using System.Collections;

public class CardColliderScript : MonoBehaviour
{
	private CardScript m_parentCardScript;

	// Use this for initialization
	void Start(){
		m_parentCardScript = gameObject.GetComponentInParent<CardScript>();
	}
	
	// Update is called once per frame
	void Update(){
	
	}
}
