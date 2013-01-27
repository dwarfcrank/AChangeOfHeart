using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {
	
	private GUIText guiText;
	private MicrophoneInput mic;
	public int score;
	
	// Use this for initialization
	void Start () {
		guiText = gameObject.GetComponent<GUIText>();
		mic = GameObject.Find ("Beat Detector").GetComponent<MicrophoneInput>();
	}
	
	// Update is called once per frame
	void Update () {
		score = mic.totalBeats - grannyCollision.GetTotalScoreLoss();
		score = Mathf.Max(0, score);
	}
	
	void OnGUI() {
		
		string text = string.Format("{0}", score);
		
		guiText.text = text;
	}
}
