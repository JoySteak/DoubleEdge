using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager current;
	public List<GameObject> players = new List<GameObject>();

	void Awake(){
		current = this;
	}

	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){

		if(endTurn()){
			// Check for projectile in hiereachy
			if(GameObject.FindGameObjectWithTag("Projectile") == null){
				Debug.Log ("Finished shooting");
				for(int i=0;i<players.Count;i++){
					players[i].GetComponent<Player>().hasPlaced = false;
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
			if(!m_hasPlaced){
				Debug.Log ("Not endturn");
				return false;
			}
		}

		Debug.Log("Ended turn");
		return true;
	}
}
