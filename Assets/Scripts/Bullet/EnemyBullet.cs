using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] GameObject enemyBullPrefab_;

    public float bSpeed_ = 5.0f;

    //Pattern 1
    public int amount_ = 10;
    private float angle_ = Mathf.PI * 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pattern_1();
    }

    private void Pattern_1()
    {
        for (int i = 0; i < amount_; i++) 
        {
            Vector3 position = new Vector3(Mathf.Cos(angle_ * i),
                                           Mathf.Sin(angle_ * i));
            GameObject bullet = Instantiate(enemyBullPrefab_, position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = position * bSpeed_;
        }
    }
}
