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
		happyText.renderer.enabled = false;
		angryText.renderer.enabled = false;
		isAngry = false;
	}
	
	// Update is called once per frame
	void Update () {
		// CHEAPEST HACK EVER :D
		try 
		{
			GameObject.Find("cloud(Clone)").renderer.material = angryCloud; 
		}
		catch(System.Exception ex) {}
		if (isAngry) {
		sky.renderer.material.mainTexture = angrySky;
		sun.renderer.material.mainTexture = angrySun;
		angryText.renderer.enabled = true;
		happyText.renderer.enabled = false;
			
		}
		else if (!isAngry) {
			// CHEAPEST HACK EVER part deux
			try
			{
				GameObject.Find("cloud(Clone)").renderer.material = happyCloud;
			}
			catch(System.Exception ex) {}
		sky.renderer.material.mainTexture = happySky;
		sun.renderer.material.mainTexture = happySun;
		angryText.renderer.enabled = false;
		if (Movement.screenArea != 2) {happyText.renderer.enabled = true;}
			
		}
		if(Movement.screenArea == 1) {
				isAngry = true;
			}
		else if(Movement.screenArea == 2) {
				isAngry = false;
				happyText.renderer.enabled = false;
			}
		else if(Movement.screenArea == 3) {
				isAngry = false;
				happyText.renderer.enabled = true;
			}
	}
}
