using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Boss_Movement")]
    private float radius_;
    private float angle_ = 0.0f;


    [Header("Default_Movement")]
    private GameObject blackHole_1;
    private GameObject blackHole_2;


    private Player player_;
    private SpawnBullet bull_;
    public Transform enemyPos_;

    private bool dirChange_;
    // Start is called before the first frame update
    void Start()
    {
        bull_ = GetComponent<SpawnBullet>();
        player_ = GetComponent<Player>();

        if (Random.value % 2 == 0)
        {
            angle_ = 0.0f;
        }
        else if(Random.value % 2 != 0)
        {
            angle_ = 3.1415f;
        }

        dirChange_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 rotation;
        Vector3 look = transform.InverseTransformPoint(enemyPos_.transform.position);

        Mathf.Clamp(angle_, 0.0f, 6.28f);

        Color color_ = new Color(Random.value, Random.value, Random.value);

        rotation.x = enemyPos_.position.x + (Mathf.Cos(angle_) * radius_);
        rotation.y = enemyPos_.position.y + (Mathf.Sin(angle_) * radius_);
        rotation.z = 0.0f;

        float lookAngle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        transform.position = rotation;
        transform.Rotate(0, 0, lookAngle + -90);

        //if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.RightArrow)) && speed_ == -1) 
        //{
        //    speed_ *= -1;
        //    bull_.ResetTimerIncrement();
        //}
        //else if ((Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.LeftArrow)) && speed_ == 1)
        //{
        //    speed_ *= -1;
        //    bull_.ResetTimerIncrement();
        //}

        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            Touch input = Input.GetTouch(0);

            if (input.phase == TouchPhase.Began)
            {
                if (dirChange_ != false) dirChange_ = false;
                else if (dirChange_ != true) dirChange_ = true;
                ResetSpeed();
                player_.currSpeed_ *= -1;
                bull_.ResetTimerIncrement();
            }
        }
        //IncrementSpeed();
        angle_ += player_.currSpeed_ * Time.deltaTime;

    }

    private void IncrementSpeed()
    {
        if(dirChange_ == false) 
        {
            if (player_.currSpeed_ < player_.GetMaxSpeed())
            {
                player_.currSpeed_ += 0.1f;
            }
        }else if (dirChange_ == true)
        {
            if (player_.currSpeed_ > player_.GetMaxSpeed() * -1)
            {
                player_.currSpeed_ -= 0.1f;
            }
        }
        
        
    }

    private void ResetSpeed()
    {
        if(dirChange_ == false) 
        {
            player_.currSpeed_ = player_.GetMinSpeed();
        }
        else if (dirChange_ == true)
        {
            player_.currSpeed_ = player_.GetMinSpeed() * -1;
        }
    }

    public void SetRadius(float rad)
    {
        radius_ = rad;
    }

    public float GetRadius()
    {
        return radius_;
    }

}
