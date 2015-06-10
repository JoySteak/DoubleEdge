using UnityEngine;
using System.Collections;

public class AnchorHelper
{
	public struct AnchorVector
	{
		public Vector2 Min;
		public Vector2 Max;
	}

	public static AnchorVector MiddleRight(){

		AnchorVector tmpAnchorVector;
		tmpAnchorVector.Min = new Vector2 (1.0f, 0.5f);
		tmpAnchorVector.Max = new Vector2 (1.0f, 0.5f);
		return tmpAnchorVector;
	}

	public static AnchorVector TopCenter(){
		AnchorVector tmpAnchorVector;
		tmpAnchorVector.Min = new Vector2 (0.5f, 1.0f);
		tmpAnchorVector.Max = new Vector2 (0.5f, 1.0f);
		return tmpAnchorVector;
	}
	
	public static AnchorVector MiddleLeft(){
		AnchorVector tmpAnchorVector;
		tmpAnchorVector.Min = new Vector2 (0.0f, 0.5f);
		tmpAnchorVector.Max = new Vector2 (0.0f, 0.5f);
		return tmpAnchorVector;
	}
	
	public static AnchorVector BottomCenter(){
		AnchorVector tmpAnchorVector;
		tmpAnchorVector.Min = new Vector2 (0.5f, 0.0f);
		tmpAnchorVector.Max = new Vector2 (0.5f, 0.0f);
		return tmpAnchorVector;
	}
}
