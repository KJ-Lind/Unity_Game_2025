using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{



    [SerializeField] private int enemyType_;
    GameObject bullPrefab_;
    public float x_pos;
    public float movSpd_ = 3f;
    public float scale_ = 1.5f;
    float timecounter = 0;
    Vector2 initpos;

    // Start is called before the first frame update
    void Start()
    {
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
        switch (enemyType_)
        {
            case 0:
                Type_1();
                break;

            case 1:
                Type_2();
                break;

            case 2:
                Type_3();
                break;

            case 3:
                Type_4();
                break;
        }

    }

    private void FixedUpdate()
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
        }

    }

    void Pattern_1()
    {

        Vector2 pos = transform.position;
        
        pos.x = x_pos;

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
        pos.x = x_pos + sin * 2.0f;
        pos.y = pos.y + movSpd_ * Time.deltaTime;

        transform.position = pos;
    }

    void Pattern_3()
    {

    }

    void Pattern_4()
    {
        timecounter += Time.deltaTime * movSpd_;
        float cos = Mathf.Cos(timecounter) * scale_;
        float sin = Mathf.Sin(timecounter) * scale_;

        transform.position = new Vector2(initpos.x + cos, initpos.y + (sin * 2f));
    }

    void Type_1()
    {

    }

    void Type_2()
    {

    }

    void Type_3()
    {

    }

    void Type_4()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
