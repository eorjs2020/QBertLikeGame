using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyBallLogic : MonoBehaviour
{
    public GameObject coilySnake;
    private int Rnum;
    private int changeToSnake = 0;
    private bool canJump;
    private int count;
    public AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("RandomNum", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && !GameLogic.isTimeStop)
        {
            count++;
        }
        
        if(changeToSnake == 6)
        {
            Vector3 coilyBall = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
            Instantiate(coilySnake, coilyBall, Quaternion.identity);
            Destroy(gameObject);
        }
        if (canJump && count > 800 && !GameLogic.isTimeStop)
        {

            RandomNum();
            count = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            jumpSound.Play();
            canJump = true;
        }
    }

    private void RandomNum()
    {
        Rnum = Random.Range(1, 3);
        if (Rnum == 1)
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
        else
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
        ++changeToSnake;
        canJump = false;
    }
}
