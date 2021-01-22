using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColor : MonoBehaviour
{
    public Material Green;
    //public Transform player;
    private int colornum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Qbert")
        {
           
            GetComponent<Renderer>().material = Green;
            
         
        }
    }
}
