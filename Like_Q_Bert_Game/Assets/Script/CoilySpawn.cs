using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilySpawn : MonoBehaviour
{
    public GameObject Enemy;
    private int count;
    void Update()
    {
        if(!GameLogic.isSnake && !GameLogic.isTimeStop)
        {
            count++;
        }
        
        if (!GameLogic.isSnake && !GameLogic.isTimeStop && count  > 1000)
        {

            SpawnEnemy();
            GameLogic.isSnake = true;
            count = 0;

        }
        

    }

    public void SpawnEnemy()
    {        
        Instantiate(Enemy, gameObject.transform);
    }

    

}
