using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public GameObject platform;
	public GameObject player1;
	public Object newPlatform;
	private Vector2 playerPosition;
	Vector2 mousePosition;
	Player playerScript;

	void Start () {
		GameObject player1 = GameObject.Find("Player1");
		playerScript = player1.GetComponent<Player>();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0) && Player.currentColor == Player.PlayerColor.Yellow && playerScript.GetComponent<Controller2D>().collisions.below==true) {
			Debug.Log ("E pressed");
			Spawn ();
		}
	}

	public void Spawn() {
		float x = (Input.mousePosition.x);
		float y = (Input.mousePosition.y);
		mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (x,y,0));
		//float x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
		//float y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
		playerPosition = new Vector2 (x, y);

		if (newPlatform != null) {
			Destroy (newPlatform);
		}
		newPlatform = Instantiate(platform, mousePosition, Quaternion.identity);
		//playerPosition = mousePosition;
	}
}
