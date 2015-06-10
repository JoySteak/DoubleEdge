using UnityEngine;
using System.Collections;

public class PlayerIndicatorHelper
{
	public static Vector3 PlayerOne(){
		return new Vector3 (Screen.width * 0.5f, 20.0f, 0.0f);
	}

	public static Vector3 PlayerTwo(){
		return new Vector3 (20.0f, Screen.height * 0.5f, 0.0f);
	}

	public static Vector3 PlayerThree(){
		return new Vector3 (Screen.width * 0.5f, -20.0f, 0.0f);
	}

	public static Vector3 PlayerFour(){
		return new Vector3 (-20.0f, Screen.height * 0.5f, 0.0f);
	}
}
