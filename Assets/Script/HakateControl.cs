using UnityEngine;
using System.Collections;

public class HakateControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (Random.Range (-2.5f, 2.5f), transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Application.LoadLevel("GameSuccess");
		}
	}
}
