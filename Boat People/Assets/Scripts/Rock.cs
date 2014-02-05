using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	Quaternion startRotation;
	public Vector3 rotations;

	// Use this for initialization
	void Start () {
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.localRotation = startRotation * Quaternion.Euler(
			Mathf.Sin(Time.realtimeSinceStartup) * rotations.x,
			Mathf.Sin(Time.realtimeSinceStartup) * rotations.y,
			Mathf.Sin(Time.realtimeSinceStartup) * rotations.z);

	}

}
