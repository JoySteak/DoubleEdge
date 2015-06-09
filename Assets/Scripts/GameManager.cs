using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager current;
	public List<GameObject> players = new List<GameObject>();

	public bool m_turnEnd = false;

	public GameObject m_poolManager;

	void Awake(){
		current = this;
	}

	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){

		if(m_turnEnd){

			List<GameObject> tmpPool = m_poolManager.GetComponent<PoolManager>().m_pool;
			for(int i = 0; i < tmpPool.Count; i++){
				if(tmpPool[i].activeSelf){
					return;
				}
			}

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
