using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(1,0);
    public Vector2 velocity;
    public float bSpeed = 2f;
    public float life = 1f;
    public float bulletDmg_ = 5.0f;

    BossManager boss_manager_;

    private void Start()
    {
        Destroy(gameObject, life);
        if (GameObject.FindGameObjectWithTag("BossSpawn") != null)
        {
            boss_manager_ = GameObject.FindGameObjectWithTag("BossSpawn").GetComponent<BossManager>();
                
            gameObject.transform.Rotate(boss_manager_.transform.position);
        
        }


    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }

    private void Update()
    {
        velocity = direction * bSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boss")
        {
            DestroyBull();
            boss_manager_.DamageBoss(bulletDmg_);

        }

        if (collision.gameObject.tag == "Enemy")
        {
            DestroyBull();
            Destroy(collision.gameObject);

        }
    }

    public void DestroyBull()
    {
        Destroy(gameObject);
    }
}
