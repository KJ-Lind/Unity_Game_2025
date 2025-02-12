using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public float trailDelay_;
    private float trailDelaySeconds_;
    public GameObject trail;
    public Vector3 offset = new Vector3(0.0f,1.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        trailDelaySeconds_ = trailDelay_;
    }

    // Update is called once per frame
    void Update()
    {
        if(trailDelaySeconds_ > 0)
        {
            trailDelaySeconds_ -= Time.deltaTime;
        }
        else
        {
            GameObject currTrail = Instantiate(trail, transform.position + offset, transform.rotation);
            trailDelaySeconds_ = trailDelay_;
            Destroy(currTrail, 0.55f);
        }
    }
}
