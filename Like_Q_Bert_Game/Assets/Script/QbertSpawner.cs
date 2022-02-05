using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QbertSpawner : MonoBehaviour
{
    public GameObject player;
    private float spawnTime = 2f;
    private float curTime;
    private bool gameStart;
    public AudioSource dead;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameLogic.isQDead)
        {
            if (curTime == 0 && gameStart)
                dead.Play();
            curTime += Time.deltaTime;
        }
        if(curTime > spawnTime)
        {
            curTime = 0;
            gameStart = true;
            Instantiate(player, gameObject.transform);
            GameLogic.isQDead = false;
        }
    }
}
