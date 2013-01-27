using UnityEngine;
using System.Collections;


public class Tutorial : MonoBehaviour
{
	public Texture[] texs;
	public MicrophoneInput mic;

	private uint curr_tex;
	
	// Use this for initialization
	void Start () 
	{
		curr_tex = 0;
		renderer.material.mainTexture = texs[curr_tex];
	}
	
	// Update is called once per frame
	private bool launched_calib = false;

	void Update()
	{
		if(launched_calib && !mic.calibrating)
		{
			// next scene!
			Debug.Log("pizza");
			Application.LoadLevel("intro");
		}


		if(Input.anyKeyDown)
		{
			curr_tex++;
			if(curr_tex < texs.Length)
			{
				renderer.material.mainTexture = texs[curr_tex];
				if(curr_tex == texs.Length - 1)
				{
					Debug.Log("Start the calib");
					launched_calib = true;
					mic.calibrating = true;
				}
			}	
		}
	}
}
