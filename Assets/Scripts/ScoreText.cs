using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {
	
	private GUIText guiText;
	private MicrophoneInput mic;
	public int score;
	private Movement player;
	
	// Use this for initialization
	void Start () {
		guiText = gameObject.GetComponent<GUIText>();
		mic = GameObject.Find ("Beat Detector").GetComponent<MicrophoneInput>();
		player = GameObject.Find ("Player").GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		score = player.score;
	}
	
	void OnGUI() {		
		string text = string.Format("{0}", score);
		
		guiText.text = text;
	}
}
