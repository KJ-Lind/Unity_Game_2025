using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject bullSpawn_;
    [Header("Lives")]
    [SerializeField] int maxLives_;
    [SerializeField] int currLives_;

    [Header("Movement")]
    public float currSpeed_;
    [SerializeField] private float maxSpeed_;
    [SerializeField] private float minSpeed_;


    // Start is called before the first frame update
    void Start()
    {
        bullSpawn_ = GetComponent<GameObject>();
        currLives_ = maxLives_;
        currSpeed_ = minSpeed_;
    }

    public void SetMaxLives(int Lives)
    {
        maxLives_ = Lives;
    }

    public void SetCurrSpeed(float spd)
    {
        currSpeed_ = spd;
    }

    public void SetMaxSpeed(float spd)
    {
        maxSpeed_ = spd;
    }

    public void SetMinSpeed(float spd)
    {
        minSpeed_ = spd;
    }

    public int GetMaxLives()
    {
        return maxLives_;
    }

    public float GetCurrSpeed()
    {
        return currSpeed_;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed_;
    }

    public float GetMinSpeed()
    {
        return minSpeed_;
    }

}
