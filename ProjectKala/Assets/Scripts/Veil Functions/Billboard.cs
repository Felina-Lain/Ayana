using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{

    public bool veilOnBillboarding = true;
    public bool veilOffBillboarding = true;

	public float toMe;
    public float lookTest = -1f;
    public bool mirrorMe = true; 


    private Transform thisTransform = null;

    void Start()
    {

        thisTransform = transform;


    }




    void BillboardFunction()
    {
        //the sprite faces the camera

//		Vector3 LookAtDir = new Vector3(Camera.main.transform.position.x - thisTransform.position.x, 0, Camera.main.transform.position.z - thisTransform.position.z);

        Vector3 LookAtDir = new Vector3(lookTest * (Camera.main.transform.position.x - thisTransform.position.x), 0,
                                        lookTest * (Camera.main.transform.position.z - thisTransform.position.z));
        if (mirrorMe)
            LookAtDir.x += 180f; 
        
        thisTransform.rotation = Quaternion.LookRotation(toMe * LookAtDir.normalized, Vector3.up);
    }
}
