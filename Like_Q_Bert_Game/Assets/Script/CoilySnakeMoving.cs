using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilySnakeMoving : MonoBehaviour
{   
    public Transform player;
    public Animation jump;
    private bool canJump;
    private int count;
    public AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        jump["Armature|Action"].speed = 2.0f;
        player = Qmoving.qbertT;
        canJump = false;        
    }

    // Update is called once per frame
    void Update()
    {
        
        player = Qmoving.qbertT;
        if (transform.position.y < -9)
        {
            GameLogic.isSnake = false;
            //Destroy(gameObject);
        }
        if (canJump)
        {
            ++count;
        }

        if (canJump && count > 700 && !GameLogic.isTimeStop)
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
                else if(player.position.x < transform.position.x && !((transform.position.x - player.position.x) < 0.1))
                {
                    LeftUp();
                }
            }
            else
            {
                
                //Down Right
                if (player.position.z < transform.position.z )
                {
                    LeftDown();
                }
                //Down Left
                else if(player.position.x > transform.position.x )
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

