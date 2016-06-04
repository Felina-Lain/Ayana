using UnityEngine;
using System.Collections;

public class MirrorOFF : MonoBehaviour
{

    void TriggerEnter(Collider _col)
    {

        ProbeOptimization po = _col.GetComponentInChildren<ProbeOptimization>();

        if (po != null)
        {
            if (po.renderOnPlayerSight == true)
                po.render = true;
            po.Initialize(); 
        }
    }

    void OnTriggerExit(Collider _col)
    {

        ProbeOptimization po = _col.GetComponentInChildren<ProbeOptimization>();

        if (po != null)
        {
            if (po.renderOnPlayerSight == true)
                po.render = false;
        }
    }
}
