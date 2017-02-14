using System.Diagnostics;
using UnityEngine;
using UnityEditor;

public class MenuEditor : ScriptableObject
{
    [MenuItem("Tools/打开Persister目录")]
    static void OpenPersister()
    {
        Process.Start(Application.persistentDataPath); 
    }

    [MenuItem("Tools/清除所有的PlayerPrefs")]
    static void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("Tools/清除所有的EditorPrefs")]
    static void ClearEditorPrefs()
    {
        EditorPrefs.DeleteAll();
    }
}