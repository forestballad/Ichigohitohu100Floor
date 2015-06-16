using UnityEngine;
using System.Collections;

public class SceneControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadTheGame(){
		Application.LoadLevel("Game");
	}

	public void LoadFailScene(){
		Application.LoadLevel("GameFail");
	}

	public void LoadTitle(){
		Application.LoadLevel("Title");
	}

	public void LoadSuccessScene(){
		Application.LoadLevel("GameSuccess");
	}
}
