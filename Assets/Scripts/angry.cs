using UnityEngine;
using System.Collections;

public class angry : MonoBehaviour {
	
	bool isAngry = false;
	public GameObject sky;
	public Texture2D angrySky;
	public Texture2D happySky;
	public GameObject sun;
	public Texture2D angrySun;
	public Texture2D happySun;
	public GameObject cloud;
	public Material angryCloud;
	public Material happyCloud;
	public GameObject happyText;
	public GameObject angryText;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (AngryTimer());
	}
	
	// Update is called once per frame
	void Update () {
		if (isAngry) {
		sky.renderer.material.mainTexture = angrySky;
		sun.renderer.material.mainTexture = angrySun;
		angryText.renderer.enabled = true;
		happyText.renderer.enabled = false;
		cloud.renderer.material = angryCloud;
		}
		else if (!isAngry) {
		sky.renderer.material.mainTexture = happySky;
		sun.renderer.material.mainTexture = happySun;
		angryText.renderer.enabled = false;
		happyText.renderer.enabled = true;
		cloud.renderer.material = happyCloud;
		}
	}
	IEnumerator AngryTimer() {
		do {
		isAngry = false;
		yield return new WaitForSeconds(5);
		isAngry = true;
		yield return new WaitForSeconds(5);
		} while (!deathCollision.gameOver);
	}
}
