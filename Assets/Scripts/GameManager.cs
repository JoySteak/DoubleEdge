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

		//check if all players has placed
		//change can place into false
		//the objects move
		//if no more "balls" on board
		//change can place into true, has placed into false
	}

	/*bool endTurn(){
			
	}*/
}
