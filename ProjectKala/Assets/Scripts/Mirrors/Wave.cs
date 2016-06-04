using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour
{
    //  public TimeWater tw;
    public Mesh mesh;
    public Vector3[] vertex;
    public Vector2 waterOffset = new Vector2(0.0f, 0.0f);
    [HideInInspector]
    public Vector2 waveOffset;
    [Range(0.001f, 0.75f)]
    public float waveStrength;
    [Range(0.001f, 10)]
    public float waveSpeed;
    [HideInInspector]
    public Color[] col;

    [HideInInspector]
    public float playerDist;
    public float distMin;
    private GameObject player;
    //public bool isVisible;
    // Use this for initialization
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player"); 
        }
        //player = GameObject.Find ("ThirdPersonController(Clone)");
        // tw = GameObject.Find("WorldController").GetComponent<TimeWater>();
        waterOffset = new Vector2(5.0f, 5.0f);
        waveOffset = new Vector2(transform.position.x * waterOffset.x, transform.position.z * waterOffset.y);
        // waveStrength = tw.waveStrength;
        //  waveSpeed = tw.waveSpeed;
        mesh = GetComponent<MeshFilter>().mesh;
        vertex = mesh.vertices;
        col = new Color[vertex.Length];
        for (int i = 0; i < vertex.Length; ++i)
        {
            vertex[i].z = Mathf.PerlinNoise((vertex[i].x + waveOffset.x) * waveStrength, (vertex[i].y + waveOffset.y) * waveStrength);
            col[i] = new Color(vertex[i].z, vertex[i].z, vertex[i].z, 0.75f);
        }
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.vertices = vertex;
        mesh.colors = col;
    }

    // Update is called once per frame
    void Update()
    {
        waveStrength = Mathf.Clamp(waveStrength, 0.0001f, waveStrength + 0.1f);
        waterOffset.x += Time.deltaTime * waveSpeed;
        waterOffset.y += Time.deltaTime * waveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<Renderer>().isVisible == true)
        {
            playerDist = Vector3.Distance(transform.position, player.transform.position);
            //if (playerDist <= distMin) 
            //{
            //waveSpeed = tw.waveSpeed;
            //waveStrength = tw.waveStrength;
            waveOffset.x = transform.position.x + waterOffset.x;
            waveOffset.y = -(transform.position.z + waterOffset.y);
            for (int i = 0; i < vertex.Length; ++i)
            {
                vertex[i].z = Mathf.PerlinNoise((vertex[i].x + waveOffset.x) * waveStrength, (vertex[i].y + waveOffset.y) * waveStrength);
                col[i] = new Color(vertex[i].z, vertex[i].z, vertex[i].z, 0.75f);
            }
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.vertices = vertex;
            mesh.colors = col;
        }
    }


}

