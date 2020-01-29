/*Made by Andre Azevedo */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class Curser : MonoBehaviour {
	FirstPersonController fpc; 
	public bool en = true;
	// Use this for initialization
	void Start () {
		fpc = GetComponent<FirstPersonController>();		
	}
	
	// Update is called once per frame
	void Update () {
		// hide/show the cursor
		 
		if(Input.GetButtonUp("CRTL")){
			
			if(en){
				Debug.Log (Cursor.visible);
			Cursor.visible= true;
			Cursor.lockState=	CursorLockMode.None;
			
			}else{
			Cursor.visible= false;
			Cursor.lockState=	CursorLockMode.Locked;
			}
			fpc.enabled = !en;
			en = !en;

		}
	}
}
