using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public static int remainingTiles;
    public static bool isSnake;
    public static bool isTimeStop;
    public static bool isQDead;
    public static int Qlife;
    public static int gameScore;
    public static int ElevatorNum;
    public static bool isElevator;
    public static bool onElevator;
    
    // Start is called before the first frame update
    void Start()
    {
        onElevator = false;
        isElevator = true;
        Qlife = 4;
        gameScore = 0;
        remainingTiles = 28;
        isSnake = false;
        isTimeStop = false;
        isQDead = true;
        ElevatorNum = 2;        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Qlife == 0)
        {           
            if (HightScroeTable.CheckIsHighScore(gameScore))
            {
                SceneManager.LoadScene("EndScene");
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        
        if (isTimeStop)
        {
            StartCoroutine(CoroutineTimer());
            
        }

        if (remainingTiles == 0)
        {
            gameScore += ElevatorNum * 100;
            gameScore += 1000;
            if (HightScroeTable.CheckIsHighScore(gameScore))
            {
                SceneManager.LoadScene("EndScene");
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

    }
    public IEnumerator CoroutineTimer()
    {   
        yield return new WaitForSeconds(5f);
        isTimeStop = false;
    }

 
}
