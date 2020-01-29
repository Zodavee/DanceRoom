/*Made By Andre Azevedo */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParamMove : MonoBehaviour {
	public int band;
    public float sScale, scaleMultiplier;
    public bool usebuffer;
  
    
	// Update is called once per frame
	void Update () {
        
       
        if(usebuffer){
			//moves the object o the y axis depending on the beat, with buffer
			transform.localPosition = new Vector3 (transform.position.x, (AudioAnalyser.bandBuffer[band]* scaleMultiplier)+sScale, transform.position.z);
        }
        
        if(!usebuffer){
			//moves the object o the y axis depending on the beat, with buffer
			transform.localPosition = new Vector3 (transform.position.x, (AudioAnalyser.freqBands[band]* scaleMultiplier)+sScale,transform.position.z);
        }
    }
}
