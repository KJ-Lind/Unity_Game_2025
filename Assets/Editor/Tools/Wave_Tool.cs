using UnityEditor;
using UnityEngine;

public class Wave
{
    public string waveName_;
    public Transform enemy_;
    public int enemyCount;
    public float spawnRate_;
}

public enum SpawnState
{
    kSpawning,
    kWaiting,
    kCounting
}

public class Wave_Tool : EditorWindow
{

    Wave[] waves_;

    GUIContent[] 

    private int selected_ = 0;

    private float timeBetweenWaves = 5f;

    [MenuItem("Tools/Mangers/Waves")]

    public static void ShowWindow()
    {
        GetWindow(typeof(Wave_Tool));
    }

    private void OnGUI()
    {
        GUILayout.Label("Wave Manager", EditorStyles.largeLabel);
        timeBetweenWaves = EditorGUILayout.FloatField("Time Between Waves", timeBetweenWaves);
        GUILayout.Space(EditorGUIUtility.singleLineHeight);
    }

    private void ApplyData()
    {

    }
}
