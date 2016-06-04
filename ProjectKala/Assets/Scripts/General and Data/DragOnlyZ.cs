using UnityEngine;
using System.Collections;

public class DragOnlyZ : MonoBehaviour
{

    public bool grabbed = false;
    public Color GrabbableColor;
    public GameObject playerCamera;
    public GameObject tintedObject; 


    void Start()
    {
        if (tintedObject == null)
            tintedObject = this.gameObject;
        if (playerCamera == null)
            playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    void Update()
    {
        if (grabbed)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, playerCamera.transform.position.z);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabber")
        {
            tintedObject.GetComponent<MeshRenderer>().material.color = GrabbableColor;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabber")
        {
            tintedObject.GetComponent<MeshRenderer>().material.color = Color.white;
            grabbed = false;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabber")
        {
            if (grabbed == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    grabbed = true;
                }
            }
            else if (grabbed == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    grabbed = false;
                }

            }
        }

    }





}
