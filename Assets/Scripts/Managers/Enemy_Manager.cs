using System.Collections;
using UnityEngine;


[System.Serializable]
public class Wave
{
    public string waveName_;
    public int[] type_;
    public int enemyCount;
    public float spawnRate_;
}

public enum SpawnState
{
    kSpawning,
    kWaiting,
    kCounting
}

public class Enemy_Manager : MonoBehaviour
{
    int EnemySpawnIndex_ = 0;
    public Wave[] waves_;
    public Transform[] enemies_;

    public Transform[] spawnPoints;

    public int waveIndex_ = 0;
    public float timeBetweenWaves = 5f;
    private float waveCountdown_ = 0f;

    private float searchCountdown_ = 1f;

    public float atkRate = 1.0f;

    public SpawnState state_ = SpawnState.kCounting;

    private void Start()
    {
        if (spawnPoints.Length == 0)
        {
            //Debug.Log("ERROR no spawn point");
        }

        waveCountdown_ = timeBetweenWaves;
    }

    private void Update()
    {
        if(state_ == SpawnState.kWaiting)
        {
            if (!EnemyIsAlive())
            {
                
                WaveCompleted();
            }
            else
            {
                
                return;
            }
        }


        if(waveCountdown_ <= 0f)
        {
            if(state_ != SpawnState.kSpawning)
            {
                StartCoroutine(SpawnWave(waves_[waveIndex_]));
            }
        }
        else
        {
            waveCountdown_ -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive()
    {

        searchCountdown_ -= Time.deltaTime;
        if (searchCountdown_ <= 0f)
        {
            GameObject go = GameObject.FindWithTag("Enemy");
            searchCountdown_ = 1f;
            if (GameObject.FindWithTag("Enemy") == null)
            {
                Debug.Log("ENEMY DEAD");
                return false;
            }
        }
        Debug.Log("ENEMY ALIVE");
        return true;
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Complete");
        state_ = SpawnState.kCounting;
        waveCountdown_ = timeBetweenWaves;

        if(waveIndex_ + 1  > waves_.Length - 1)
        {
            waveIndex_ = 0;
            //Debug.Log("Waves Complete");
        }
        else
        {
            waveIndex_++;
        }
    }


    IEnumerator SpawnWave(Wave currWave_)
    {
        Debug.Log("Spawning Wave");
        state_ = SpawnState.kSpawning;

        for(int i = 0; i < currWave_.enemyCount; i++)
        {
            SpawningEnemy(currWave_.type_[i] - 1);
            yield return new WaitForSeconds(1f/currWave_.spawnRate_);
        }

        state_ = SpawnState.kWaiting;

        yield break;
    }

    void SpawningEnemy(int _enemy)
    {
        Debug.Log("Spawn Enemy:" + enemies_[_enemy].name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Transform enemy = Transform.Instantiate<Transform>(enemies_[_enemy], _sp.position, _sp.rotation);
        Enemy_Behavior mg_ = enemy.GetComponent<Enemy_Behavior>();
        mg_.SetType(_enemy);
    }

}
