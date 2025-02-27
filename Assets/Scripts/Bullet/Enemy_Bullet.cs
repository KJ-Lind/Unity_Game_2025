using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 velocity;
    public float bSpeed = 8f;
    public float bulletDmg_ = 5.0f;

    BossManager boss_manager_;

    private void Start()
    {

        Destroy(gameObject, 6.0f);

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;

        if(transform.position.x < -12.0f) 
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        velocity = direction * bSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
