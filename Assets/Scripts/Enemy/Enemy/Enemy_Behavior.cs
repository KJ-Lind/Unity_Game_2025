using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{

    [SerializeField] private int enemyType_;



    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
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

    }

    void Pattern_2()
    {

    }

    void Pattern_3()
    {

    }

    void Pattern_4()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
