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

    public static void Save_H_Score(float score) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/h_score.tommy";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, score);
        stream.Close();
    }

    public static void Save_K_Score(float score) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/k_score.tommy";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, score);
        stream.Close();
    }

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
