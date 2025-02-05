using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 0.2f;
    public float bulletDmg_ = 5.0f;

    BossManager boss_manager_;

    private void Start()
    {
        boss_manager_ = GameObject.FindGameObjectWithTag("BossSpawn").GetComponent<BossManager>();
    }

    private void Update()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Boss")
        {
            DestroyBull();
            boss_manager_.DamageBoss(bulletDmg_);

        }
    }

    public void DestroyBull()
    {
        Destroy(gameObject);
    }
}
