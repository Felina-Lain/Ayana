using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class ForContinue : MonoBehaviour {


	// Update is called once per frame
	public void Continued () {

		if(File.Exists(Application.persistentDataPath + "savegame.bananasplit")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "savegame.bananasplit", FileMode.Open);
			int dataa = (int)bf.Deserialize(file);

			SceneManager.LoadScene(dataa);
	
		}
	}

	public void Quitt (){

		Application.Quit();

	}
}
