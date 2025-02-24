using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Codice.Client.BaseCommands.Import.Commit;

public class Wave
{
    public string waveName_;
    public GameObject enemy_;
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
    public string waveName_;
    public GameObject enemy_;
    public int enemyCount;
    public float spawnRate_;

    Wave[] waves_;

    float timeBetweenWaves = 5f;
    Transform aux_;

    int tabs_ = 0;
    string[] tabOption = new string[] { "Wave 1" };

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
        GUILayout.Space(EditorGUIUtility.singleLineHeight);
        ShowOptions();
        if (GUILayout.Button("Add Wave"))
        {
            //ApplyData();
        }
    }
    //    tabs_ = GUILayout.Toolbar(tabs_, tabOption);
    //    if (waves_.Length > 0)
    //    {
    //        ShowTab(tabs_);
    //    }
    //}

    private void ShowOptions()
    {
        waveName_ = EditorGUILayout.TextField("Wave Name", waveName_);
        enemy_ = EditorGUILayout.ObjectField("Spawn Point", enemy_, typeof(GameObject), false) as GameObject;
        enemyCount = EditorGUILayout.IntField("Enemy Amount", enemyCount);
        spawnRate_ = EditorGUILayout.FloatField("Spawn Rate", spawnRate_);
    }

    //private void ShowTab(int selected) 
    //{

    //    waves_[selected].waveName_ = EditorGUILayout.TextField("Wave Name", waves_[selected].waveName_);
    //    waves_[selected].enemy_ = EditorGUILayout.ObjectField("Spawn Point", waves_[selected].enemy_, typeof(GameObject), false) as GameObject;
    //    waves_[selected].enemyCount = EditorGUILayout.IntField("Enemy Amount", waves_[selected].enemyCount);
    //    waves_[selected].spawnRate_ = EditorGUILayout.FloatField("Spawn Rate", waves_[selected].spawnRate_);

    //}

    //private void ApplyData()
    //{
    //    tabs_++;
    //    Wave aux = null;
    //    aux.waveName_ = waveName_;
    //    aux.enemy_ = enemy_;
    //    aux.enemyCount = enemyCount;
    //    aux.spawnRate_ = spawnRate_;

    //    waves_[0] = aux;
    //}
}
