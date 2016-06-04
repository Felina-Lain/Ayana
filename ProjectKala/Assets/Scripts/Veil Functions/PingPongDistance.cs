using UnityEngine;
using System.Collections;

public class PingPongDistance : MonoBehaviour
{

    //Direction to move
    public Vector3 MoveDir = Vector3.zero;

    //Speed to move - units per second
    public float Speed = 0.0f;

    public bool facingRight;

    //Distance to travel in world units before inverting direction and turning back
    public float TravelDistance = 0.0f;

    //cached transform
    private Transform ThisTransform = null;

    //---------------------------------------------------------------------------------
    // Use this for initialization
    IEnumerator Start()
    {

        //get this cached transform
        ThisTransform = transform;

        //loop forever
        while (true)
        {

            //invert direction
            MoveDir *= -1;
            DoFlip();

            // start movement
            yield return StartCoroutine(Travel());

        }


    }

    void DoFlip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    //---------------------------------------------------------------------------------
    //travel full distance in direction frum current position
    IEnumerator Travel()
    {
        //distance travelled so far 
        float DistanceTravelled = 0;

        //Move
        while (DistanceTravelled < TravelDistance)
        {

            //Get new position based on speed and direction
            Vector3 DistToTravel = MoveDir * Speed * Time.deltaTime;

            //Update Position
            ThisTransform.position += DistToTravel;

            //Update distance travelled so far 
            DistanceTravelled += DistToTravel.magnitude;

            //wait until next update
            yield return null;

        }

    }
}
