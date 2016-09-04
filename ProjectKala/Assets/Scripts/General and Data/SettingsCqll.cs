using UnityEngine;
using System.Collections;

public class SettingsCqll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void CallMenu (GameObject canvasOn) {

		canvasOn.gameObject.SetActive(true);

	}

	public void OffMenu (GameObject canvasOff) {

		canvasOff.gameObject.SetActive(false);	
	}
}
