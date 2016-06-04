using UnityEngine;
using System.Collections;

public class BlipWithTimer : MonoBehaviour {

    public bool active = true;
    [Range(0, 5)]
    public float timer = 2.5f;

    private float timeLeft = 0; 


    void Update()
    {
        timeLeft += Time.deltaTime;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);

        }

        if (timeLeft > timer)
        {
            active = !active;
            timeLeft = 0;
        }

    }


}
