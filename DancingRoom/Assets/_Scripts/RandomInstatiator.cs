/*Made By Andre Azevedo */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstatiator : MonoBehaviour {
	public GameObject [] gameObjects = new GameObject [8] ;
	public int numberOfInstants;



	// Use this for initialization
	void Start () {
		Setup();
	}
	public void Setup(){
		//clean the sceene
		 foreach (Transform child in transform) {
    		 GameObject.Destroy(child.gameObject);
 		}
		// alocate a place in the scene and select an object to put in that place and finaly change the objects color
		for(int i =0;  i < numberOfInstants ;i++){
			Vector3 position = new Vector3 ( Mathf.Round( Random.Range (-50,50)), Random.Range (0,20) , Mathf.Round( Random.Range (-50,50)) );
			
		

			int o = (int)Mathf.Round (Random.Range(0,gameObjects.Length));
			
			GameObject clone = Instantiate (gameObjects[o],position, this.gameObject.transform.rotation);
			clone.transform.parent = this.transform;
			clone.GetComponent<Renderer>().material.color =  Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
		}
	}
	

}
