using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ReflectionProbe))]
//[ExecuteInEditMode]
public class ControlProbe : MonoBehaviour
{
    public Vector3 Normal;
    [SerializeField]
    private bool m_bDebug = true;
    private GameObject m_mirror;
    private float m_offset;
    private Vector3 m_symmetricPoint;
    private GameObject m_playerCamera;
    private Mesh m_mesh;
    private Vector3 pointOnMirror;
    [SerializeField]
    private bool calculateNormals = true;

    void Start()
    {
        Initialize();
    }

    void OnEnable()
    {
        Initialize();
    }


    void FixedUpdate()
    {

        //UPDATE POSITION TO SYMMETRIC POINT
        Plane plane = new Plane(Normal, pointOnMirror);
        Vector3 projectionPlane = Formulas.ProjectPointOnPlane(m_playerCamera.transform.position, plane);
        m_symmetricPoint = projectionPlane - (m_playerCamera.transform.position - projectionPlane);
        transform.position = new Vector3(m_symmetricPoint.x, m_symmetricPoint.y, m_symmetricPoint.z);
        //    Vector3 cameraDirection = m_playerCamera.transform.forward;
        //  float scalarProduct = Vector3.Dot(Normal, cameraDirection);
        //  Vector3 mirroredDirection = cameraDirection - (2 * scalarProduct * Normal.normalized);
        // transform.LookAt(transform.position + mirroredDirection);

        if (m_bDebug && calculateNormals)
            if (Input.GetKeyDown(KeyCode.H))
                CalculateNormals();

    }

    private void Initialize()
    {

        m_mirror = transform.parent.gameObject;
        if (m_mirror == null)
            Debug.LogError("No Mirror GameObject Found for " + gameObject.name);


        //GET COMPONENTS
        m_playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (m_playerCamera == null)
            Debug.LogError("No Player GameObject Found for " + gameObject.name);

        m_mirror = transform.parent.gameObject;
        if (m_mirror == null)
            Debug.LogError("No Mirror GameObject Found for " + gameObject.name);

        m_mesh = this.GetComponentInParent<MeshFilter>().sharedMesh;

        if (calculateNormals)
            CalculateNormals();
    }

    public void CalculateNormals()
    {

        m_mesh.RecalculateNormals();
        Normal = m_mesh.normals[0];
        pointOnMirror = m_mesh.vertices[0];
        pointOnMirror = this.transform.parent.transform.TransformPoint(pointOnMirror);
        Normal = this.transform.parent.transform.TransformVector(Normal);
    }




}