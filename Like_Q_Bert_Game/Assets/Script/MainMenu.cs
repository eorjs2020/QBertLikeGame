using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject selector1;
    public GameObject selector2;
    public GameObject selector3;
    int selection = 1;
    private void Awake()
    {
        selector1.SetActive(true);
        selector2.SetActive(false);
        selector3.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        switch(selection)
        {
            case 1:
                selector1.SetActive(true);
                selector2.SetActive(false);
                selector3.SetActive(false);
                break;
            case 2:
                selector1.SetActive(false);
                selector2.SetActive(true);
                selector3.SetActive(false);
                break;
            case 3:
                selector1.SetActive(false);
                selector2.SetActive(false);
                selector3.SetActive(true);
                break;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && selection < 3)
        {
            selection += 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && selection > 1)
        {
            selection -= 1;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (selection)
            {
                case 1:
                    SceneManager.LoadScene("Level1");
                    break;
                case 2:
                    SceneManager.LoadScene("Score");
                    break;
                case 3:
                    Application.Quit();
                    break;
            }
        }
    }
}
