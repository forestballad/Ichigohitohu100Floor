using UnityEngine;
using System.Collections;

public class BreakStepBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			GameObject.Find("Player").GetComponent<PlayerControl>().TouchHealStep();	
		}
		StartCoroutine(DestroyAfterTime());
	}

	IEnumerator DestroyAfterTime() {
		yield return new WaitForSeconds(0.5f);
		Destroy (gameObject);
	}
}
