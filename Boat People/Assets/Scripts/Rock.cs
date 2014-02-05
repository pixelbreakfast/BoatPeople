using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.localRotation = Quaternion.Euler(Mathf.Sin(Time.realtimeSinceStartup) * 12,0,0);

	}

}
