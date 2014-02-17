using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SceneManager : MonoBehaviour {

	// Static singleton property
	public static SceneManager Instance { get; private set; }

	public List<Actor> actors;
	
	void Awake()
	{	
		// First we check if there are any other instances conflicting
		if(Instance != null && Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}
		
		// Here we save our singleton instance
		Instance = this;
	}


	// Use this for initialization
	void Start () {
		actors = gameObject.GetComponent<SpawnActor>().Spawn();
		IgnoreColliders();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void IgnoreColliders() {
		UnityEngine.Object[] characterControllers = Object.FindObjectsOfType (typeof(CharacterController));
		
		foreach(CharacterController characterControllerA in characterControllers)
		{
			foreach(CharacterController characterControllerB in characterControllers) 
			{
				if(characterControllerA != characterControllerB) {
					characterControllerA.gameObject.SetActive(true);
					characterControllerB.gameObject.SetActive(true);
					Physics.IgnoreCollision(characterControllerA.collider, characterControllerB.collider);
				}
				
			}
			
		}
		

	}
}
