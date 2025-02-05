using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public LineRenderer circle_;
    public float radius_;
    public int points_;
    public Transform Center_;
    // Start is called before the first frame update
    void Start()
    {
        DrawCircle(points_, radius_);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawCircle(int points, float radius)
    {
        circle_.positionCount = points;

        for(int currPoint = 0; currPoint < points; currPoint++)
        {
            float circunference = (float)currPoint / points;

            float currRad = circunference * 2 * Mathf.PI;

            float x = Mathf.Cos(currRad) * radius + Center_.position.x;
            float y = Mathf.Sin(currRad) * radius + Center_.position.y;

            Vector3 currPos = new Vector3(x, y, 0);

            circle_.SetPosition(currPoint, currPos);
        }
    }
}
