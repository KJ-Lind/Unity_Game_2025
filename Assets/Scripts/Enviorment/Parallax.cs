using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mat_;
    float distance_;

    [Range(0f,0.5f)]
    public float speed_ = 0.2f;

    void Start()
    {
        mat_ = GetComponent<Renderer>().material;
    }

    void Update()
    {
        distance_ += Time.deltaTime * speed_;
        mat_.SetTextureOffset("_MainTex", Vector2.right * distance_);
    }
}
