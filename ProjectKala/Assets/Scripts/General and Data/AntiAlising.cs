using UnityEngine;
using System.Collections;

public class AntiAlising : MonoBehaviour {

    [Range(0,8)]
    public int antialising = 2; 

    void Start()
    {
        QualitySettings.antiAliasing = antialising;
    }

}