using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager
{
    private string soundKey = "sound";
    private string highScoreKey = "highScore";
    
    public int getHighScore()
    {
        return PlayerPrefs.GetInt(highScoreKey, 0);
    }

    public int getSound()
    {
        return PlayerPrefs.GetInt(soundKey, 1);
    }

    public void setSound(int volume)
    {
        PlayerPrefs.SetInt(soundKey, volume);
        PlayerPrefs.Save();
    }
    
    public void setHighestScore(int newScore)
    {
        PlayerPrefs.SetInt(highScoreKey, newScore);
        PlayerPrefs.Save();
    }
}
