using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {
	public float sensitivity = 1000;
	public float threshold = 5;		// 5 seems ok for bare foot
	
	float loudness = 0;

	List<float> beats;

	public float average_bpm;
	public int totalBeats;

	void Start() {
		audio.clip = Microphone.Start(null, true, 10, 44100);
		audio.loop = true; // Set the AudioClip to loop
		audio.mute = true; // Mute the sound, we don't want the player to hear it
		while (!(Microphone.GetPosition(null) > 0)){} // Wait until the recording has started
		audio.Play(); // Play the audio source!

		beats = new List<float>();
		totalBeats = 0;
	}

	uint av_update_count = 0;
	public float window = 8;

	void Update()
	{
		float now = Time.time;

		loudness = GetAveragedVolume() * sensitivity;
		if(loudness > threshold)
		{
			if(beats.Count > 0)		// echo protection
			{
				float prev = beats[beats.Count - 1];
				if(now - prev > 0.2)
				{
					beats.Add(now);
					totalBeats++;
				}
	
				Debug.Log("Loudness: " + loudness);
			}
			else
			{
				beats.Add(now);
				totalBeats++;
			}
		}

		// Run average once in a while
		av_update_count++;
		if(av_update_count % 10 == 0)
		{
			float begin = now - window;
			while(beats.Count > 0 && beats[0] < begin)
			{
				beats.RemoveAt(0);
			}

			// The easy way
			average_bpm = beats.Count / window * 60.0f;
		}
	}

	float GetAveragedVolume()
	{ 
		float[] data = new float[256];
		float a = 0;
		audio.GetOutputData(data,0);
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a/256;
	}
}