using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HightScroeTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreTransformList;
    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if (PlayerPrefs.HasKey("highscoreTable"))
        {
            for (int i = 0; i < highscores.highscoreEntryList.Count; ++i)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; ++j)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                        HighscoreEntry temp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = temp;
                    }
                }
            }

            highscoreTransformList = new List<Transform>();
            foreach (HighscoreEntry highscoreEnty in highscores.highscoreEntryList)
            {
                CreateHighscoreEntryTransform(highscoreEnty, entryContainer, highscoreTransformList);
            }
        }

        //Debug.Log(highscores.highscoreEntryList.Count);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscore, Transform container, List<Transform> transformList)
    {
        float templateHight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        int score = highscore.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
        string name = highscore.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;
        transformList.Add(entryTransform);
    }
    public static bool CheckIsHighScore(int score)
    {
        if (PlayerPrefs.HasKey("highscoreTable"))
        {
            string jsonString = PlayerPrefs.GetString("highscoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
            if(highscores.highscoreEntryList[highscores.highscoreEntryList.Count - 1].score < score)
            {
                return true;
            }
            else if(highscores.highscoreEntryList.Count < 10)
            {
                return true;
            }
            else
                return false;
        }
        else
        {
            return true;
        }        
    }

    public static void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        if (PlayerPrefs.HasKey("highscoreTable"))
        {
            string jsonString = PlayerPrefs.GetString("highscoreTable");
            
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            if (highscores.highscoreEntryList.Count > 9)
            {
                if (highscoreEntry.score > highscores.highscoreEntryList[9].score)
                    highscores.highscoreEntryList[highscores.highscoreEntryList.Count - 1] = highscoreEntry;
            }
            else
            {
                highscores.highscoreEntryList.Add(highscoreEntry);
            }
            for (int i = 0; i < highscores.highscoreEntryList.Count; ++i)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; ++j)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                        HighscoreEntry temp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = temp;
                    }
                }
            }

            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }
        else
        {
            List<HighscoreEntry> tempEntry = new List<HighscoreEntry>()
            {
                new HighscoreEntry {score = highscoreEntry.score, name = highscoreEntry.name}
            };
            Highscores temp = new Highscores() { highscoreEntryList = tempEntry };            
            string json = JsonUtility.ToJson(temp);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }
        
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
