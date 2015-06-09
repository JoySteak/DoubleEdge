using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager current;
	public List<GameObject> players = new List<GameObject>();
	public float turncheckTimer = 2f;
	public float turncheckMax = 2f;

	void Awake(){
		current = this;
	}

	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){

		//decrease timer

		//if
		if(endTurn()){
		 	turncheckTimer -= Time.deltaTime;
			if(turncheckTimer <= 0){
				Debug.Log ("TIMER OVER");
			// Check for projectile in hiereachy
				if(GameObject.FindGameObjectWithTag("Projectile") == null){
					for(int i=0;i<players.Count;i++){
						players[i].GetComponent<Player>().hasPlaced = false;
					}
					turncheckTimer = turncheckMax;
					Debug.Log ("CAN PLACE");
				}
			}
		}


		//check if all players has placed
		//change can place into false(handled in player)

		//the objects move
		//if no more "balls" on board
		//change can has placed into false
	}

	public bool endTurn(){
		for(int i =0; i< players.Count; i++){
			bool m_hasPlaced = players[i].GetComponent<Player>().hasPlaced;
			Debug.Log (players[i]);
			if(m_hasPlaced == false){
				Debug.Log (players.Count);
				return false;
			}
		}

		Debug.Log("ENDED TURN");
		return true;
	}
}
