using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    // General

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletPrefab;

    private float shootCooldown_ = 1.0f;
    private float shootResetCD_ = 1.0f;
    private float bSpeed = 8.0f;
    private float shootTimer_ = 0.0f;
    private float minShootFrequency_ = 0.1f;
    private float maxShootFrequency_ = 1.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (shootTimer_ <= Time.time)
        {
            Shoot();
            shootTimer_ = Mathf.Clamp(shootCooldown_, maxShootFrequency_, maxShootFrequency_) + Time.time;
            if(Mathf.Clamp(shootCooldown_, maxShootFrequency_, maxShootFrequency_) > maxShootFrequency_)
            {
                shootCooldown_ -= 0.1f;
            }
        }
    }
    private void Shoot()
    {
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

