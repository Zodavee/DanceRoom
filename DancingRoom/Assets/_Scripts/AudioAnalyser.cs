/*Made By Andre Azevedo */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioAnalyser : MonoBehaviour {
	
	AudioSource audioS ;
	public static float [] samples = new float [512];
	public static float[] freqBands= new float[8];
	public static float[] bandBuffer = new float[8];
	float [] bufferDecrease = new float [8];
	// Use this for initialization
	void Start () {
		//finds the audio source
		audioS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if(audioS == null){
			// if it didnt found the audio source, ty to find it again
			audioS = GetComponent<AudioSource>();
		}
		GetSpectrum();
		MakeBands();
		theBuffer();
	}
	void GetSpectrum(){
		// gets all the music samples and alocats them in to the samples array
		audioS.GetSpectrumData(samples,0,FFTWindow.Blackman);
	}

	void MakeBands(){
		float average = 0;
		int count = 0 ;
		//divides all the sample it to only 8, by taking the average sample, as the main sample.
		for (int i = 0 ; i < 8; i++){
		
			int sampleCount = (int) Mathf.Pow (2, i ) * 2 ;

			if ( i ==7){
				sampleCount += 2; // add the last 2 samples to the 7 bands 
			}
			for (int j = 0; j < sampleCount ; j ++){
				average += samples [count] * (count + 1);	
				count ++;

			}
		
		average /= count;
		freqBands [i] = average * 10; 

		}

	}
	void theBuffer(){
		// make a buffer so that there is a smooth transition for one value to another 
		for (int b = 0; b < 8 ; ++b){
			if (freqBands [b]> bandBuffer[b] ){
				bandBuffer [b] = freqBands [b];
				bufferDecrease [b] = 0.005f;
			}
			else if (freqBands [b]< bandBuffer[b] ){
				bandBuffer [b] -= bufferDecrease [b];
				bufferDecrease [b] *= 1.2f;
			
			}
		}
	}

}
