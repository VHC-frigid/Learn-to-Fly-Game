using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // this is adding extra fuctions to deal with collections(like arrays or lists)
using TMPro;

public class HighScoreSystem : MonoBehaviour
{
    //Highest to lowest
    private List<string> names = new List<string>();
    private List<float> scores = new List<float>();

    public TMP_Text textBox;

    [SerializeField] private Transform playerObject;

    void Start()
    {
        //NewScore("test10", 10f);
        //NewScore("test4", 5f);
        //NewScore("test8", 11f);
        //NewScore("test3", 7f);
        //NewScore("test11", 2f);
        //NewScore("test2", 13f);
        //NewScore("test9", 5f);

        //foreach (var score in scores)
        //{
        //Debug.Log(score );
        //}

        //foreach (var name in names)
        //{
        //Debug.Log(name );
        //}
        //HighScoreData data = new HighScoreData(scores.ToArray(), names.ToArray(), playerObject.position);
        //JsonSaveLoad.Save(data);

        //Load game on game on start
        LoadScores();
    }

    //printed highscore to textbox (text mesh pro), don't forget to inculde using TMPro;
    public void RefreshScoreDisplay()
    {
        textBox.text = "";
        for (int index = 0; index < scores.Count; index++)
        {
            textBox.text += names[index] + ": " + scores[index] + "\n";
        }
    }

    // this runs when the game closes (unless it crashes) 
    private void OnApplicationQuit()// instead of ondestroy()
    {
        SaveScores();
    }

    public void LoadScores()
    {
        HighScoreData data = JsonSaveLoad.Load();
        if (data != null)
        {
            names = data.names.ToList();

            scores = data.scores.ToList();
        }
        else
        {
            names = new List<string>();
            scores = new List<float>();
        }

        RefreshScoreDisplay();
    }

    public void SaveScores()
    {
        HighScoreData data = new HighScoreData(scores.ToArray(), names.ToArray(), playerObject.position);
        JsonSaveLoad.Save(data);
    }

    //Every time the player has a new score(like when they die), run this to save the score to the highscore system it should order the scores correctly
    public void NewScore(string name, float score)
    {
        //highscores should be in order, from highest score on [0] and the lowest score at scores[count-1]
        for (int index = 0; index < scores.Count ; index ++)// loop through every score
        {
            float highScore = scores[index];// current highscore we are looking at
            if (score > highScore)// if the new score is higher that the current score
            {
                //if we have a higher score, save score at that position
                scores.Insert(index, score);
                names.Insert(index, name);
                //refresh textbox
                RefreshScoreDisplay();
                return;
            }
        }
        // if it's the lowest score, add it to the end
        scores.Add(score);
        names.Add(name);
        RefreshScoreDisplay();
    }

}
