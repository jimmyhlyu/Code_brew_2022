using UnityEngine;
using UnityEditor;

// The window size increases as full as Unity.
// This only work when the editor window is inside Unity.

public class MaximizedExample : EditorWindow
{
    [MenuItem("Examples/Maximized")]
    public static void Init()
    {
        GetWindow<MaximizedExample>("Maximized");
    }

    void OnGUI()
    {
        maximized = GUILayout.Toggle(maximized, "Maximize window");
    }
}

