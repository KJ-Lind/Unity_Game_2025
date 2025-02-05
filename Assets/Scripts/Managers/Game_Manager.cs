using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public enum Levels
    {
        kDefaultLevel = 0,
        kBossLevel
    };
    
    public Levels currLevels_ = Levels.kBossLevel;

}
