/*Made by Andre Azevedo */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMusic : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// select 2 colour depending on the beat of the music
		Color col1 = Color.HSVToRGB(AudioAnalyser.bandBuffer[7]/2,Mathf.Clamp(AudioAnalyser.bandBuffer[3],0.2f,0.8f),AudioAnalyser.bandBuffer[1]/2);
		Color col2 = Color.HSVToRGB(AudioAnalyser.bandBuffer[7]/2,Mathf.Clamp(AudioAnalyser.bandBuffer[3],0.2f,0.8f),AudioAnalyser.bandBuffer[1]/2);

		// make objec have a smooth transition from one colour to another
		GetComponent<Renderer>().material.color = Color.Lerp(col1,col2,20);

		
	}
}
