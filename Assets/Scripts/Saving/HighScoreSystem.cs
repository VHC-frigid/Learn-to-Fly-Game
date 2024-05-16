using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreSystem : MonoBehaviour
{
    //Highest to lowest
    private List<string> names = new List<string>();
    private List<float> scores = new List<float>();

    void Start()
    {
        NewScore("test10", 10f);
        NewScore("test4", 5f);
        NewScore("test8", 11f);
        NewScore("test3", 7f);
        NewScore("test11", 2f);
        NewScore("test2", 13f);
        NewScore("test9", 5f);

        foreach (var score in scores)
        {
            Debug.Log(score );
        }

        foreach (var name in names)
        {
            Debug.Log(name );
        }
        HighScoreData data = new HighScoreData(scores.ToArray(), names.ToArray());
        JsonSaveLoad.Save(data);
    }

    public void NewScore(string name, float score)
    {
        for (int index = 0; index < scores.Count ; index ++)
        {
            float highScore = scores[index];
            if (score > highScore)
            {
                scores.Insert(index, score);
                names.Insert(index, name);
                return;
            }
        }
        scores.Add(score);
        names.Add(name);
    }

}
