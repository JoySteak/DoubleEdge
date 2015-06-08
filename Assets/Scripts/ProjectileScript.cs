using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	public float m_maxSpeed = 2.0f;
	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){

		rigidbody2D.velocity = new Vector2 (m_maxSpeed, rigidbody2D.velocity.y);
	
	}
}
