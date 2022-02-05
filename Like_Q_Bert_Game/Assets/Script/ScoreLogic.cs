using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreLogic : MonoBehaviour
{
    public static string winOrlose;
    float currTime;
    int selector = 1;
    int nameNum = 1;
    char name1;
    char name2;
    char name3;
    int scoreSave;
    string nameSave;
    public Text selectNamedone;
    public Text name;
    public Text score;
    public List<GameObject> listImg;
    // Start is called before the first frame update
    void Start()
    {
        scoreSave = GameLogic.gameScore;

        for (int i = 0; i < listImg.Count; ++i)
        {
            listImg[i].SetActive(false);
        }
        score.text = scoreSave.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(nameNum == 4)
        {
            selectNamedone.text = "PRESS ENTER ONE MORE";
        }
        currTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selector > 10)
                selector -= 10;
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(!(selector > 16 && selector <21) && !(selector > 20  && selector <27))
            {
                selector += 10;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if((selector < 11 && selector > 1 ) || (selector < 21 && selector > 11) || (selector < 27 && selector > 21))
            {
                --selector;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if((selector < 10 && selector > 0) || (selector < 20 && selector > 10) || (selector < 26 && selector > 20))
            {
                ++selector;
               
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) && nameNum < 5)
        {
            switch(nameNum)
            {
                case 1:
                    name1 = getChar();
                    break;
                case 2:
                    name2 = getChar();
                    break;
                case 3:
                    name3 = getChar();
                    break;
                case 4:
                    HightScroeTable.AddHighscoreEntry(scoreSave, nameSave);
                    SceneManager.LoadScene("Score");
                    break;
            }
            ++nameNum;
        }
        setActiveImage();
        nameSave = name1.ToString() + name2.ToString() + name3.ToString();        
        name.text = nameSave;
    }
    private void setActiveImage()
    {
        switch (selector)
        {
            case 1:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 2:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 3:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 4:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 5:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 6:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 7:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 8:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 9:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 10:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 11:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 12:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 13:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 14:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 15:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 16:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 17:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 18:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 19:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 20:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 21:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 22:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 23:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 24:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 25:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
            case 26:
                for (int i = 0; i < listImg.Count; ++i)
                {
                    listImg[i].SetActive(false);
                }
                listImg[selector - 1].SetActive(true);
                break;
        }
    }
    private char getChar()
    {
        switch (selector)
        {
            default:
                return 'A';
            case 1:
                return 'A';                
            case 2:
                return 'B';
            case 3:
                return 'C';
            case 4:
                return 'D';
            case 5:
                return 'E';
            case 6:
                return 'F';
            case 7:
                return 'G';
            case 8:
                return 'H';
            case 9:
                return 'I';
            case 10:
                return 'J';
            case 11:
                return 'K';
            case 12:
                return 'L';
            case 13:
                return 'M';
            case 14:
                return 'N';
            case 15:
                return 'O';
            case 16:
                return 'P';
            case 17:
                return 'Q';
            case 18:
                return 'R';
            case 19:
                return 'S';
            case 20:
                return 'T';
            case 21:
                return 'U';
            case 22:
                return 'V';
            case 23:
                return 'W';
            case 24:
                return 'X';
            case 25:
                return 'Y';
            case 26:
                return 'Z';
        }
    }
   

}




