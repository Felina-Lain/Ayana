using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BlockScale : MonoBehaviour {


	void OnTriggerEnter () {

        transform.localScale = Vector3.one; 
	
	}
	
		void OnTriggerExit () {

        transform.localScale = Vector3.one; 
	
	}
}
