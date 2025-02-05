using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private LineRenderer circle_;
    private float radius_;
    public int points_;
    private Movement pl_;
    private Transform Center_;
    private Game_Manager manager_;

    private Transform Hole_1, Hole_2;

    bool IsDrawen = false;

    // Start is called before the first frame update
    void Start()
    {
        circle_ = GetComponent<LineRenderer>();
        pl_ = GameObject.FindWithTag("Player").GetComponent<Movement>();
        radius_ = pl_.GetRadius();
        manager_ = GameObject.FindWithTag("GM").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (manager_.currLevels_)
        {
            case Game_Manager.Levels.kDefaultLevel:

                if (!IsDrawen)
                {
                    Hole_1 = GameObject.Find("Black_Hole_1").GetComponent<Transform>();
                    Hole_2 = GameObject.Find("Black_Hole_2").GetComponent<Transform>();
                    DrawLine();
                    IsDrawen = true;
                }

                break;

            case Game_Manager.Levels.kBossLevel:

                if (!IsDrawen)
                {
                    Center_ = GameObject.FindWithTag("BossSpawn").GetComponent<Transform>();
                    DrawCircle(points_, radius_);
                    IsDrawen = true;
                }

                break;
        }
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

    void DrawLine()
    {
        circle_.positionCount = 2;

        Vector3 points = new Vector3(Hole_1.position.x, Hole_1.position.y, 0.0f);

        circle_.SetPosition(0, points);

        points = new Vector3(Hole_2.position.x, Hole_2.position.y, 0.0f);

        circle_.SetPosition(1, points);

    }
}
