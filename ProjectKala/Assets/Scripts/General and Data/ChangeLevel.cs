using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class ChangeLevel : MonoBehaviour
{

    public int currentLvl;
    public List<string> levels = new List<string>();

	public int dataa;


    void Start()
    {

        string current = SceneManager.GetActiveScene().name;

        for (int i = 0; i < levels.Count; i++)
        {
            if (current.Contains(levels[i]))
            {
                currentLvl = i;
                //	print("i" + i);
            }
        }
    }


    void OnTriggerEnter(Collider _col)
    {

        if (_col.tag == "Player")
        {
            StartCoroutine(PlaySound());

			if (currentLvl != 0) {

				dataa = currentLvl + 1;
				print ("dataa" + dataa);
				print(Application.persistentDataPath);
			}

				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Create (Application.persistentDataPath + "savegame.bananasplit");
				bf.Serialize(file, dataa);
				file.Close();

        }
    }

    private IEnumerator PlaySound()
    {
        int _tip = levels.Count - 1;
        if (currentLvl == _tip)
        {
            SceneManager.LoadScene(levels[0]);
            print("reached");
        }
        if (currentLvl < _tip)
        {
            SceneManager.LoadScene(currentLvl + 1);
        }

        yield return new WaitForEndOfFrame();
    }
}
