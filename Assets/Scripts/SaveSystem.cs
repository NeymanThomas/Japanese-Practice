/// <summary>
/// The static SaveSystem Class implements functions that help store simple
/// data sets that are tracked by the application. These include
///     -> High scores for both Hiragana and Katakana Challenges
///     -> All tallied Hiragana mistakes
///     -> All Tallied Katakana mistakes
/// The files of data are stored as .tommy files in Unity's persistent
/// data path. Because the data being saved is very simple, a binary
/// serializer is used.
/// </summary>

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;

public static class SaveSystem
{
    // the file path where the stats are saved
    private static string statsPath = Application.persistentDataPath + "/stats.json";

    // This function creates a new StatisticalData object and writes it to the
    // filepath. This will be called when no stats file is found.
    public static void CreateStatsFile() 
    {
        // Create a brand new StatisticalData Object
        StatisticalData stats = new StatisticalData();
        // convert the stats string into Json string
        string json = JsonUtility.ToJson(stats);
        // Write the json string into the file
        File.WriteAllText(statsPath, json);
    }


    public static void UpdateHiraganaStats(int element) 
    {
        if (!File.Exists(statsPath)) 
        {
            CreateStatsFile();
        }
        // increment mistake by 1
        // convert the loaded stats string back into Json string
        string json = JsonUtility.ToJson(LoadStats().hiraganaMistakes[element]++);
        // Write the json string back into the file
        File.WriteAllText(statsPath, json);
    }


    public static void UpdateKatakanaStats(int element) 
    {
        if (!File.Exists(statsPath)) 
        {
            CreateStatsFile();
        }
        // read the file in as a string from the path
        string stats = File.ReadAllText(statsPath);
        // convert the string into StatisticalData from json
        StatisticalData loadedStats = JsonUtility.FromJson<StatisticalData>(stats);
        // increment mistake by 1
        loadedStats.katakanaMistakes[element]++;
        // convert the loaded stats string back into Json string
        string json = JsonUtility.ToJson(loadedStats);
        // Write the json string back into the file
        File.WriteAllText(statsPath, json);
    }


    public static bool UpdateHiraganaHighscore(float score) 
    {
        if (!File.Exists(statsPath)) 
        {
            CreateStatsFile();
        }
        // read the file in as a string from the path
        string stats = File.ReadAllText(statsPath);
        // convert the string into StatisticalData from json
        StatisticalData loadedStats = JsonUtility.FromJson<StatisticalData>(stats);

        if (loadedStats.hiraganaHighscore < score) 
        {
            // Set the new highscore
            loadedStats.hiraganaHighscore = score;
            // convert the loaded stats string back into Json string
            string json = JsonUtility.ToJson(loadedStats);
            // Write the json string back into the file
            File.WriteAllText(statsPath, json);
            return true;
        }
        return false;
    }


    public static bool UpdateKatakanaHighscore(float score) 
    {
        if (!File.Exists(statsPath)) 
        {
            CreateStatsFile();
        }
        // read the file in as a string from the path
        string stats = File.ReadAllText(statsPath);
        // convert the string into StatisticalData from json
        StatisticalData loadedStats = JsonUtility.FromJson<StatisticalData>(stats);

        if (loadedStats.katakanaHighscore < score) 
        {
            // Set the new highscore
            loadedStats.katakanaHighscore = score;
            // convert the loaded stats string back into Json string
            string json = JsonUtility.ToJson(loadedStats);
            // Write the json string back into the file
            File.WriteAllText(statsPath, json);
            return true;
        }
        return false;
    }


    public static float LoadHiraganaScore() 
    {
        if (!File.Exists(statsPath)) 
        {
            CreateStatsFile();
            return 0;
        }
        return LoadStats().hiraganaHighscore;
    }


    public static float LoadKatakanaScore() 
    {
        if (!File.Exists(statsPath)) 
        {
            CreateStatsFile();
            return 0;
        }
        return LoadStats().katakanaHighscore;
    }


    public static StatisticalData LoadStats() 
    {
        // read the file in as a string from the path
        string stats = File.ReadAllText(statsPath);
        // convert the string into StatisticalData from json
        StatisticalData loadedStats = JsonUtility.FromJson<StatisticalData>(stats);
        return loadedStats;
    }












    public static void DeleteStats() {
        string path = Application.persistentDataPath + "/stats.tommy";
        try {
            File.Delete(path);
        }
        catch (Exception ex) {
            Debug.LogException(ex);
        }
    }

    public static void DeleteScores() {
        string path = Application.persistentDataPath + "/h_score.tommy";
        try {
            File.Delete(path);
        }
        catch (Exception ex) {
            Debug.LogException(ex);
        }
        path = Application.persistentDataPath + "/k_score.tommy";
        try {
            File.Delete(path);
        }
        catch (Exception ex) {
            Debug.LogException(ex);
        }
    }
    
}
