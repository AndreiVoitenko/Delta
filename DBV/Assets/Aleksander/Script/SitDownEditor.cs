#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;


[CustomEditor(typeof(SitDown))]
[CanEditMultipleObjects]
public class SitDownEditor : Editor
{
    SitDown sitDown;

    void OnEnable()
    {
        sitDown = (SitDown)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Change Position"))
        {
            sitDown.ChangeTables(sitDown.transform);
            
        }
    }
}
#endif