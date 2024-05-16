using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadGame : MonoBehaviour
{
    private HighScoreData data = new HighScoreData();
    
    public void SaveGame()
    {
        JsonSaveLoad.Save(data);
    }

    public void LoadGame()
    {

    }
}
