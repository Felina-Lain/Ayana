using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadLevelOnKey : MonoBehaviour
{

    // public List<string> levels = new List<string>(); 
	public int currentLvl;
    public string[] levels = new string[12];

	void Start(){

		string current = SceneManager.GetActiveScene().name;

		for (int i = 0; i < levels.Length; i++){
			if( current.Contains(levels[i])){				
				currentLvl = i;
				//	print("i" + i);
			}
		}
	}
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.M))
		{
			LoadLevel(0);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadLevel(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadLevel(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadLevel(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoadLevel(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            LoadLevel(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            LoadLevel(6);
		}

	}

	public void LoadLevel(int level)
    {
        if (levels[level] != null || levels[level] != "")

            if (Application.CanStreamedLevelBeLoaded(levels[level]))
            {
                SceneManager.LoadScene(levels[level]);
            } else
            {
                Debug.Log("Scene " + levels[level] + " could be found but not loaded because it is not been added to the build settings"); 
            }
        else
        {
            Debug.Log("the scene " + level.ToString() + " couldn't be found, make sure the name on the list is the same name as the level's"); 
        }
    }
}
