using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilySpawn : MonoBehaviour
{
    public GameObject Enemy;
    private float count;
    private float spawnTime = 12f;
    public float startTime;
    private void Start()
    {
        spawnTime = startTime;
    }
    void Update()
    {
        if(GameLogic.isQDead)
        {
            count = 0;
        }   
        
        if (!GameLogic.isSnake && !GameLogic.isTimeStop && count > spawnTime)
        {

            SpawnEnemy();
            GameLogic.isSnake = true;
            count = 0;

        }
        if (!GameLogic.isTimeStop && !GameLogic.isSnake)
        {
            count += Time.deltaTime;
        }
    }

    public void SpawnEnemy()
    {
        spawnTime = 5f;
        Instantiate(Enemy, gameObject.transform);
    }

    

}
