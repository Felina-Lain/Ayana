using UnityEngine;
using System.Collections;

public class DontDestroyOnLevelChange : MonoBehaviour
{

    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
