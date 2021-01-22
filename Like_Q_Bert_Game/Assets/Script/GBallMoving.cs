using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBallMoving : MonoBehaviour
{
    private int Rnum;
    public GameObject GBall;
    private Vector3 Target;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomNum",1,2);
        gameObject.tag = "Ignore";
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -9)
        {
            Destroy(GBall);
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
        if(collision.gameObject.tag == "Ignore")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>()); ; ;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Qbert")
        {
            Destroy(GBall);
        }
    }
   
}
