/*Made By Andre Azevedo */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParamSphere : MonoBehaviour {
	public int band;
    public float sScale, scaleMultiplier;
    public bool usebuffer;
    public bool itself;
     public bool rotate;

    public float speed;
    public Transform position;
    	
	// Update is called once per frame
	void Update () {
        if(rotate){
            if(itself){
                //Rotates the object around itself
                transform.RotateAround(transform.position , Vector3.up , speed* Time.deltaTime);
            }
            if(!itself){
                //Rotates the object around another objec 
                transform.LookAt(position);
                transform.RotateAround( Vector3.zero*(transform.position.z*(AudioAnalyser.bandBuffer[band]* scaleMultiplier)+sScale) , Vector3.up , speed* Time.deltaTime);
            }
        }
        if(usebuffer){
            //scale accordind to the band value with a buffer, for a smoth transition
		    transform.localScale = new Vector3 ((AudioAnalyser.bandBuffer[band]* scaleMultiplier)/sScale, (AudioAnalyser.bandBuffer[band]* scaleMultiplier)/sScale, (AudioAnalyser.bandBuffer[band]* scaleMultiplier)/sScale);
        }
        
        if(!usebuffer){
            //scale accordind to the band value without a buffer
		transform.localScale = new Vector3 ((AudioAnalyser.freqBands[band]* scaleMultiplier)+sScale, (AudioAnalyser.freqBands[band]* scaleMultiplier)+sScale,(AudioAnalyser.freqBands[band]* scaleMultiplier)+sScale);
        }
    }
}
