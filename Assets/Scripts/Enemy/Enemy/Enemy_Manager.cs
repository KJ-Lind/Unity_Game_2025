using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints_;
    [SerializeField] private GameObject[] enemyTypes_;

    int enemyAmount_ = 1;
    int enemyType_ = 0;

    private void Update()
    {
        WaveController(enemyAmount_, enemyType_);
    }

    void WaveController(int amount, int type)
    {
        GameObject Enemy = GameObject.Instantiate(enemyTypes_[type], spawnPoints_[0].transform.position, spawnPoints_[0].transform.rotation);
    }

}
