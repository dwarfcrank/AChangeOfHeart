using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {
	
	// sensitivity is adjusted during calibration, so that the noise level roughly reaches
	// the number in noise_threshold (which is arbitrary and doesn't change). signal_noise_ratio
	// indicates how much higher than noise_threshold must be the sound input to trigger a beat
	// detection.

	private float sensitivity = 1000;
	private const float noise_threshold = 10;
	public float signal_noise_ratio = 5;
	
	List<float> beats;

	public float average_bpm = 0;
	public int totalBeats;

	public bool calibrating = true;

	float average_bpm_target = 0;

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
		if(calibrating)
		{
			UpdateCalibrating();
			return;
		}

		float now = Time.time;

		float loudness = GetAveragedVolume() * sensitivity;
		if(loudness > noise_threshold * signal_noise_ratio)
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
			average_bpm_target = beats.Count / window * 60.0f;
		}


		// Smoothing
		average_bpm += (average_bpm_target - average_bpm) * 0.1f;
		if(average_bpm < 1.0f)
		{
			average_bpm = 0.0f;
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

	private float curr_noise_level = 0;

	private bool wasAbove = false;
	private bool wasBelow = false;

	void UpdateCalibrating()
	{
		float inst_noise_level = GetAveragedVolume() * sensitivity;

		// Instant low pass filtering
		curr_noise_level += (inst_noise_level - curr_noise_level) * 0.01f;

		if(curr_noise_level < noise_threshold)
		{
			wasBelow = true;
			sensitivity += 10;
		}
		else
		{
			wasAbove = true;
			sensitivity -= 10;
		}

		if(wasAbove && wasBelow)
		{
			calibrating = false;
			Debug.Log("Calibrated to sensitivity: " + sensitivity);
		}
	}
}