using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static int remainingTiles = 28;
    public static bool isSnake = false;
    public static bool isTimeStop = false;
    private int counterTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isTimeStop)
        {
            StartCoroutine(CoroutineTimer());
            
        }

        if (remainingTiles == 0)
        {
            Debug.Log("You Win!");
        }

    }
    public IEnumerator CoroutineTimer()
    {   
        yield return new WaitForSeconds(5f);
        isTimeStop = false;
    }
}
