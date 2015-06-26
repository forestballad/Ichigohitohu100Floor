using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : MonoBehaviour {
	static int MAX_LEVEL = 49;
	public int stepNumber;
	public int levelNumber;
	public int Koban;
	public GameObject regularStep;
	public GameObject successObject;

	int[] levels = new int[100];

	void Awake(){
		successObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		GameObject.Find ("LevelIndicator").GetComponent<Text> ().text = "1";
		stepNumber = 0;
		levelNumber = 0;
		InitializeLevel ();
		GameObject firstStep = Instantiate (regularStep);
		firstStep.GetComponent<StepCommonBehavior> ().SetStepPosition (new Vector2 (-0.9f,-1.5f));
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
		if (levelNumber == MAX_LEVEL) {
			GetComponent<GenerateSteps>().StopCreateSteps();
			successObject.SetActive(true);
		}
		if (levelNumber > MAX_LEVEL) {
			levelNumber = MAX_LEVEL;
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
		gameObject.GetComponent<SceneControl> ().LoadFailScene ();
	}

	public void GetKoban(){
		Koban += 10;
		string kobanDisplay = Koban.ToString ();
		if (Koban >= 10 && Koban < 100) {
			kobanDisplay = "00" + kobanDisplay;
		} 
		else if (Koban >= 100 && Koban < 1000){
			kobanDisplay = "0" + kobanDisplay;
		}
		GameObject.Find ("KobanNumber").GetComponent<Text> ().text = kobanDisplay;
	}

	void DestroyAllSteps()
	{
		GameObject[] steps = GameObject.FindGameObjectsWithTag ("Step");
		for(var i = 0 ; i < steps.Length ; i ++)
		{
			Destroy(steps[i]);
		}
	}
}
