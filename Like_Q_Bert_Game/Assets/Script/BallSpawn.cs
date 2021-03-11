using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject Enemy;
    private float spawnTime = 10.0f;
    public float curTime;
    private string enemyName;
    
    private void Start()
    {
        curTime = 0;
        enemyName = Enemy.name;
        switch (enemyName)
        {
            case "GreenBall":
                curTime += 7;
                break;

            case "RedBall":
                curTime += 5;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime >= spawnTime && !GameLogic.isTimeStop)
        {
            SpawnEnemy();
        }
        curTime += Time.deltaTime;

    }

    public void SpawnEnemy()
    {
        curTime = 0;
        Instantiate(Enemy, gameObject.transform);
    }

    
}
