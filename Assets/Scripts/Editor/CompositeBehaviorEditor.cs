using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeBehavior))]
[CanEditMultipleObjects]
public class CompositeBehaviorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //setup
        //dave try to fix
        CompositeBehavior cb = (CompositeBehavior)target;
        // dave add basic layout options
        GUILayoutOption[] guiOptions =
            new GUILayoutOption[]{
                GUILayout.ExpandWidth(true),
                GUILayout.MinHeight(EditorGUIUtility.singleLineHeight * 1.2f)
            };
        GUILayoutOption[] smallGuiOptions =
            new GUILayoutOption[]{
                GUILayout.MaxWidth(20),
                GUILayout.MinHeight(EditorGUIUtility.singleLineHeight * 1.2f)
            };
        EditorGUILayout.BeginHorizontal();

        //check for behaviors
        if (cb.behaviors == null || cb.behaviors.Length == 0)
        {
            EditorGUILayout.HelpBox("No behaviors in array.", MessageType.Warning);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
          
        }
        else
        {

            EditorGUILayout.LabelField("Behaviors", guiOptions);
            EditorGUILayout.LabelField("Weights", smallGuiOptions);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            for (int i = 0; i < cb.behaviors.Length; i++)
            {
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.LabelField(i.ToString(), smallGuiOptions);
                cb.behaviors[i] = (FlockBehavior)EditorGUILayout.ObjectField(cb.behaviors[i], typeof(FlockBehavior), false, guiOptions);
                cb.weights[i] = EditorGUILayout.Slider(cb.weights[i], 0f, 25f, guiOptions);
                // cb.weights[i] = EditorGUILayout.FloatField(cb.weights[i], guiOptions);
            }
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(cb);
            }
        }

        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add Behavior", guiOptions))
        {
            AddBehavior(cb);
            EditorUtility.SetDirty(cb);
        }

        if (cb.behaviors != null && cb.behaviors.Length > 0)
        {
            if (GUILayout.Button("Remove Behavior", guiOptions))
            {
                RemoveBehavior(cb);
                EditorUtility.SetDirty(cb);
            }
        }


    }

    void AddBehavior(CompositeBehavior cb)
    {
        int oldCount = (cb.behaviors != null) ? cb.behaviors.Length : 0;
        FlockBehavior[] newBehaviors = new FlockBehavior[oldCount + 1];

        float[] newWeights = new float[oldCount + 1];
        for (int i = 0; i < oldCount; i++)
        {
            newBehaviors[i] = cb.behaviors[i];
            newWeights[i] = cb.weights[i];
        }
        newWeights[oldCount] = 1f;
        cb.behaviors = newBehaviors;
        cb.weights = newWeights;
    }

    void RemoveBehavior(CompositeBehavior cb)
    {
        int oldCount = cb.behaviors.Length;
        if (oldCount == 1)
        {
            cb.behaviors = null;
            cb.weights = null;
            return;
        }
        FlockBehavior[] newBehaviors = new FlockBehavior[oldCount - 1];
        float[] newWeights = new float[oldCount - 1];
        for (int i = 0; i < oldCount - 1; i++)
        {
            newBehaviors[i] = cb.behaviors[i];
            newWeights[i] = cb.weights[i];
        }
        cb.behaviors = newBehaviors;
        cb.weights = newWeights;
    }
}
