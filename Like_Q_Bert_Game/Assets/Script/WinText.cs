using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    Text state;
    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<Text>();
        state.text = ScoreLogic.winOrlose;
       
    }
    
}
