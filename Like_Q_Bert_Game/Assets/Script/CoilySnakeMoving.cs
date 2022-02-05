using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilySnakeMoving : MonoBehaviour
{   
    private Transform player;
    public Animation jump;
    private bool canJump;
    private bool deadJump;
    private float count;
    public AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        jump["Armature|Action"].speed = 2.0f;
        player = Qmoving.qbertT;
        canJump = false;
        deadJump = true;
    }    

    // Update is called once per frame
    void Update()
    {
        
        if (GameLogic.isQDead)
        {
            GameLogic.isSnake = false;
            Destroy(gameObject);
        }

        player = Qmoving.qbertT;
        if (transform.position.y < -9)
        {
            GameLogic.gameScore += 500;
            GameLogic.isSnake = false;
            Destroy(gameObject);

        }
        if (GameLogic.onElevator && deadJump)
        {            
            if (player.position.z < 0)
                LeftUp();
            if (player.position.x > 0)
                RightUp();
            deadJump = false;
        }
        else if(!GameLogic.onElevator)
        {
            deadJump = true;
        }

        if (canJump)
        {
            count += Time.deltaTime;
        }
        if (canJump && count > 1.3f && !GameLogic.isTimeStop)
        {
            jump.Play();
            
            if (player.position.y > transform.position.y)
            {
                //Top Right
                if (player.position.z > transform.position.z && !((player.position.z - transform.position.z) < 0.1))
                {
                    RightUp();
                }
                //Top Left
                else if (player.position.x < transform.position.x && !((transform.position.x - player.position.x) < 0.1))
                {
                    LeftUp();
                }
            }
            else
            {

                //Down Right
                if (player.position.z < transform.position.z)
                {
                    LeftDown();
                }
                //Down Left
                else if (player.position.x > transform.position.x)
                {
                    RightDown();

                }
            }
            count = 0;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            float x = transform.position.x;
            float z = transform.position.z;

            x = Mathf.Round(x);
            z = Mathf.Round(z);
            jumpSound.Play();
            transform.position = new Vector3(x, transform.position.y, z);
            canJump = true;
        }

        if (collision.gameObject.tag == "Player")
        {

            Destroy(collision.gameObject);
            GameLogic.isQDead = true;
            GameLogic.isSnake = false;
            GameLogic.Qlife -= 1;
            Destroy(gameObject);
            
        }
       
    }

    void RightUp()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);
        canJump = false;
    }

    void RightDown()
    {
        transform.eulerAngles = new Vector3(0, 90, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
        canJump = false;
    }

    void LeftUp()
    {
        transform.eulerAngles = new Vector3(0, -90, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
        canJump = false;
    }

    void LeftDown()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
        canJump = false;
    }
}

