using UnityEngine;
using System.Collections;

public class RenderOnZone : MonoBehaviour
{


    public ProbeOptimization probe;

    void Start()
    {
        if (probe == null || !probe.useRenderZone)
            Destroy(gameObject);

     //   Debug.Log(probe); 
    }




    void OnTriggerEnter(Collider other)
    {
      //  Debug.Log("OnTriggerEntered");
      //  Debug.Log(other.name + other.tag); 
        if (other.tag == "Grabber" || other.tag == "Player")
        {
        //    Debug.Log("CollisionWithPlayer");

            probe.render = true;
            probe.Initialize();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabber" || other.tag == "Player")
        {
            probe.render = true;
        }
    }



}
