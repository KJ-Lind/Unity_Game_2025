using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pl_Movement : MonoBehaviour
{
    Vector2 m_Movement;
    public float m_MovementSpeed;
    private Rigidbody2D rb_;
    void Start()
    {
        m_Movement = new Vector2(0.0f,1.0f);
        rb_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch input = Input.GetTouch(0);

            if(input.phase == TouchPhase.Began)
            {
                m_Movement.y *= -1.0f;
            }

        }
    }

    private void FixedUpdate()
    {
        rb_.MovePosition(rb_.position + m_Movement * m_MovementSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BL_Hole")
        {
            m_Movement.y *= -1.0f;
        }
    }
}
