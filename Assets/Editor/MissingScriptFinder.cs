using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MissingScriptFinderExtended : EditorWindow
{
    [MenuItem("Tools/Find Missing Scripts in Project + Scene")]
    public static void FindAllMissingScripts()
    {
        int missingInScene = FindMissingInScene();
        int missingInAssets = FindMissingInAssets();

        Debug.Log($"✅ Done. Missing scripts - Scene: {missingInScene}, Project Assets: {missingInAssets}");
    }

    private static int FindMissingInScene()
    {
        int missingCount = 0;
        GameObject[] gos = GameObject.FindObjectsOfType<GameObject>(true); // include inactive
        foreach (GameObject g in gos)
        {
            Component[] components = g.GetComponents<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.LogWarning($"[Scene] Missing script on: {GetGameObjectPath(g)}", g);
                    missingCount++;
                }
            }
        }
        return missingCount;
    }

    private static int FindMissingInAssets()
    {
        int missingCount = 0;
        string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab");

        foreach (string guid in prefabGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

            if (prefab == null) continue;

            Component[] components = prefab.GetComponentsInChildren<Component>(true);
            foreach (Component c in components)
            {
                if (c == null)
                {
                    Debug.LogWarning($"[Asset] Missing script in prefab: {path}", prefab);
                    missingCount++;
                    break;
                }
            }
        }
        return missingCount;
    }

    private static string GetGameObjectPath(GameObject obj)
    {
        string path = obj.name;
        Transform current = obj.transform;
        while (current.parent != null)
        {
            current = current.parent;
            path = current.name + "/" + path;
        }
        return path;
    }
}
