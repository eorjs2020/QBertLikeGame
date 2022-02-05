using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallMoving : MonoBehaviour
{
    private int Rnum;
    public GameObject GBall;
    private Vector3 Target;
    private bool canJump = false;
    private float count = 0;
    void Start()
    {
        count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameLogic.isQDead || !GameLogic.isSnake)
        {
            count = 0;
            Destroy(GBall);
        }
        if (gameObject.transform.position.y < -9)
        {
            count = 0;
            Destroy(GBall);
        }
        if (canJump && !GameLogic.isTimeStop)
        {
            count += Time.deltaTime;
        }

        if (canJump && count > 1.5f && !GameLogic.isTimeStop)
        {

            RandomNum();
            count = 0;
            canJump = false;
        }
    }

    private void RandomNum()
    {
        Rnum = Random.Range(1, 3);
        if (Rnum == 1)
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
        else
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            canJump = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            GameLogic.isQDead = true;            
            GameLogic.Qlife -= 1;            
            Destroy(GBall);           
        }
    }

}

