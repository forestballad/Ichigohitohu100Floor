using UnityEngine;
using System.Collections;

public class BreakStepBehavior : MonoBehaviour {
	public float breakTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			GameObject.Find("Player").GetComponent<PlayerControl>().TouchHealStep();
			GameObject.Find("Scripts").GetComponent<GameController>().GetKoban();
			StartCoroutine(DestroyAfterTime());
		}
	}

	IEnumerator DestroyAfterTime() {
		yield return new WaitForSeconds(breakTime);
		Destroy (gameObject);
	}
}
