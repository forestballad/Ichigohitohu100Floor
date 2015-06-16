﻿using UnityEngine;
using System.Collections;

public class StepCommonBehavior : MonoBehaviour {
	public float movingSpeed;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2(Random.Range (-1.88f, 1.88f), -2.84f);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 3f) {
			GameObject.Find("Scripts").GetComponent<GameController>().AddOneBlock();
			Destroy(gameObject);
		}
	}

	void FixedUpdate(){
		transform.position = new Vector2 (transform.position.x, transform.position.y + movingSpeed);
	}
}
