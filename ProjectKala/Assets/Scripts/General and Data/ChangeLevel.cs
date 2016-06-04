using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour
{

    public int currentLvl;
    public List<string> levels = new List<string>();

    [SerializeField]
    private AudioClip m_sound;
    private AudioSource m_AudioSource;
    [SerializeField]
    private bool m_playAudio = false; 
    [SerializeField]
    private bool m_waitForSeconds = false;

    void Start()
    {

        string current = SceneManager.GetActiveScene().name;
        m_AudioSource = this.GetComponent<AudioSource>();

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
        if (m_playAudio)
        {
            if (m_AudioSource != null)
            {
                if (m_sound != null)
                    m_AudioSource.clip = m_sound;

                m_AudioSource.Play();

            }
        }
        if (m_waitForSeconds)
            yield return new WaitForSeconds(1f);

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
