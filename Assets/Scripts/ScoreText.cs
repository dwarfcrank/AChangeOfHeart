using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {
	
	private GUIText guiText;
	private GUITexture textBackground;
	private MicrophoneInput mic;
	public int score;
	private Movement player;
	
	// Use this for initialization
	void Start () {
		guiText = gameObject.GetComponent<GUIText>();
		textBackground = GameObject.Find("ScoreBackground").GetComponent<GUITexture>();
		mic = GameObject.Find ("Beat Detector").GetComponent<MicrophoneInput>();
		player = GameObject.Find ("Player").GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null) score = player.score;
		
		guiText.enabled = !deathCollision.gameOver;
		textBackground.enabled = !deathCollision.gameOver;
	}
	
	void OnGUI() {
		string text = string.Format("{0}", score);
		
		guiText.text = text;
	}
}
