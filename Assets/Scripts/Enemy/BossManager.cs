using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    public GameObject[] boss_;
    private Transform tr_;
    private bool isAlive_;
    [SerializeField] private int bossIndex_;
    public float bossHP_ = 100.0f;
    public float HPMult_ = 2.0f;
    [SerializeField] private float bossCurrHP_ = 0.0f;
    private Boss activeBoss_;

    // Start is called before the first frame update
    void Start()
    {
        tr_ = GetComponent<Transform>();
        isAlive_ = false;
        bossIndex_ = 0;
        bossCurrHP_ = bossHP_;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive_)
        {
            GameObject NewBoss = Instantiate(boss_[bossIndex_], tr_.position, tr_.rotation);
            NewBoss.name = "NewBoss";
            isAlive_ = true;
        }
        
        if(bossCurrHP_ <= 0.0f && bossIndex_ < boss_.Length - 1)
        {
            Debug.Log(boss_.Length);
            bossIndex_ += 1;
            NextBossHP();
            isAlive_ = false;
        }
    }

    public void DamageBoss(float dmg)
    {
        bossCurrHP_ -= dmg;
    }

    private void NextBossHP()
    {
        bossHP_ *= HPMult_;
        bossCurrHP_ += bossHP_;
        GameObject Aux = GameObject.Find("NewBoss");
        Destroy(Aux);
    }
}
