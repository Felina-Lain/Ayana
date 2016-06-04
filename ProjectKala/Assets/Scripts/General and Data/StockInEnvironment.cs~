using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class StockInEnvironment : MonoBehaviour {


    public string m_nameEnvironment = "Environment";

    // Use this for initialization
    void Update () {

        GameObject environment = GameObject.FindGameObjectWithTag(m_nameEnvironment); 

        if(environment == null)
        {
            environment = new GameObject();
            environment.transform.position = Vector3.zero;
            environment.transform.rotation = Quaternion.identity;
            environment.transform.localScale = Vector3.one;
            environment.tag = m_nameEnvironment;
            environment.name = m_nameEnvironment;
                }

        transform.parent = environment.transform;
        this.enabled = false; 
       // DestroyImmediate(this); 
	
	}
	
}
