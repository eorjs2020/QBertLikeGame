using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QLife : MonoBehaviour
{

    public GameObject qLife1;
    public GameObject qLife2;
    public GameObject qLife3;
    // Update is called once per frame
    void Update()
    {
        if(GameLogic.Qlife == 3)
        {
            qLife3.SetActive(false);
        }
        if (GameLogic.Qlife == 2)
        {
            qLife2.SetActive(false);
        }
        if (GameLogic.Qlife == 1)
        {
            qLife1.SetActive(false);
        }
    }
}
