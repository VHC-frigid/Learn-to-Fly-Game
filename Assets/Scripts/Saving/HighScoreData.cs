using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class HighScoreData 
{
    
    public float[] scores;
    public string[] names;

    public Float3 playerPosition;
    
    public HighScoreData()
    {
        scores = new[] { 99f, 40f, 2f };
        names = new string [] { "Andrew", "Edward", "Adam" };
    }

    public HighScoreData(float[] scores, string[] names)
    {
        this.scores = scores;
        this.names = names;
    }

    public HighScoreData(float[] scores, string[] names, Vector3 position)
    {
        this.scores = scores;
        this.names = names;
        this.playerPosition = new Float3(position);
    }

}
[System.Serializable]
public class Float3
{
    public float x, y, z;

    public Float3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }
}
