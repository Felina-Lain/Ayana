using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformMove : MonoBehaviour
{
    [SerializeField]
    private bool m_bDebug = false;



    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.name == "Player")
        {
            if (m_bDebug)
                print("I hit player");
           other.transform.parent = this.transform;
        }
    }


    void OnTriggerExit(Collider other)
    {
		if (other.gameObject.name == "Player")
        {
            if (m_bDebug)
                print("I loose player");
            
			other.transform.parent = null;
        }
    }
}