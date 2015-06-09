using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager current;
	public List<GameObject> players = new List<GameObject>();
	public float turncheckTimer = 2f;
	public float turncheckMax = 2f;

	public bool m_turnEnd = false;

	void Awake(){
		current = this;
	}

	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){

		if(GameObject.FindGameObjectWithTag("Projectile") == null && m_turnEnd){
			for(int i=0;i<players.Count;i++){
				players[i].GetComponent<Player>().hasPlaced = false;
			}
			m_turnEnd = false;
		}

		TurnCheck();

		//check if all players has placed
		//change can place into false(handled in player)

		//the objects move
		//if no more "balls" on board
		//change can has placed into false
	}

	public void TurnCheck(){
		for (int i = 0; i < players.Count; i++) {
			bool hasPlaced = players[i].GetComponent<Player>().hasPlaced;

			// If any player has not placed a card return
			if(hasPlaced == false)
				return;
		}

		// Else set turnEnd to true
		m_turnEnd = true;
	}
}
