using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{
	public static NetworkManager current;

	private string roomName = "Double Edge";
	private bool isVisible = true;
	private bool isOpen = true;
	private int maxPlayers = 4;
	public bool isRoomMaster = false;

	void Awake(){
		current = this;
	}

	// Use this for initialization
	void Start(){
		PhotonNetwork.ConnectUsingSettings("0.1");
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
	}
	
	// Update is called once per frame
	void Update(){
	
	}

	void OnGUI(){
		GUI.Label (new Rect(0.0f, 5.0f, 200.0f, 50.0f),
		          "Status - " + PhotonNetwork.connectionStateDetailed.ToString ()
			+ System.Environment.NewLine + "Ping - "
			+ PhotonNetwork.GetPing ());
	}

	void OnJoinedLobby(){
		// Show All the UI of available rooms, create room and etc
		PhotonNetwork.JoinRoom(roomName);
	}

	void OnPhotonJoinRoomFailed(){
		Debug.Log("Join Room Failed");
		PhotonNetwork.CreateRoom(roomName, isVisible, isOpen, maxPlayers);
		isRoomMaster = true;
	}

	void OnJoinedRoom(){
		if(isRoomMaster){
			// Instantiate what's needed for MasterClient
		}

		PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0, new object[]{1});
	}
}
