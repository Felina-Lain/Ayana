using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ObjectController : MonoBehaviour
{


    //TO DO: CREATE A NEW STENCIL MATERIAL IF IT DOESNT EXIST FROM THE STANDARD MATERIAL (IF THERE IS ONE)

    public const string tagName = "Generated";

    public enum ObjectType
    {
        standard, world, mirror, window, veil, mirrorWindow, allReflections, screenProjection, Invisible
    };

    public ObjectType thisType = ObjectType.standard;

    public bool m_childCreated = false;


    public bool m_static;

	public bool isVeiled = false;
	public bool startVisible;
    public bool isDraggable;
    public bool makeStep = true;
    public bool activatesMecanisms = false; 
    public Material m_standardMaterial = null;
    public Material m_stencilMaterial = null;
    [HideInInspector]
    public Vector3 startPosition; 

    void Start()
    {
        startPosition = transform.position; 

    }

    void OnTriggerEnter(Collider other)
    {


    }






    public void SetType(LayerMask layer, Material material)
    {
        if (Application.isPlaying)
            return; 


        SetLayer(layer);
        ApplyMaterial(material);
		IsVeiled();
        if (activatesMecanisms)
            SetActivator(); 
        
        gameObject.isStatic = (m_static == true) ? true : false; 

    }

    public void CreateChild(ObjectType type)
    {
        if (Application.isPlaying)
            return;

        if (!m_childCreated)
        {
            GameObject childObject = new GameObject();
            childObject.transform.parent = gameObject.transform;
            childObject.transform.position = Vector3.zero;
            childObject.transform.rotation = Quaternion.identity;
            childObject.transform.localScale = Vector3.one;
            childObject.tag = ObjectController.tagName;
            // childObject.name = name + "Window"; 
            MeshRenderer mr = childObject.AddComponent<MeshRenderer>();
            mr.receiveShadows = false;
            mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off; 
            ObjectController oc = childObject.AddComponent<ObjectController>();
            oc.thisType = type;
            oc.m_standardMaterial = m_standardMaterial;
            oc.m_stencilMaterial = m_stencilMaterial;
            oc.isDraggable = isDraggable;
            oc.m_static = m_static;
			oc.isVeiled = isVeiled;
            oc.SetType(LayerMask.NameToLayer("Default"), oc.m_stencilMaterial);
            m_childCreated = true;
        }



    }

    public void DestroyChildren(string tagName)
    {
        foreach (Transform child in transform)
        {
            if (child.tag == tagName)
                DestroyImmediate(child.gameObject);
        }
        m_childCreated = false;

    }


    private void SetLayer(LayerMask layer)
    {
        gameObject.layer = layer;
    }


    private void ApplyMaterial(Material material)
    {
        if (GetComponent<MeshRenderer>() != null)
            if (material != null)
            {
                GetComponent<MeshRenderer>().material = material;
            }
    }

    private void resetBools()
    {
        isDraggable = false;
        m_static = true;

    }

    private void SetStatic()
    {
        gameObject.isStatic = m_static;
    }

	private void IsVeiled(){
		if (this.GetComponent<MaterialFadeIn> () == null)
			return;

		if(isVeiled){
			this.GetComponent<MaterialFadeIn>().enabled = true;
		}else{
			this.GetComponent<MaterialFadeIn>().enabled = false;
		}
	}

    private void SetActivator()
    {
        gameObject.tag = "Activator"; 
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }

    }


    private void OnDrawGizmos()
    {
        if(thisType == ObjectType.window)
        {
            Gizmos.DrawCube(transform.position, transform.localScale); 
        }
    }


}
