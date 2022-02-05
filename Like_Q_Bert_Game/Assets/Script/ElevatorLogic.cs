using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 target;
    public float speed = 3.0f;
    private bool elevatorMove = false;
    public Rigidbody qRigid;
        
    void Start()
    {
        
        target = new Vector3(0, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position == new Vector3(0, 2, 0))
        {
            
            Qmoving.rigid.isKinematic = false;
            GameLogic.ElevatorNum -= 1;
            GameLogic.isElevator = false;
            Qmoving.liftOn = false;
            Destroy(gameObject);
        }
        if(elevatorMove)
        {
            if (!Qmoving.liftOn)
                Qmoving.liftOn = true;
            ElevatorMoving();
        }
    }
    private void ElevatorMoving()
    {        
        float step = speed * Time.deltaTime;        
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            elevatorMove = true;            
        }
    }
}
