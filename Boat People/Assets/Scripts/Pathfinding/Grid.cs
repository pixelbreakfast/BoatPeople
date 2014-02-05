using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
	public int width;
	public int length;
	public float gridSpacing;
	public List<Node> nodes;
	public float raycastRange = 10f;
	public LayerMask environmentLayerMask;
	public bool debugMode;

	// Use this for initialization
	void Start () {
		environmentLayerMask = 1 << LayerMask.NameToLayer("Environment");
		if(nodes == null) nodes = new List<Node>();

		for(int x = 0; x < width;x++) {
			
			for(int z = 0; z < length;z++) {
				Ray ray = new Ray(transform.position + new Vector3(x * gridSpacing, 0, z * gridSpacing),Vector3.down);
				RaycastHit hit;
				if(Physics.Raycast(ray,out hit, raycastRange, environmentLayerMask)) {
					if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Environment")) {
						GameObject nodeGameObject;
						if(debugMode) {
							nodeGameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
							Destroy(nodeGameObject.GetComponent<Collider>());
							nodeGameObject.renderer.material.color = new Color(0,255,0);

						} else {
							nodeGameObject = new GameObject();
						}

						nodeGameObject.name = "Node";
						Node newNode = nodeGameObject.AddComponent<Node>() as Node;
						newNode.transform.position = hit.point;
						newNode.transform.parent = hit.transform;
						newNode.transform.localScale = newNode.transform.localScale * 0.2f;
						nodes.Add(newNode);
					}

				}


			}
		}

	}


	// Update is called once per frame
	void Update () {
	
	}
}
