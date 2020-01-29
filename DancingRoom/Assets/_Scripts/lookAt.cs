/*Made by Andre Azevedo */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour {
	public GameObject obj;
	// Use this for initialization
	void Start () {
		// rotate the object in the targets direction 
		transform.LookAt(obj.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
