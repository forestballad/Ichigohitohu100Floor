using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : MonoBehaviour {
	public int stepNumber;
	public int levelNumber;

	int[] levels = new int[100];
	// Use this for initialization
	void Start () {
		GameObject.Find ("LevelIndicator").GetComponent<Text> ().text = "1";
		stepNumber = 0;
		levelNumber = 0;
		InitializeLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddOneBlock(){
		stepNumber++;
		if (stepNumber == levels [levelNumber]) {
			levelNumber++;
			stepNumber = 0;
			GameObject.Find ("LevelIndicator").GetComponent<Text> ().text = (levelNumber + 1).ToString();
		}
		if (levelNumber == 100) {
			// Load Game Success Scene
		}
	}

	void InitializeLevel(){
		int[] min = {5,4,6,6,7,7,9,6,8,8,8};
		int[] max = {7,6,8,8,10,9,10,8,15,12};
		for (int i = 0;i<10;i++){
			for (int j = 0;j<10;j++){
				levels[i*10+j] = Random.Range(min[i],max[i]+1);
			}
		}
		levels [99] = Random.Range (8, 14);
	}

	public void OnGameFail(){
		Application.LoadLevel ("Game");
	}
}
