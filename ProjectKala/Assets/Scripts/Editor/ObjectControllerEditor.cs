using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic; 

[CustomEditor(typeof(ObjectController))]
public class ObjectControllerEditor : Editor {


    public Dictionary<string, SerializedProperty> _properties = new Dictionary<string, SerializedProperty>();
    public List<Property> _timingProperties = new List<Property>();

    public class Property
    {
        public string name;
        public string text;

        public Property(string n, string t)
        {
            name = n;
            text = t;
        }
    }


    public readonly Property OBJECT_TYPE = new Property("thisType", "Object Seen In:");
    public readonly Property IS_STATIC = new Property("m_static", "Static:");
    public readonly Property IS_DRAGGABLE = new Property("isDraggable", "Draggable:");
    public readonly Property MAKE_STEP = new Property("makeStep", "Make Step:");
	public readonly Property IS_VEILED = new Property("isVeiled", "Veiled:");
	public readonly Property START_VISIBLE = new Property("startVisible", "Start Visible:");
    public readonly Property MATERIAL_STANDARD = new Property("m_standardMaterial", "Standard Material:");
    public readonly Property MATERIAL_STENCIL = new Property("m_stencilMaterial", "Stencil Material:");
    public readonly Property ACTIVATES_MECANISMS = new Property("activatesMecanisms", "Activates mecanisms:");



    public void OnEnable()
    {
        _properties.Clear();
        SerializedProperty property = serializedObject.GetIterator();

        while (property.NextVisible(true))
        {
            _properties[property.name] = property.Copy();
        }

    }

    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        _timingProperties.Clear();

        ObjectController oc = target as ObjectController; 


        DisplayRegularField(OBJECT_TYPE);
        switch (oc.thisType)
        {
            case ObjectController.ObjectType.standard:
                oc.SetType(LayerMask.NameToLayer("Default"), oc.m_standardMaterial);
                oc.DestroyChildren(ObjectController.tagName);
                DisplayRegularInspector(); 
                break;
            case ObjectController.ObjectType.world:
                oc.SetType(LayerMask.NameToLayer("World"), oc.m_standardMaterial);
                oc.DestroyChildren(ObjectController.tagName);
                DisplayRegularInspector();
                break;
            case ObjectController.ObjectType.mirror:
                oc.SetType(LayerMask.NameToLayer("Mirror"), oc.m_standardMaterial);
                oc.DestroyChildren(ObjectController.tagName);
                DisplayRegularInspector();
                break;
            case ObjectController.ObjectType.window:
                oc.SetType(LayerMask.NameToLayer("Default"),oc.m_stencilMaterial);
                oc.DestroyChildren(ObjectController.tagName);
                DisplayRegularInspector();
                break;
            case ObjectController.ObjectType.veil:
                oc.SetType(LayerMask.NameToLayer("Veil"), oc.m_standardMaterial);
                oc.DestroyChildren(ObjectController.tagName);
                DisplayRegularInspector();
                break;
            case ObjectController.ObjectType.mirrorWindow:
                oc.SetType(LayerMask.NameToLayer("Mirror"), oc.m_standardMaterial);
                oc.CreateChild(ObjectController.ObjectType.window);
                DisplayRegularInspector();
                break;
            case ObjectController.ObjectType.allReflections:
                oc.SetType(LayerMask.NameToLayer("AllReflections"), oc.m_standardMaterial);
                oc.CreateChild(ObjectController.ObjectType.window);
                DisplayRegularInspector();
                break;
            case ObjectController.ObjectType.screenProjection:
                oc.SetType(LayerMask.NameToLayer("Projection"), oc.m_standardMaterial);
                DisplayRegularInspector();
                break;
            case ObjectController.ObjectType.Invisible:
                oc.SetType(LayerMask.NameToLayer("Invisible"), oc.m_standardMaterial);
                oc.DestroyChildren(ObjectController.tagName);
                DisplayRegularInspector();
                break;

        }

        serializedObject.ApplyModifiedProperties();

    }

    public void DisplayRegularInspector()
    {

        ObjectController oc = target as ObjectController;

        DisplayRegularField(IS_STATIC);
        EditorGUILayout.Separator();

        if (!oc.m_static)
        {
            DisplayRegularField(ACTIVATES_MECANISMS);
            EditorGUILayout.Separator(); 
            DisplayRegularField(IS_DRAGGABLE);
        }
        if (oc.isDraggable)
        {
            DisplayRegularField(MAKE_STEP);
            EditorGUILayout.Separator();
        }
        DisplayRegularField(IS_VEILED);
        if (oc.isVeiled && !oc.m_static)
            DisplayRegularField(START_VISIBLE);
        EditorGUILayout.Separator();
        DisplayRegularField(MATERIAL_STANDARD);
        DisplayRegularField(MATERIAL_STENCIL);


    }


    public void DisplayRegularField(Property property)
    {
        EditorGUILayout.PropertyField(_properties[property.name], new GUIContent(property.text));

    }




}