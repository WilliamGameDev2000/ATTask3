using UnityEngine;
using UnityEditor;

/// <summary>
/// Credit to Chilli :)
/// </summary>

public class ObjectSpawner : EditorWindow
{
    // Terrain Objects
    private static bool _spawner;
    private GameObject objectToSpawn;

    [MenuItem("Terrain/ObjectSpawner")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ObjectSpawner));
    }

    private void OnGUI()
    {
        objectToSpawn = EditorGUILayout.ObjectField("Object To Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawner: " + _spawner))
        {
            _spawner = !_spawner;
        }
    }

    private void OnEnable() => SceneView.duringSceneGui += OnSceneGUI;
    private void OnDisable() => SceneView.duringSceneGui -= OnSceneGUI;

    private void OnSceneGUI(SceneView view)
    {
        if (!_spawner)
        {
            return;
        }

        if (Event.current.type == EventType.MouseDown)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject spawnedObject = Instantiate(objectToSpawn, new Vector3(hit.point.x, hit.point.y + 4, hit.point.z), Quaternion.Euler(new Vector3(-90,0,0)));
            }
            Event.current.Use();
        }
    }
}