using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    // General

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform pl_;

    private float shootCooldown_ = 1.0f;
    private float shootResetCD_ = 1.0f;
    private float bSpeed = 8.0f;
    private float shootTimer_ = 0.0f;
    private float minShootFrequency_ = 0.2f;
    private float maxShootFrequency_ = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        pl_ = GetComponentInParent<Transform>();
        shootCooldown_ = maxShootFrequency_;
        shootTimer_ = maxShootFrequency_;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shootTimer_ <= Time.time)
        {
            Shoot();
            shootTimer_ = shootCooldown_ + Time.time;
            if(shootCooldown_ > minShootFrequency_)
            {
                shootCooldown_ -= 0.1f;
            }
        }
    }
    private void Shoot()
    {
        Debug.Log(pl_.rotation);
       
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = spawnPoint.up * bSpeed;
    }

    // Setters

    public void ResetTimerIncrement()
    {
        shootCooldown_ = shootResetCD_;
    }

    public void SetShootCD(float CD)
    {
        shootResetCD_ = CD;
    }
    public void SetBulletSpeed(float spd)
    {
        bSpeed = spd;
    }
    public void SetMinShootFrequency(float min)
    {
        minShootFrequency_= min;
    }
    public void SetMaxShootFrequency(float max)
    {
        maxShootFrequency_ = max;
    }

    // Getters

    public float GetShootCD()
    {
        return shootResetCD_;
    }
    public float GetBulletSpeed()
    {
        return bSpeed;
    }
    public float GetMinShootFrequency()
    {
        return minShootFrequency_;
    }
    public float GetMaxShootFrequency()
    {
        return maxShootFrequency_;
    }

}

