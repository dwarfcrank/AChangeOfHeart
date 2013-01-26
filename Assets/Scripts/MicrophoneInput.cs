using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {
	public float sensitivity = 1000;
	public float threshold = 5;		// 5 seems ok for bare foot
	
	float loudness = 0;

	uint numBeats = 5;
	uint currBeat = 0;
	float[] deltas;
	float lastTime;

	public float average_bpm;
	public int totalBeats;

	void Start() {
		audio.clip = Microphone.Start(null, true, 10, 44100);
		audio.loop = true; // Set the AudioClip to loop
		audio.mute = true; // Mute the sound, we don't want the player to hear it
		while (!(Microphone.GetPosition(null) > 0)){} // Wait until the recording has started
		audio.Play(); // Play the audio source!

		lastTime = Time.time;
		deltas = new float[numBeats];

		totalBeats = 0;
	}

	void Update(){
		loudness = GetAveragedVolume() * sensitivity;
		if(loudness > threshold)
		{
			float now = Time.time;
			float d = now - lastTime;

			if(d > 0.2)		// echo protection
			{
				deltas[currBeat] = d;
				lastTime = now;

				currBeat++;
				currBeat = currBeat % numBeats;

				float av_d = GetAverageDelta();
				average_bpm = 60.0f / av_d;

				totalBeats++;

				Debug.Log("Loudness: " + loudness);
				Debug.Log("Last delta: " + d);
				Debug.Log("Average delta: " + av_d);
				Debug.Log("Average BPM: " + average_bpm);
			}
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

	float GetAverageDelta()
	{
		float sum = 0;
		foreach(float d in deltas)
		{
			sum += d;
		}
		return sum/numBeats;
	}
}