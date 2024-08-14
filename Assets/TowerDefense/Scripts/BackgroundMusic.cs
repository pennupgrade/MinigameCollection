using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundMusic : MonoBehaviour
{

	public AudioSource[] musicSources;
	public AudioSource introSource;
	public int musicBPM, timeSignature, barsLength;

	public float introDelay;

	private float time;

	private float loopPointMinutes, loopPointSeconds;
	private int nextSource = 0;
	private float nextPlayTime;
	void Start()
	{
		loopPointMinutes = (barsLength * timeSignature) / (float)musicBPM;

		loopPointSeconds = loopPointMinutes * 60;

		time = 0;
		introSource.Play();

		nextPlayTime = introDelay;
	}
	void Update()
	{
		time += GameManager.Instance.timeSlowed? Time.deltaTime / 2 : Time.deltaTime;
		if (time >= nextPlayTime)
		{
			//Debug.Log("queued next audio source");
			nextPlayTime += loopPointSeconds;
			musicSources[nextSource].Play();
			nextSource = 1 - nextSource; //Switch to other AudioSource
		}


		if (GameManager.Instance.timeSlowed)
        {
			musicSources[0].pitch = 0.5f;
			musicSources[1].pitch = 0.5f;
			introSource.pitch = 0.5f;
		}
		else
        {
			musicSources[0].pitch = 1f;
			musicSources[1].pitch = 1f;
			introSource.pitch = 1f;
		}
	}
}
