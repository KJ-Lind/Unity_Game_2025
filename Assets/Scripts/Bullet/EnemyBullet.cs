using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    Vector2 direcction;

    [SerializeField] private float shootTimer_ = 0.0f;
    [SerializeField] private float maxShootFrequency_ = 1.0f;
    // Update is called once per frame

    private void Start()
    {
        Enemy_Manager ene_mg = GameObject.FindWithTag("GM").GetComponent<Enemy_Manager>();
        shootTimer_ = ene_mg.atkRate;
    }

    void Update()
    {
        direcction = (transform.rotation * Vector2.left).normalized;
        shootTimer_ -= Time.deltaTime;
        if (shootTimer_ < 0f)
        {
            shoot();
            shootTimer_ = maxShootFrequency_;
        }
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Enemy_Bullet go = bullet.GetComponent<Enemy_Bullet>();
        go.direction = direcction;
    }

}
