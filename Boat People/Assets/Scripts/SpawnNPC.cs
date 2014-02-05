using UnityEngine;
using System.Collections;

public class SpawnNPC : MonoBehaviour {
	int width = 30;
	int length = 30;
	public float spawnDistance;
	float raycastRange = 10;
	float xOffset = -10;
	float zOffset = -10;
	public Grid grid;

	// Use this for initialization
	void Start () {
		for(int x = 0; x < width;x++) {
			
			for(int z = 0; z < length;z++) {
				Ray ray = new Ray(transform.position + new Vector3(x * spawnDistance + xOffset, 0, z * spawnDistance + zOffset),Vector3.down);
				RaycastHit hit;
				if(Physics.Raycast(ray,out hit, raycastRange)) {
					
					GameObject newNPC = GameObject.Instantiate(Resources.Load("Prefabs/NPC Boat Person"),hit.point, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;

					newNPC.GetComponent<AIController>().currentGrid = grid;
				}
				
				
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
