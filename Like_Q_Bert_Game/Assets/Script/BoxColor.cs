using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColor : MonoBehaviour
{
    public Material Green;
    //public Transform player;
    private int colornum;
    private int startTime;
    // Start is called before the first frame update
    void Start()
    {
        
        startTime = 0;
        colornum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime < 5)
        {
            startTime += 1;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && startTime > 4 && colornum == 1)
        {
            colornum -= 1;
            GetComponent<Renderer>().material = Green;
            GameLogic.remainingTiles -= 1;
            GameLogic.gameScore += 25;
         
        }
    }
}
