using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Highscore
{
    public string date;
    public int playTime;
    public int numberOfMoves;

    public Highscore(string _date, int _playTime, int _numberOfMoves)
    {
        date = _date;
        playTime = _playTime;
        numberOfMoves = _numberOfMoves;
    }
}

public class HighscoreManager : MonoBehaviour
{
    private List<Highscore> highscores = new List<Highscore>(5);
    private bool highscoresAreLoaded = false;
    private string saveDataPath;

    public GameObject highscoreCanvas;
    public List<HighscoreDisplay> highscoreDisplays;

    public static HighscoreManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        saveDataPath = Application.persistentDataPath + "/solitaireSaveData.ssd";
        if (highscoreCanvas.activeSelf)
            highscoreCanvas.SetActive(false);
    }

    public void Add(int time)
    {
        if (highscores.Count == 5 && highscores[4].playTime <= time)
            return;

        string date = DateTime.Now.ToString("dd MMMM yyyy, HH:mm");
        Highscore newHighscore = new Highscore(date, time, CardGameManager.Instance.ActionCounter);

        if (!highscoresAreLoaded)
            Load();

        if (highscores.Count == 5)
            highscores.RemoveAt(4);

        highscores.Add(newHighscore);
        highscores = highscores.OrderBy(highscore => highscore.playTime).ToList();
        Save();
    }

    private void Load()
    {
        if (File.Exists(saveDataPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(saveDataPath, FileMode.Open);

            if(fileStream.Length > 0)
                highscores = formatter.Deserialize(fileStream) as List<Highscore>;
            fileStream.Close();
        }

        highscoresAreLoaded = true;
    }

    private void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(saveDataPath, FileMode.Create);
        formatter.Serialize(fileStream, highscores);
        fileStream.Close();
    }

    // Gets executed by the respective button in the menu bar UI.
    public void OnHighscoreButtonPressed()
    {
        highscoreCanvas.SetActive(!highscoreCanvas.activeSelf);

        if (highscoreCanvas.activeSelf)
        {
            if (!highscoresAreLoaded)
                Load();

            for (int i = 0; i < highscores.Count; i++)
            {
                Highscore highscore = highscores[i];
                if (highscore != null)
                    highscoreDisplays[i].Fill(highscore);
            }
        }             
    }

    // Gets executed by the "reset button" in the highscore canvas.
    public void DeleteAll()
    {
        highscores = new List<Highscore>();
        Save();
        foreach (HighscoreDisplay display in highscoreDisplays)
            display.ResetValues();
    }
}
