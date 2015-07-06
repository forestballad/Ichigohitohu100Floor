using UnityEngine;
using System.Collections;

public class StepCommonBehavior : MonoBehaviour {
	public float movingSpeed;
	float[] pos = new float[8] {-2.77f,-2.27f,-1.72f,-1.17f,-0.62f,-0.07f,0.48f,0.98f};

	// Use this for initialization
	void Awake () {
		transform.position = new Vector2(pos[Random.Range (0,8)], -2.66f);
	}

	void Start(){

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

	public void SetStepPosition(Vector2 newPos){
		transform.position = newPos;
	}
}
