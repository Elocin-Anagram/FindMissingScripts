using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class FindMissingScripts : EditorWindow 
{
    // Added " _F12" at the end to assign the hotkey
    [MenuItem("Tools/Select Objects with Missing Scripts _F12")]
    static void SelectObjects()
    {
        // Find all objects in the scene, including inactive ones
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>(true);
        List<GameObject> foundObjects = new List<GameObject>();

        int count = 0;
        foreach (GameObject go in allObjects)
        {
            Component[] components = go.GetComponents<Component>();
            foreach (Component c in components)
            {
                if (c == null)
                {
                    foundObjects.Add(go);
                    count++;
                    break; 
                }
            }
        }

        if (foundObjects.Count > 0)
        {
            Selection.objects = foundObjects.ToArray();
            Debug.Log($"<color=red>Found {foundObjects.Count} objects with missing scripts.</color>");
        }
        else
        {
            Debug.Log("<color=green>No missing scripts found!</color>");
        }
    }
}
