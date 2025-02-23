using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct EnemyWave
{
    public int wave_;

}


public class Game_Manager : MonoBehaviour
{
    public bool InBossStage;

    [SerializeField] int enemyWave_;


    Movement pl_mov;

    private void Start()
    {
        pl_mov = GameObject.FindWithTag("Player").GetComponent<Movement>();

    }

    public void LevelChange()
    {
        
    }


}
