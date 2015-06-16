using UnityEngine;
using System.Collections;

public class GenerateSteps : MonoBehaviour {
	public float invokeInterval;
	//order: 0 Regular, 1 Break, 2 Trap, 3 Bounce, 4 MovingLeft 5 MovingRight 
	public GameObject[] steps = new GameObject[6];
	public GameObject player;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("createStep", 0f, invokeInterval);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void createStep(){
		int stepType = Random.Range (0,5);
		if (stepType == 4) {
			stepType = Random.Range (4,6);
		}
		Instantiate (steps[stepType]);
	}
}
