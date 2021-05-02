using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform container;
    private Transform template;
    private List<Transform> transformlist;
   private  List<HighScoreEntry> highScorelist;
    private void Awake() //Awake function is used for initialization, this is like the constructor
    {
        container = GameObject.Find("container").transform;
        template = GameObject.Find("template").transform;
        template.gameObject.SetActive(false);
        highScorelist = new List<HighScoreEntry>()
        {
  new HighScoreEntry
  {
      score = 10000, name="AAA",
     
  },
  new HighScoreEntry
  {
      score = 1000, name="BBB",

  },
  new HighScoreEntry
  {
      score = 100, name="CCC",

  },
   new HighScoreEntry
  {
      score = 50, name="DDD",

  },
    new HighScoreEntry
  {
      score = 40, name="EEE",

  },
        };
        transformlist = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScorelist)
        {
            CreateHighScoreEntryTable(highScoreEntry,container,transformlist);
        }



    }



    private void CreateHighScoreEntryTable(HighScoreEntry highScoreEntry, Transform container, List<Transform>transformList)
    {
        float templateHeight = 15f;
        int count = 0;
        Transform entryTransform = Instantiate(template, container);
        RectTransform rectTransform = entryTransform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        count++;
        //Debug.Log(transform.position);
        entryTransform.gameObject.SetActive(true);
        int rank = transformList.Count+1;
        string rankstring;
        switch (rank)
        {
            default:
                rankstring = rank + "th"; break;
            case 1: rankstring = "1st"; break;
            case 2: rankstring = "2nd"; break;
            case 3: rankstring = "3rd"; break;

        }
        entryTransform.Find("postext").transform.GetComponent<TMP_Text>().text = rankstring;

        int score = highScoreEntry.score;
        entryTransform.Find("scoretext").transform.GetComponent<TMP_Text>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("nametext").transform.GetComponent<TMP_Text>().text = name;
        transformList.Add(entryTransform);

    }
    private  class HighScoreEntry{
        public int score;
        public string name;
        }

    
}
