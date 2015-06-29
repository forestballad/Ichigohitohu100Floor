using UnityEngine;
using System.Collections;

public class HakateControl : MonoBehaviour {
	int RICH_END = 700;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (Random.Range (-3f, 1f), transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (GameObject.Find("Scripts").GetComponent<GameController>().Koban >= RICH_END){
				Application.LoadLevel("GameRichSuccess");
			}
			else {
				Application.LoadLevel("GameSuccess");
			}
		}
	}
}
