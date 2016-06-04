using UnityEngine;
using System.Collections;

public class XZPosEqualPlayer : MonoBehaviour
{


    private Transform m_player;
    public bool useZYPosition = false;

    // Use this for initialization
    void Start()
    {

        if (m_player == null)
            m_player = GameObject.FindGameObjectWithTag("MainCamera").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(!useZYPosition)
        transform.position = new Vector3(m_player.position.x, transform.position.y, m_player.position.z);
        else
            transform.position = new Vector3(transform.position.x, m_player.position.y, m_player.position.z);


    }
}
