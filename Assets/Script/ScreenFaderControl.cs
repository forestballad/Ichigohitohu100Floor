using UnityEngine;
using System.Collections;

public class ScreenFaderControl : MonoBehaviour {
	public int fadeDirection = 1;
	public float fadeSpeed;

	// Use this for initialization
	void Start () {
		GetComponent<CanvasGroup> ().alpha = 1;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<CanvasGroup> ().alpha -= fadeSpeed;
	}
}
