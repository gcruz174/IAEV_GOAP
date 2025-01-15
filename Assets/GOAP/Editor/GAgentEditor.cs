using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using GOAP;

[CustomEditor(typeof(GAgentVisual))]
[CanEditMultipleObjects]
public class GAgentVisualEditor : Editor
{


    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();
        GAgentVisual agent = (GAgentVisual)target;
        GUILayout.Label("Name: " + agent.name);
        GUILayout.Label("Current Action: " + agent.gameObject.GetComponent<GAgent>().CurrentAction);
        GUILayout.Label("Actions: ");
        foreach (GAction a in agent.gameObject.GetComponent<GAgent>().Actions)
        {
            string pre = "";
            string eff = "";

            foreach (KeyValuePair<string, int> p in a.preconditions)
                pre += p.Key + ", ";
            foreach (KeyValuePair<string, int> e in a.effects)
                eff += e.Key + ", ";

            GUILayout.Label("====  " + a.actionName + "(" + pre + ")(" + eff + ")");
        }
        GUILayout.Label("Goals: ");
        foreach (KeyValuePair<SubGoal, int> g in agent.gameObject.GetComponent<GAgent>().Goals)
        {
            GUILayout.Label("---: ");
            foreach (KeyValuePair<string, int> sg in g.Key.sgoals)
                GUILayout.Label("=====  " + sg.Key + " -> " + sg.Value);
        }
        
        GUILayout.Label("World Beliefs: ");
        foreach (KeyValuePair<string, int> sg in GWorld.GetWorld().GetStates())
        {
            GUILayout.Label("=====  " + sg.Key + " -> " + sg.Value);
        }
        
        GUILayout.Label("Beliefs: ");
        foreach (KeyValuePair<string, int> sg in agent.gameObject.GetComponent<GAgent>().Beliefs.GetStates())
        {
            GUILayout.Label("=====  " + sg.Key + " -> " + sg.Value);
        }

        GUILayout.Label("Inventory: ");
        foreach (GameObject g in agent.gameObject.GetComponent<GAgent>().Inventory.Items)
        {
            if (g == null) continue;
            GUILayout.Label("====  " + g.tag);
        }


        serializedObject.ApplyModifiedProperties();
    }
}