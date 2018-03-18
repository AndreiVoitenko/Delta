#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;


[CustomEditor(typeof(Actor))]
[CanEditMultipleObjects]
public class ActorEditor : Editor
{
    Actor actor;

    void OnEnable()
    {
        actor = (Actor)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Reset Destination"))
        {
            NavMeshAgent agent = actor.GetComponent<NavMeshAgent>();
            agent.SetDestination(actor.destination.transform.position);
            
        }
    }
}
#endif