using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JsonSaveLoad 
{

    private static string file = Application.dataPath + "/highscores.json";

    public static void Save(HighScoreData data)
    {
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(file, json);
    }
}
