using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Starter))]
public class StarterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //DrawDefaultInspector();
        var starter = target as Starter;


        if (GUILayout.Button("Serialize"))
        {
            starter.SerializeLevel();
        }
        if (GUILayout.Button("Create Level"))
        {
            starter.CreateLevel();
        }
        if (GUILayout.Button("Clear Level"))
        {
            starter.ClearLevel();
        }
    }
}
