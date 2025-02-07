using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public bool InBossStage;

    Movement pl_mov;

    private void Start()
    {
        pl_mov = GameObject.FindWithTag("Player").GetComponent<Movement>();

    }

    public void LevelChange()
    {
        
    }


}
