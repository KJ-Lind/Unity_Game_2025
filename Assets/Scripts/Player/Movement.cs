using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Boss_Movement")]
    [SerializeField] private float radius_ = 12.0f;
    private float angle_ = 0.0f;


    [Header("Default_Movement")]
    private GameObject blackHole_1;
    private GameObject blackHole_2;


    private Player player_;
    private SpawnBullet bull_;
    private Transform enemyPos_;
    private Game_Manager manager_;
    private Transform tr_;
    private Rigidbody2D rb_;

    private bool dirChange_;
    // Start is called before the first frame update
    void Start()
    {
        tr_ = gameObject.transform;
        rb_ = GetComponent<Rigidbody2D>();

        manager_ = GameObject.FindWithTag("GM").GetComponent<Game_Manager>();

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

        if (manager_.InBossStage)
        {
            PlayerBossMovement();
        }
        else if (!manager_.InBossStage)
        {
            PlayerDefaultMovement();
        }

    }

    private void PlayerDefaultMovement()
    {
        transform.position = transform.position + new Vector3(0.0f, player_.currSpeed_ * Time.deltaTime, 0.0f);
        //transform.position = new Vector3(pos.x, transform);

        if (Input.touchCount > 0)
        {
            Touch input = Input.GetTouch(0);

            if (input.phase == TouchPhase.Began)
            {
                player_.currSpeed_ *= -1;
                //bull_.ResetTimerIncrement();
            }
        }

    }

    private void PlayerBossMovement()
    {
        Transform enemyPos_ = GameObject.FindWithTag("BossSpawn").GetComponent<Transform>();

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
            Touch input = Input.GetTouch(0);

            if (input.phase == TouchPhase.Began)
            {
                player_.currSpeed_ *= -1;
                //bull_.ResetTimerIncrement();
            }
        }
        //IncrementSpeed();
        angle_ += player_.currSpeed_ * Time.deltaTime;
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
