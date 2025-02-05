using PlasticGui.Configuration.CloudEdition.Welcome;
using UnityEditor;
using UnityEngine;

public class Player_Tools : EditorWindow
{
    float playerSpeed;
    float max_playerSpeed;
    float min_playerSpeed;
    
    int playerLives;
    
    float playerRadius;

    float playerShotCD;
    float playerBulletSpeed;
    float playerMaxAtkSpd;
    float playerMinAtkSpd;

    [MenuItem("Tool/Player")]

    public static void ShowWindow()
    {
        GetWindow(typeof(Player_Tools));
    }


    private void OnGUI()
    {
        GUILayout.Label("Player Settings", EditorStyles.largeLabel);
        GUILayout.Label("Player Lives", EditorStyles.boldLabel);
        playerLives = EditorGUILayout.IntField("Player Lives", playerLives);
        GUILayout.Space(EditorGUIUtility.singleLineHeight);
        GUILayout.Label("Player Speed", EditorStyles.boldLabel);
        playerSpeed = EditorGUILayout.FloatField("Player Speed", playerSpeed);
        max_playerSpeed = EditorGUILayout.FloatField("Player Max Speed", max_playerSpeed);
        min_playerSpeed = EditorGUILayout.FloatField("Player Min Speed", min_playerSpeed);
        GUILayout.Space(EditorGUIUtility.singleLineHeight);
        GUILayout.Label("Player Rotation", EditorStyles.boldLabel);
        playerRadius = EditorGUILayout.FloatField("Player Rotation Radius", playerRadius);
        GUILayout.Space(EditorGUIUtility.singleLineHeight);
        GUILayout.Label("Player Shooting", EditorStyles.boldLabel);
        playerShotCD = EditorGUILayout.FloatField("Player Shot CoolDown", playerShotCD);
        playerBulletSpeed = EditorGUILayout.FloatField("Player Bullet Speed", playerBulletSpeed);
        playerMaxAtkSpd = EditorGUILayout.FloatField("Player Max Attack Speed", playerMaxAtkSpd);
        playerMinAtkSpd = EditorGUILayout.FloatField("Player Min Attack Speed", playerMinAtkSpd);
        if (GUILayout.Button("Apply"))
        {
            ApplySettings();
        }
    }

    private void GetData()
    {
        Player pl;
        Movement mov;
        SpawnBullet bull;

        pl = GameObject.FindWithTag("Player").GetComponent<Player>();
        mov = GameObject.FindWithTag("Player").GetComponent<Movement>();
        bull = GameObject.FindWithTag("Player").GetComponent<SpawnBullet>();

        // Player Data
        playerLives = pl.GetMaxLives();
        playerSpeed = pl.GetCurrSpeed();
        max_playerSpeed = pl.GetMaxSpeed();
        min_playerSpeed = pl.GetMinSpeed();

        // Movement Data
        playerRadius = mov.GetRadius();

        // Shooting data
        playerShotCD = bull.GetShootCD();
        playerBulletSpeed = bull.GetBulletSpeed();
        playerMaxAtkSpd = bull.GetMaxShootFrequency();
        playerMinAtkSpd = bull.GetMinShootFrequency();

    }
    private void ApplySettings()
    {
        Player pl;
        Movement mov;
        SpawnBullet bull;

        pl = GameObject.FindWithTag("Player").GetComponent<Player>();
        mov = GameObject.FindWithTag("Player").GetComponent<Movement>();
        bull = GameObject.FindWithTag("Player").GetComponent<SpawnBullet>();


        // Setting player data
        pl.SetMaxLives(playerLives);
        pl.SetCurrSpeed(playerSpeed);
        pl.SetMaxSpeed(max_playerSpeed);
        pl.SetMinSpeed(min_playerSpeed);

        // Setting movement data
        mov.SetRadius(playerRadius);

        // Setting players shooting data
        bull.SetShootCD(playerShotCD);
        bull.SetBulletSpeed(playerBulletSpeed);
        bull.SetMaxShootFrequency(playerMaxAtkSpd);
        bull.SetMinShootFrequency(playerMinAtkSpd);
    }
}
