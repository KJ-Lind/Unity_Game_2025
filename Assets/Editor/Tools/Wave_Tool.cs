using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Codice.Client.BaseCommands.Import.Commit;

public enum SpawnState
{
    kSpawning,
    kWaiting,
    kCounting
}

public class Wave_Tool : EditorWindow
{

    float timeBetweenWaves = 5f;
    float movSpdIncr_ = 1.0f;
    float atkSpdIncr_ = 1.0f;
    float spwRateIncr_ = 1.0f;

    private SpawnState spawnState  = SpawnState.kCounting;

    private int selState = 0;
    private String[] stateName = { "Spawning", "Waiting", "Countoing" };

    [MenuItem("Tools/Mangers/Waves")]

    public static void ShowWindow()
    {
        GetWindow(typeof(Wave_Tool));
    }


    private void OnGUI()
    {
        GUILayout.Label("Wave Manager", EditorStyles.largeLabel);
        timeBetweenWaves = EditorGUILayout.FloatField("Time Between Waves", timeBetweenWaves);
        
        GUILayout.Space(20f);
        
        GUILayout.Label("Wave Values", EditorStyles.largeLabel);
        movSpdIncr_ = EditorGUILayout.FloatField("Move Speed Increment", movSpdIncr_);
        atkSpdIncr_ = EditorGUILayout.FloatField("Attack Speed Increment", atkSpdIncr_);
        spwRateIncr_ = EditorGUILayout.FloatField("Spawn Rate Increment", spwRateIncr_);

        GUILayout.Space(20f);

        GUILayout.Label("Wave State", EditorStyles.largeLabel);

        selState = GUILayout.SelectionGrid(selState, stateName, 3);

        if (GUILayout.Button("Apply"))
        {
            //ApplyChanges();
        }
    }

    //private void ApplyChanges()
    //{
    //    Enemy_Manager mg_;

    //    mg_ = GameObject.FindWithTag("GM").GetComponent<Enemy_Manager>();

    //    switch (state)
    //    {
    //        case 0:
    //            mg_.state_ = SpawnState.kSpawning;
    //        break;

    //        case 1:
    //            mg_.state_ = SpawnState.kWaiting;
    //        break;

    //        case 2:
    //            mg_.state_ = SpawnState.kCounting;
    //        break;
    //    }

    //}

}
