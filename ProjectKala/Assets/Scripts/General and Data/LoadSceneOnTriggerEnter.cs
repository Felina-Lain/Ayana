using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnTriggerEnter : MonoBehaviour
{

    public string sceneToLoad; 

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            if (Application.CanStreamedLevelBeLoaded(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("Scene " + sceneToLoad + " could not be loaded, make sure it has the right name and it has been added to the build settings");
            }

            if (sceneToLoad == null || sceneToLoad != "")
            {

             //   Debug.Log("please insert a valid name for the scene");
            }
        }
    }
}
