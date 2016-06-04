using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ChangePic : MonoBehaviour {

		// public List<string> pictures = new List<string>(); 
		public Material[] pictures = new Material[10];

		// Update is called once per frame
		void Update()
		{

			if (Input.GetKeyDown(KeyCode.Keypad0))
			{
				LoadPicture(0);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				LoadPicture(1);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad2))
			{
				LoadPicture(2);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad3))
			{
				LoadPicture(3);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad4))
			{
				LoadPicture(4);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad5))
			{
				LoadPicture(5);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad6))
			{
				LoadPicture(6);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad7))
			{
				LoadPicture(7);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad8))
			{
				LoadPicture(8);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad9))
			{
				LoadPicture(9);
			}
		}

		private void LoadPicture(int num)
		{
			
		this.GetComponent<MeshRenderer>().material = pictures[num];
			
		}
	}