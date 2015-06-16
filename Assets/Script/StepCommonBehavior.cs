using UnityEngine;
using System.Collections;

public class StepCommonBehavior : MonoBehaviour {
	public float movingSpeed;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2(-2.78f + 0.376f * Random.Range (0,11), -2.66f);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 2.6f) {
			GameObject.Find("Scripts").GetComponent<GameController>().AddOneBlock();
			Destroy(gameObject);
		}
	}

	void FixedUpdate(){
		transform.position = new Vector2 (transform.position.x, transform.position.y + movingSpeed);
	}
}
