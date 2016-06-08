using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour
{

    public int currentLvl;
    public List<string> levels = new List<string>();


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
            print("current" + currentLvl);
        }

        yield return new WaitForEndOfFrame();
    }
}
