using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Bullet : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bSpeed = 8.0f;
    [SerializeField]private float shootTimer_ = 0.0f;
    [SerializeField] private float maxShootFrequency_ = 1.0f;
    // Update is called once per frame

    private void Start()
    {
        shootTimer_ = maxShootFrequency_;
    }

    void Update()
    {
        shootTimer_ -= Time.deltaTime;
        if(shootTimer_ < 0f)
        {
            shoot();
            shootTimer_ = maxShootFrequency_;
        }
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = spawnPoint.up * bSpeed;
    }
}
