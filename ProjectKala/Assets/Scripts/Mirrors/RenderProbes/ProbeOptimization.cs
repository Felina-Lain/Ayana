using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ReflectionProbe))]
public class ProbeOptimization : MonoBehaviour
{

    public enum Resolution { r256, r512, r1024, r2048 };

    [SerializeField]
    private bool useProbesPositionForOptimization = false;

    public bool useRenderZone = false;
    public bool renderOnPlayerSight = false;

    [SerializeField]
    private bool m_isInteractable = false;

    [SerializeField]
    private float m_requiredFrameUpdateRate = 30;

    [SerializeField]
    private float m_maxResolutionStartDistance = 20f;
    [SerializeField]
    private float m_mediumResolutionStartDistance = 40f;

    [SerializeField]
    private Resolution minResolution = Resolution.r512;

    [SerializeField]
    private Resolution mediumResolution = Resolution.r1024;

    [SerializeField]
    private Resolution maxResolution = Resolution.r2048;

    public bool render = true;

    private int m_maxResolution = 2048;
    private int m_mediumResolution = 1024;
    private int m_minResolution = 512;

    private ReflectionProbe m_rProbe;
    private float m_forWaitForSecFloat;
    [SerializeField]
    private GameObject m_player;
    private float m_distanceFromPlayer;
    private bool m_refreshModeEveryFrame = false;



    void Start()
    {

        switch (maxResolution)
        {
            case Resolution.r2048:
                m_maxResolution = 2048;
                break;
            case Resolution.r1024:
                m_maxResolution = 1024;
                break;
            case Resolution.r512:
                m_maxResolution = 512;
                break;
            case Resolution.r256:
                m_maxResolution = 256;
                break;
        }

        switch (mediumResolution)
        {
            case Resolution.r2048:
                m_mediumResolution = 2048;
                break;
            case Resolution.r1024:
                m_mediumResolution = 1024;
                break;
            case Resolution.r512:
                m_mediumResolution = 512;
                break;
            case Resolution.r256:
                m_mediumResolution = 256;
                break;
        }

        switch (minResolution)
        {
            case Resolution.r2048:
                m_minResolution = 2048;
                break;
            case Resolution.r1024:
                m_minResolution = 1024;
                break;
            case Resolution.r512:
                m_minResolution = 512;
                break;
            case Resolution.r256:
                m_minResolution = 256;
                break;
        }

        Initialize();
        m_rProbe.RenderProbe();
    }



    void Update()
    {
        if (!useProbesPositionForOptimization)
            m_distanceFromPlayer = Vector3.Distance(gameObject.transform.parent.transform.position, m_player.transform.position);
        else
            m_distanceFromPlayer = Vector3.Distance(gameObject.transform.position, m_player.transform.position);

        m_rProbe.refreshMode = (m_refreshModeEveryFrame == true) ? UnityEngine.Rendering.ReflectionProbeRefreshMode.EveryFrame :
                                                                   UnityEngine.Rendering.ReflectionProbeRefreshMode.ViaScripting;
    }

    void OnEnable()
    {
        Initialize();
    }

    public void SetResolution(Resolution resolution, int valueToSet)
    {

        switch (resolution)
        {
            case Resolution.r2048:
                valueToSet = 2048;
                break;
            case Resolution.r1024:
                valueToSet = 1024;
                break;
            case Resolution.r512:
                valueToSet = 512;
                break;
            case Resolution.r256:
                valueToSet = 256;
                break;
        }
    }

    public void Initialize()
    {

        SetResolution(maxResolution, m_maxResolution);
        SetResolution(mediumResolution, m_mediumResolution);
        SetResolution(minResolution, m_minResolution);

        if (m_player == null)
            m_player = GameObject.FindGameObjectWithTag("Player");
        //  render = true;
        if (m_player == null)
            Debug.LogError("Player object not found for " + gameObject.name);
        if (m_isInteractable)
            m_refreshModeEveryFrame = true;
        m_forWaitForSecFloat = 1 / m_requiredFrameUpdateRate;
        m_rProbe = GetComponent<ReflectionProbe>();
        StartCoroutine(RefreshProbe());


    }

    IEnumerator RefreshProbe()
    {


        // Debug.Log("Coroutine Started");

        while (true)
        {
            if (m_refreshModeEveryFrame)
            {
                yield return new WaitForSeconds(1);
                m_refreshModeEveryFrame = false;
            }

            if (m_distanceFromPlayer < m_maxResolutionStartDistance)
            {
                m_rProbe.resolution = m_maxResolution;
            }
            else if (m_distanceFromPlayer > m_maxResolutionStartDistance && m_distanceFromPlayer < m_mediumResolutionStartDistance)
            {
                m_rProbe.resolution = m_mediumResolution;
            }
            else
            {
                m_rProbe.resolution = m_minResolution;
            }

            if (render)
            {
                m_rProbe.RenderProbe();
            }

            yield return new WaitForSeconds(m_forWaitForSecFloat);
        }

    }


    void OnBecameVisible()
    {
        //     StartCoroutine(RefreshProbe());
    }

    void OnBecameInvisible()
    {
        // Debug.Log("Coroutine Stopped");

        //   StopCoroutine(RefreshProbe());
    }



    void OnDisable()
    {
        if (m_isInteractable)
            m_refreshModeEveryFrame = true;
        StopCoroutine(RefreshProbe());

    }


}