using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(-1, 0);
    public Vector2 velocity;
    public float bSpeed = 8f;
    public float life = 3f;
    public float bulletDmg_ = 5.0f;

    BossManager boss_manager_;

    private void Start()
    {
        Destroy(gameObject, life);
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

        if (collision.gameObject.tag == "Player")
        {
            DestroyBull();
            //Destroy(collision.gameObject);

        }
    }

    public void DestroyBull()
    {
        Destroy(gameObject);
    }
}
