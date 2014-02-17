using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public bool isServer = false;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this);
	}

    void Start()
    {
		if(isServer) {
			Network.InitializeServer(32, 25000, false);
		} else {
			Network.Connect("127.0.0.1", 25000);
		}
    }

	// Update is called once per frame
	void Update () {
		
	}

	void OnServerInitialized() {
		Debug.Log ("Server Started");
	}

	void OnPlayerConnected() {
		Debug.Log ("Player Connected");
	}

	void OnLevelWasLoaded(int level) {
		if(level == 3) {
			
			AddPC();

		}
	}

	[RPC]
	void LoadLevel(string level) {
		Application.LoadLevel(level);

	}

	[RPC]
	void AddPC() {
		GameObject prefab = Network.Instantiate(Resources.Load("Prefabs/Playable Boat Person"), Vector3.zero,Quaternion.Euler(0,0,0),0) as GameObject;

		prefab.GetComponentInChildren<Camera>().depth = 2;

	}	

	GameObject searchChildrenForName(GameObject parent, string name) {
		Transform[] children = parent.GetComponentsInChildren<Transform>();
		foreach(Transform child in children) {

			if(child.name == name) {
				return child.gameObject;
			}
		}
		return null;
	}
}
