using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    [SerializeField] float direction_;
    [SerializeField] Transform Other_hole;
    [SerializeField] Transform Player_;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION!!!!");

        if(collision.gameObject.tag == "Player" && direction_ < 0)
        {
            Player_.position = new Vector3(Other_hole.position.y + 3, 0.0f,0.0f);
        }

        if(collision.gameObject.tag == "Player" && direction_ > 0)
        {
            Player_.position = new Vector3(Other_hole.position.y - 3, 0.0f, 0.0f);
        }
    }
}
