using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qmoving : MonoBehaviour
{
    private bool m_bJump;
    private bool musicOn;
    private bool moveToTarget;
    public static bool liftOn;
    public int m_iJump;
    public static Transform qbertT;
    public static Rigidbody rigid;
    public AudioSource jump;
    public AudioSource timeStop;
    public AudioSource lift;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        moveToTarget = false;
        liftOn = false;
        target = new Vector3(0, 1f, 0);
        musicOn = false;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveToTarget)
        {
            MovetoTarget();
        }
        if (transform.position.y < -9)
        {
            GameLogic.isQDead = true;
            GameLogic.Qlife -= 1;
            Destroy(gameObject);
        }

        if (!GameLogic.isElevator)
        {
            moveToTarget = false;
            liftOn = false;
            rigid.isKinematic = true;            
            float step = 1 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        if (gameObject.transform.position == target)
        {
            rigid.isKinematic = false;            
            GameLogic.isElevator = true;
            GameLogic.onElevator = false;
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            GameLogic.Qlife = 0;         
        }*/
        if(GameLogic.isTimeStop && !musicOn)
        {           
            timeStop.Play();
            musicOn = true;
        }
        else if(!(GameLogic.isTimeStop) && musicOn)
        {
            timeStop.Stop();
            musicOn = false;
        }

        qbertT = gameObject.transform;
        if (m_iJump > 1)
        {
            // Down Left
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
                m_bJump = false;
                m_iJump = 0;
            }
            // Top right
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);
                m_bJump = false;
                m_iJump = 0;
            }
            // Top left
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
                GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
                m_bJump = false;
                m_iJump = 0;
            }
            // Down right
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
                GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
                m_bJump = false;
                m_iJump = 0;
            }
           
            
        }
    }
    private void FixedUpdate()
    {
        if (m_bJump && m_iJump < 6)
        {
            ++m_iJump;           
        }
        
    }
    private void MovetoTarget()
    {
        float step = 4 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,2,0), step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Elevator")
        {
            if (!liftOn)
            {
                GameLogic.onElevator = true;
                lift.Play();
            }
            moveToTarget = true;
            //transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 0.15f, collision.transform.position.z);
        }        
        else
        {
            //rigid.isKinematic = false;
            jump.Play();
            float x = transform.position.x;
            float z = transform.position.z;

            x = Mathf.Round(x);
            z = Mathf.Round(z);

            transform.position = new Vector3(x, transform.position.y, z);
            m_bJump = true;
        }
    }
}
