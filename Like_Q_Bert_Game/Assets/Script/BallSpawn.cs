using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject Enemy;
    public int startTime;
    private float spawnTime = 10.0f;
    private float curTime;
    private string enemyName;
    
    private void Start()
    {
        spawnTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameLogic.isQDead || !GameLogic.isSnake)
        {
            curTime = 0;
        }
        if (curTime >= spawnTime && !GameLogic.isTimeStop)
        {
            SpawnEnemy();
        }
        if (!GameLogic.isTimeStop)
        {
            curTime += Time.deltaTime;
        }
    }

    public void SpawnEnemy()
    {
        spawnTime = 13.0f;
        curTime = 0;
        Instantiate(Enemy, gameObject.transform);
    }

    
}
