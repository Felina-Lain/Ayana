using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyBind : MonoBehaviour {

	public static Dictionary<string, KeyCode> _keys = new Dictionary<string, KeyCode>();

	public Text up, left, down, right, jump, action;

	private GameObject currentKey;

	public Color normal, onClick;

	// Use this for initialization
	void Start () {

		_keys.Add ("Up", KeyCode.Z);
		_keys.Add ("Down", KeyCode.S);
		_keys.Add ("Right", KeyCode.D);
		_keys.Add ("Left", KeyCode.Q);
		_keys.Add ("Jump", KeyCode.Space);
		_keys.Add ("Action", KeyCode.E);

		up.text = _keys ["Up"].ToString();
		down.text = _keys ["Down"].ToString();
		left.text = _keys ["Left"].ToString();
		right.text = _keys ["Right"].ToString();
		jump.text = _keys ["Jump"].ToString();
		action.text = _keys ["Action"].ToString();
	
	}
	
	// Update is called once per frame
	void OnGUI () {

		if (currentKey != null)
		{		
			Event e = Event.current;
			if (e.isKey)
			{

				_keys [currentKey.name] = e.keyCode;
				currentKey.transform.GetChild(2).GetComponent<Text> ().text = e.keyCode.ToString ();
				currentKey.GetComponent<Image> ().color = normal;
				currentKey = null;

			}
		
		}

	
	}

	public void ChangeKey(GameObject clicked){

		if(currentKey != null)
		{
			currentKey.GetComponent<Image> ().color = normal;

		}

		currentKey = clicked;
		currentKey.GetComponent<Image> ().color = onClick;

	}
}
