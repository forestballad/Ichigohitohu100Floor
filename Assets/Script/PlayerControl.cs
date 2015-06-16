using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float playerSpeed;
	public float playerHealth = 54;
	public float playerHealthCap = 54;
	public float bounceForce;
	public Rigidbody2D rgb2D;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("left")) {
			transform.position = new Vector2 (transform.position.x - playerSpeed, transform.position.y);
		} else if (Input.GetKey ("right")) {
			transform.position = new Vector2 (transform.position.x + playerSpeed, transform.position.y);
		}
	}

	public void TouchHealStep(){
		playerHealth += 5;
		if (playerHealth > playerHealthCap) {
			playerHealth = playerHealthCap;
		}
		GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
	}

	public void TouchTrapStep(){
		playerHealth -= 14;
		if (playerHealth <= 0) {
			playerHealth = 1;
			GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
			GameObject.Find("Scripts").GetComponent<GameController>().OnGameFail();
		}
		GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
	}

	public void TouchRoof(){
		playerHealth -= 20;
		if (playerHealth <= 0) {
			playerHealth = 1;
			GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
			GameObject.Find("Scripts").GetComponent<GameController>().OnGameFail();
		}
		GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
	}

	public void MoveByStep(int moveDirection, float moveSpeed){
		transform.position = new Vector2 (transform.position.x + moveDirection * moveSpeed, transform.position.y);
	}

	public void TouchBounceStep(){
		rgb2D.AddForce (new Vector2(0,bounceForce));
	}
}
