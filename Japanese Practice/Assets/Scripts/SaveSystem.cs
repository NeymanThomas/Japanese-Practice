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
    public static bool H_Score_Exists() {
        if (File.Exists(Application.persistentDataPath + "/h_score.tommy")) {
            return true;
        }
        return false;
    }

    public static bool K_Score_Exists() {
        if (File.Exists(Application.persistentDataPath + "/k_score.tommy")) {
            return true;
        }
        return false;
    }

    public static bool Stats_Exist() {
        if (File.Exists(Application.persistentDataPath + "/stats.tommy")) {
            return true;
        }
        return false;
    }

    // Saves a high score from the Hiragana Challenge Mode
    public static void Save_H_Score(float score) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/h_score.tommy";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, score);
        stream.Close();
    }

    // Saves a high score from the Katakana Challenge Mode
    public static void Save_K_Score(float score) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/k_score.tommy";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, score);
        stream.Close();
    }

    // accepts the string for the Hiragana that caused you to fail the challenge 
    // mode and tallies it to your stats.
    public static void Save_Hiragana(string h) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stats.tommy";
        if (File.Exists(path)) {
            StatisticalData stats = Load_Stats();
            stats.add_H_Stat(h);
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, stats);
            stream.Close();
        }
        else {
            StatisticalData stats = new StatisticalData();
            stats.add_H_Stat(h);
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, stats);
            stream.Close();
        }
    }

    // accepts the string for the Katakana that caused you to fail the challenge 
    // mode and tallies it to your stats.
    public static void Save_Katakana(string h) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stats.tommy";
        if (File.Exists(path)) {
            StatisticalData stats = Load_Stats();
            stats.add_K_Stat(h);
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, stats);
            stream.Close();
        }
        else {
            StatisticalData stats = new StatisticalData();
            stats.add_K_Stat(h);
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, stats);
            stream.Close();
        }
    }

    public static StatisticalData Load_Stats() {
        string path = Application.persistentDataPath + "/stats.tommy";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        StatisticalData stats = formatter.Deserialize(stream) as StatisticalData;
        stream.Close();
        return stats;
    }

    public static float Load_H_Score() {
        string path = Application.persistentDataPath + "/h_score.tommy";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            float loadedScore = (float)formatter.Deserialize(stream);
            stream.Close();
            return loadedScore;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return 0;
        }
    }

    public static float Load_K_Score() {
        string path = Application.persistentDataPath + "/k_score.tommy";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            float loadedScore = (float)formatter.Deserialize(stream);
            stream.Close();
            return loadedScore;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return 0;
        }
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
