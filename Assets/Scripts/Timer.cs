using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    private DateTime startTime;
    private DateTime endTime;

    void Awake() 
    {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartTimer() 
    {
        startTime = DateTime.Now;
    }

    public void AddTimePassed()
    {
        endTime = DateTime.Now;
        TimeSpan diff = endTime.Subtract(startTime);
        SaveSystem.UpdateTimePassed((int)diff.TotalSeconds);
    }
}
