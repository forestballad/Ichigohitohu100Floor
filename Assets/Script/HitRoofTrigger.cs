using UnityEngine;
using System.Collections;

public class HitRoofTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			GameObject.Find ("Player").GetComponent<PlayerControl> ().TouchRoof();
		}
	}
}
