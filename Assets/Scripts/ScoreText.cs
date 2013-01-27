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
	}
	
	void OnGUI() {
		score = mic.totalBeats - grannyCollision.GetTotalScoreLoss();
		string text = string.Format("{0}", score);
		
		guiText.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
		guiText.text = text;
	}
}
