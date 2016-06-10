using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeGestion : MonoBehaviour {

	public Slider _slider;
	public static float _volume = 0.5f;

	void Start () {

		_slider = GameObject.Find("FX").GetComponent<Slider>();

	}
	
	// Update is called once per frame
	public void GetVolume () {

		_volume = _slider.value;
	
	}

}
