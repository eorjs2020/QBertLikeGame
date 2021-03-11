using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBallMoving : MonoBehaviour
{
    private int Rnum;
    public GameObject GBall;
    private Vector3 Target;
    private bool canJump = false;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("RandomNum",1,2);
        gameObject.tag = "Ignore";
        
    }

    // Update is called once per frame
    void Update()
    {        
        if(transform.position.y < -9)
        {
            if (GBall.name == "GreenBall(Clone)") 
                Destroy(GBall);
        }
        if (canJump && !GameLogic.isTimeStop)
        {
            count++;
        }
       
        if (canJump && count > 800 && !GameLogic.isTimeStop)
        {

            RandomNum();
            count = 0;
            canJump = false;
        }
    }
    
    private void RandomNum()
    {
        Rnum = Random.Range(1, 3);
        if(Rnum == 1)
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
        if (collision.gameObject.tag == "Ignore")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>()); ; ;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Qbert")
        {
            GameLogic.isTimeStop = true;
            GBall.SetActive(false);
            Destroy(GBall);
            Debug.Log("Collision");
        }
    }
   
}
