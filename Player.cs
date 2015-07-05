using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	float moveSpeed = 6;
	float gravity = -36;
	float jumpVelocity = 17;
	Vector3 velocity;

	bool yellowPowers = true;
	bool bluePowers = false;
	bool greenPowers = false;

	public enum PlayerColor {Yellow, Blue, Green};
	public static PlayerColor currentColor = PlayerColor.Yellow;

	public Animator animator;

	Controller2D controller;

	void Start () {
		animator = GetComponent<Animator>();
		controller = GetComponent<Controller2D> ();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			yellowPowers = true;
			Debug.Log("yellowPowers available");
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			bluePowers = true;
			Debug.Log("bluePowers available");
		}
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			greenPowers = true;
			Debug.Log("greenPowers available");
		}
		if (Input.GetKeyDown (KeyCode.Alpha1) && yellowPowers == true) {
			currentColor = PlayerColor.Yellow;
			//gameObject.GetComponent<MeshRenderer>().material.color = new Color(1,0.97f,0); //sunny yellow
			animator.SetInteger("colorInt", 0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && bluePowers == true) {
			currentColor = PlayerColor.Blue;
			//gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.09f,0.09f,0.91f); //blue
			animator.SetInteger("colorInt", 1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && greenPowers == true) {
			currentColor = PlayerColor.Green;
			//gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.05f,0.80f,0.05f); //planty green
			animator.SetInteger("colorInt", 2);
		}

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}


		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		
		velocity.x = input.x * moveSpeed;

		if (velocity.x == 0) {
			animator.SetBool("walking", false);
		} else {
			animator.SetBool("walking", true);
		}


		if (velocity.y > 0) {
			animator.SetInteger("vertical", 1);
		} else if (velocity.y < 0) {
			animator.SetInteger("vertical", -1);
		} else {
			animator.SetInteger("vertical", 0);
		}
		//Debug.Log (velocity.y);
		Debug.Log (animator.GetInteger("vertical"));

		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);

	}

	public void setVelocity() {
		velocity = new Vector3 (0, 0, 0);
	}
}
