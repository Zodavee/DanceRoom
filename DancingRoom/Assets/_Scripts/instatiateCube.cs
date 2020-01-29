/*Made By Andre Azevedo */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instatiateCube: MonoBehaviour {
    public GameObject samplesPrefab;
    public int numb =512;
    public int radios = 100;
    
    public float maxScale;
    
	// Use this for initialization
	void Start () {
        // spawn several objects in a circule.  
        GameObject[] cubes = new GameObject[numb];
		for (int i = 0 ; i < numb; i++){
            GameObject instaCube =  Instantiate(samplesPrefab);
            instaCube.transform.position = this.transform.position;
            instaCube.transform.parent = this.transform;
            instaCube.name = "Cube " + i ;
            this.transform.eulerAngles = new Vector3 (0,(360/numb)*i,0) ;
            instaCube.transform.position = Vector3.forward*radios;
            cubes [i] = instaCube;
        }
	}
	
}
