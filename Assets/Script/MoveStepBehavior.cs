using UnityEngine;
using System.Collections;

public class MoveStepBehavior : MonoBehaviour {
	public int moveDirection;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			GameObject.Find("Player").GetComponent<PlayerControl>().MoveByStep(moveDirection,moveSpeed);	
		}
	}
}
