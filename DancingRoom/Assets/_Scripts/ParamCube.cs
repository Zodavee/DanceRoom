/*Made by Andre Azevedo */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParamCube : MonoBehaviour {
	public int band;
    public float sScale, scaleMultiplier;
    public bool usebuffer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(usebuffer){
			//scale accordind to the band value with a buffer, for a smoth transition
		transform.localScale = new Vector3 (transform.localScale.x, (AudioAnalyser.bandBuffer[band]* scaleMultiplier)+sScale, transform.localScale.z);
        }
        
        if(!usebuffer){
			//scale accordind to the band value without a buffer
		transform.localScale = new Vector3 (transform.localScale.x, (AudioAnalyser.freqBands[band]* scaleMultiplier)+sScale, transform.localScale.z);
        }
    }
}
