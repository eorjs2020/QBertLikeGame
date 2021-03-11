using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qmoving : MonoBehaviour
{
    private bool m_bJump;
    public int m_iJump;
    public static Transform qbertT;
    public bool qdead = false;
    public AudioSource jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        jump.Play();
        float x = transform.position.x;
        float z = transform.position.z;

        x = Mathf.Round(x);
        z = Mathf.Round(z);

        transform.position = new Vector3(x, transform.position.y, z);
        m_bJump = true;
    }
}
