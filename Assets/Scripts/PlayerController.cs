using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {

	public CharacterController controller;
	 float moveSpeed = 2;
	 float gravity = 5;


	// Use this for initialization
	void Start () {
		if(controller == null) {
			controller = gameObject.GetComponent<CharacterController>() as CharacterController;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(networkView.isMine) {
		Vector3 move = Vector3.zero;
		move += new Vector3(0, -gravity  * Time.deltaTime, 0);

		if(Input.GetKey(KeyCode.W)) {
			move += transform.forward * moveSpeed * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.D)) {
			move += transform.right * moveSpeed * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.A)) {
			move += -transform.right * moveSpeed * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.S)) {
			move += -transform.forward * moveSpeed * Time.deltaTime;
		}
		

		controller.Move (move);

		}
	}
}
