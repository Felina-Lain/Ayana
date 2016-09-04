using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class VolumeGestion : MonoBehaviour {

	public static Slider _sliderFX;
	public static Slider _sliderM;
	public static float _volumeFX = 0.1f;
	public static float _volumeM = 0.1f;


	// Update is called once per frame
	void Update () {
		
		_sliderFX = GameObject.Find ("FX").GetComponent<Slider> ();
		if (_sliderFX == null) return;
		_sliderM = GameObject.Find ("Music").GetComponent<Slider> ();
		if (_sliderM == null) return;

		_volumeFX = _sliderFX.value;
		_volumeM = _sliderM.value;

	}

}
