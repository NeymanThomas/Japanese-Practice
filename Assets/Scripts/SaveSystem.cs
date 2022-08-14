/// <summary>
/// implements functions that help store data classes used by the application.
/// The data is stored as json files to make for easy reading and writing. 
/// </summary>

using System.IO;
using UnityEngine;
using System;

public static class SaveSystem
{
    // the file path where the stats are saved
    private static string statsPath = Application.persistentDataPath + "/stats.json";
    // the file path where User Preferences are saved
    private static string prefsPath = Application.persistentDataPath + "/userPrefs.json";


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


    public static void CreatePrefsFile() 
    {
        // Create a brand new UserPreferences object
        UserPreferences prefs = new UserPreferences();
        // convert the prefs string into Json string
        string json = JsonUtility.ToJson(prefs);
        // Write the json string into the file
        File.WriteAllText(prefsPath, json);
    }


    public static bool DoStatsExist() 
    {
        if (File.Exists(statsPath))
            return true;
        return false;
    }


    public static bool DoPrefsExist() 
    {
        if (File.Exists(prefsPath))
            return true;
        return false;
    }


    public static void UpdateHiraganaStats(int element) 
    {
        if (!File.Exists(statsPath)) 
        {
            CreateStatsFile();
        }
        // increment mistake by 1
        StatisticalData loadedstats = LoadStats();
        loadedstats.hiraganaMistakes[element] += 1;
        // convert the loaded stats string back into Json string
        string json = JsonUtility.ToJson(loadedstats);
        // Write the json string back into the file
        File.WriteAllText(statsPath, json);
    }


    public static void UpdateKatakanaStats(int element) 
    {
        if (!File.Exists(statsPath)) 
        {
            CreateStatsFile();
        }
        // increment mistake by 1
        StatisticalData loadedStats = LoadStats();
        loadedStats.katakanaMistakes[element] += 1;
        // convert the loaded stats string back into Json string
        string json = JsonUtility.ToJson(loadedStats);
        // Write the json string back into the file
        File.WriteAllText(statsPath, json);
    }


    public static void UpdateUserPrefs(float v, int q, bool full) 
    {
        if (!File.Exists(prefsPath)) 
        {
            CreatePrefsFile();
        }
        UserPreferences prefs = LoadPrefs();
        prefs.volume = v;
        prefs.quality = q;
        prefs.isFullscreen = full;

        // convert the loaded prefs string back into Json string
        string json = JsonUtility.ToJson(prefs);
        // Write the json string back into the file
        File.WriteAllText(prefsPath, json);
    }


    public static void UpdateUserResolution(int index) 
    {
        if (!File.Exists(prefsPath)) 
        {
            CreatePrefsFile();
        }
        UserPreferences prefs = LoadPrefs();
        prefs.resolutionIndex = index;

        // convert the loaded prefs string back into Json string
        string json = JsonUtility.ToJson(prefs);
        // Write the json string back into the file
        File.WriteAllText(prefsPath, json);
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


    public static UserPreferences LoadPrefs() 
    {
        // read the file in as a string from the path
        string prefs = File.ReadAllText(prefsPath);
        // convert the string into UserPreferences from json
        UserPreferences loadedPrefs = JsonUtility.FromJson<UserPreferences>(prefs);
        return loadedPrefs;
    }


    public static void DeleteStats() {
        try {
            File.Delete(statsPath);
            CreateStatsFile();
        }
        catch (Exception ex) {
            Debug.LogException(ex);
        }
    }
}
