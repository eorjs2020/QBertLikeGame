using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour
{
    Image img;
    public float BlinkFadeInTime = 0.5f;
    public float BlinkStayTime = 0.8f;
    public float BlinkFadeOutTime = 0.7f;
    private float time = 0f;
    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        color = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.active == true)
        {
            time += Time.deltaTime;
            if (time < BlinkFadeInTime)
            {
                img.color = new Color(color.r, color.g, color.b, color.a);
            }
            else if (time < BlinkFadeInTime + BlinkStayTime)
            {
                img.color = new Color(color.r, color.g, color.b, 0);
            }
            else
            {
                time = 0f;
            }
        }
        else 
        {
            time = 0f;
        }
    }
}
