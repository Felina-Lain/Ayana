using UnityEngine;
using System.Collections;

public class SpawnPlayerToPoint : MonoBehaviour
{

    public Transform spawnPoint; 

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.position = spawnPoint.position;
           // other.GetComponentInChildren<GrabbObject>().objectToGrabb = null; 
        }

        if(other.gameObject.GetComponent<ObjectController>() != null)
        {
          //  other.transform.position = other.gameObject.GetComponent<ObjectController>().startPosition; 
        }

    }
}
