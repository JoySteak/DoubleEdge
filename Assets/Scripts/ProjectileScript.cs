﻿using UnityEngine;
using System.Collections;

public class ProjectileScript : Photon.MonoBehaviour {

	public float m_maxSpeed = 2.0f;
	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){

		rigidbody2D.velocity = this.transform.rotation*  new Vector3 (m_maxSpeed, 0,0) ;
	
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Debug.Log ("aaa");
			Destroy(this.gameObject);
		}
	}

	[RPC]
	public void RemoteProjectileRotation(int turnAngle){
		Vector3 tmpRotation = transform.localEulerAngles;
		tmpRotation.z += turnAngle;
		transform.localEulerAngles = tmpRotation;

		Debug.Log (transform.rotation.z + "");
	}
}
