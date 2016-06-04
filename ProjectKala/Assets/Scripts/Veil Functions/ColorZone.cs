using UnityEngine;
using System.Collections;

public class ColorZone : MonoBehaviour {

	public GameObject filter1;
	public string zoneColor1;


	// Use this for initialization
	void OnTriggerEnter () {

		if(this.tag == zoneColor1){
			filter1.GetComponent<MeshRenderer>().enabled = true;
		}
	
	}

	void OnTriggerExit () {

		filter1.GetComponent<MeshRenderer>().enabled = false;

	}

	// Update is called once per frame
	void Start () {
	
		filter1.GetComponent<MeshRenderer>().enabled = false;

	}
}
