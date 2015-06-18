﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float playerSpeed;
	public float playerHealth = 54;
	public float playerHealthCap = 54;
	public float bounceForce;
	public Rigidbody2D rgb2D;
	public Animator animator;

	// Use this for initialization
	void Start () {
		updateHealthBar ();
		animator.SetBool ("isAir", true);
		animator.SetBool ("isIdle", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("left")) {
			transform.position = new Vector2 (transform.position.x - playerSpeed, transform.position.y);
			animator.SetBool ("isFacingRight", false);
			animator.SetBool ("isIdle",false);
		} else if (Input.GetKey ("right")) {
			transform.position = new Vector2 (transform.position.x + playerSpeed, transform.position.y);
			animator.SetBool ("isFacingRight", true);
			animator.SetBool ("isIdle",false);
		} else {
			animator.SetBool ("isIdle",true);
		}
	}

	public void TouchHealStep(){
		playerHealth += 1;
		if (playerHealth > playerHealthCap) {
			playerHealth = playerHealthCap;
		}
		updateHealthBar();
		GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
	}

	public void TouchTrapStep(){
		playerHealth -= 5;
		updateHealthBar();
		if (playerHealth <= 0) {
			playerHealth = 1;
			GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
			GameObject.Find("Scripts").GetComponent<GameController>().OnGameFail();
			updateHealthBar();
		}
		GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
	}

	public void TouchRoof(){
		playerHealth -= 16;
		updateHealthBar();
		if (playerHealth <= 0) {
			playerHealth = 1;
			GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
			GameObject.Find("Scripts").GetComponent<GameController>().OnGameFail();
			updateHealthBar();
		}
		GameObject.Find ("HealthIndicator").GetComponent<Text> ().text = playerHealth.ToString();
	}

	public void MoveByStep(int moveDirection, float moveSpeed){
		transform.position = new Vector2 (transform.position.x + moveDirection * moveSpeed, transform.position.y);
	}

	public void TouchBounceStep(){
		rgb2D.AddForce (new Vector2(0,bounceForce));
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Step") {
			animator.SetBool("isAir",false);
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Step") {
			animator.SetBool("isAir",true);
		}
	}

	void updateHealthBar(){
		GameObject.Find("HealthBar").GetComponent<RectTransform>().sizeDelta = new Vector2(playerHealth*3,20);
		if (playerHealth > 35) {
			GameObject.Find ("HealthBar").GetComponent<Image> ().color = Color.green;
		} else if (playerHealth > 20) {
			GameObject.Find ("HealthBar").GetComponent<Image> ().color = Color.yellow;
		} else {
			GameObject.Find ("HealthBar").GetComponent<Image> ().color = Color.red;
		}
	}
}
