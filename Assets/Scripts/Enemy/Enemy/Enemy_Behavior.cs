using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

enum EnemyState
{
    kPositioning,
    kAttacking
};

public class Enemy_Behavior : MonoBehaviour
{
    [SerializeField] GameObject pl_;
    [SerializeField] private int enemyType_;
    GameObject bullPrefab_;
    public float x_pos;
    public float movSpd_ = 3f;
    public float scale_ = 1.5f;
    float timecounter = 0;
    Vector2 initpos;

    float waitTime = 2f;
    Vector2 velocity;
    float speed = 8f;

    EnemyState enemyState_;


    // Start is called before the first frame update
    void Start()
    {
        enemyState_ = EnemyState.kPositioning;
        pl_ = GameObject.FindWithTag("Player");
        x_pos = Random.Range(-1.0f, 10f);
        transform.position.Set(Random.Range(-4.5f, 4.5f), transform.position.x, transform.position.z);
        initpos = new Vector2(x_pos, transform.position.y);
    }
    public void SetType(int type)
    {
        enemyType_ = type;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(enemyState_ == EnemyState.kPositioning)
        {
            if(transform.position.x > x_pos)
            {
                Vector2 pos = transform.position;

                pos.x = pos.x - movSpd_ * Time.deltaTime;

                transform.position = pos;
            }
            else
            {
                enemyState_ = EnemyState.kAttacking;
            }
        }
        if(enemyState_ == EnemyState.kAttacking)
        {
            switch (enemyType_)
            {
                case 0:
                    Pattern_1();
                    break;

                case 1:
                    Pattern_2();
                    break;

                case 2:
                    Pattern_3();
                    break;

                case 3:
                    Pattern_4();
                    break;

                case 4:
                    Pattern_5();
                    break;
            }
        }
       
    }

    void Pattern_1()
    {

        Vector2 pos = transform.position;

        if(pos.y > 4.5f)
        {
            movSpd_ *= -1f;
        }else if(pos.y < -4.5f)
        {
            movSpd_ *= -1f;
        }
        pos.y = pos.y + movSpd_ * Time.deltaTime;

        transform.position = pos;

    }

    void Pattern_2()
    {
        Vector2 pos = transform.position;

        if (pos.y > 4.5f)
        {
            movSpd_ *= -1f;
        }
        else if (pos.y < -4.5f)
        {
            movSpd_ *= -1f;
        }
        float sin = Mathf.Sin(pos.y);
        pos.x = sin * 2.0f;
        pos.y = pos.y + movSpd_ * Time.deltaTime;

        transform.position = pos;
    }

    void Pattern_3()
    {
        timecounter += Time.deltaTime * movSpd_;
        float cos = Mathf.Cos(timecounter) * scale_;
        float sin = Mathf.Sin(timecounter) * scale_;

        transform.position = new Vector2(initpos.x, initpos.y + (sin * 1.5f));
    }

    void Pattern_4()
    {
        transform.Rotate(0.0f, 0.0f, 300.0f * Time.deltaTime);
    }
    void Pattern_5()
    {
        if(waitTime <= 0)
        {
            Vector2 pos = transform.position;

            pos += velocity * Time.deltaTime;

            transform.position = pos;
        }
        else
        {
            waitTime -= Time.deltaTime;
            Vector2 dir = pl_.transform.position - transform.position;
            Debug.Log("Player Pos:" + pl_.transform.position);
            dir.Normalize();
            velocity = dir * speed;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + 180f));
        }

        if(transform.position.x < -12.0f) 
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
