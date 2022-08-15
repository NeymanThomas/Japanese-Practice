/// <summary>
/// The statistcs menu is used to display
/// </summary>

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class StatsMenuHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text h_scoreBlock_1, h_scoreBlock_2, h_scoreBlock_3, h_scoreBlock_4, h_scoreBlock_5, h_scoreBlock_6, h_scoreBlock_7;
    [SerializeField] 
    private TMP_Text k_scoreBlock_1, k_scoreBlock_2, k_scoreBlock_3, k_scoreBlock_4, k_scoreBlock_5, k_scoreBlock_6, k_scoreBlock_7;
    [SerializeField]
    private GameObject hiraganaPanel, katakanaPanel, statsPanel;
    [SerializeField]
    private TMP_Text txtTimeSpent, txtHiraganaHS, txtKatakanaHS;
    StatisticalData stats;


    private void Start() 
    {
        if (!SaveSystem.DoStatsExist()) 
        {
            SaveSystem.CreateStatsFile();
        }
        stats = SaveSystem.LoadStats();

        hiraganaPanel.gameObject.SetActive(true);
        katakanaPanel.gameObject.SetActive(false);
        statsPanel.gameObject.SetActive(false);
        ShowHiraganaScores();
    }

    public void ShowHiraganaScores() 
    {
        int i;
        h_scoreBlock_1.text = "";
        h_scoreBlock_2.text = "";
        h_scoreBlock_3.text = "";
        h_scoreBlock_4.text = "";
        h_scoreBlock_5.text = "";
        h_scoreBlock_6.text = "";
        h_scoreBlock_7.text = "";

        for (i = 0; i < 10; i++) 
        {
            h_scoreBlock_1.text += (stats.hiraganaMistakes[i].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            h_scoreBlock_2.text += (stats.hiraganaMistakes[i + 10].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            h_scoreBlock_3.text += (stats.hiraganaMistakes[i + 20].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            h_scoreBlock_4.text += (stats.hiraganaMistakes[i + 30].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            h_scoreBlock_5.text += (stats.hiraganaMistakes[i + 40].ToString() + "\n");
        }
        for (i = 0; i < 11; i++) 
        {
            h_scoreBlock_6.text += (stats.hiraganaMistakes[i + 50].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            h_scoreBlock_7.text += (stats.hiraganaMistakes[i + 61].ToString() + "\n");
        }
    }

    public void ShowKatakanaScores() 
    {
        int i;
        k_scoreBlock_1.text = "";
        k_scoreBlock_2.text = "";
        k_scoreBlock_3.text = "";
        k_scoreBlock_4.text = "";
        k_scoreBlock_5.text = "";
        k_scoreBlock_6.text = "";
        k_scoreBlock_7.text = "";

        for (i = 0; i < 10; i++) 
        {
            k_scoreBlock_1.text += (stats.katakanaMistakes[i].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            k_scoreBlock_2.text += (stats.katakanaMistakes[i + 10].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            k_scoreBlock_3.text += (stats.katakanaMistakes[i + 20].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            k_scoreBlock_4.text += (stats.katakanaMistakes[i + 30].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            k_scoreBlock_5.text += (stats.katakanaMistakes[i + 40].ToString() + "\n");
        }
        for (i = 0; i < 11; i++) 
        {
            k_scoreBlock_6.text += (stats.katakanaMistakes[i + 50].ToString() + "\n");
        }
        for (i = 0; i < 10; i++) 
        {
            k_scoreBlock_7.text += (stats.katakanaMistakes[i + 61].ToString() + "\n");
        }
    }

    public void ShowStats() 
    {
        TimeSpan t = TimeSpan.FromSeconds(stats.secondsSpentPracticing);
        txtTimeSpent.text = t.ToString(@"dd\:hh\:mm\:ss");
        txtHiraganaHS.text = stats.hiraganaHighscore.ToString("0.##");
        txtKatakanaHS.text = stats.katakanaHighscore.ToString("0.##");
    }

    public void Next() {
        SoundManager.instance.Play("Bloop 1");
        if (hiraganaPanel.gameObject.activeSelf == true) {
            hiraganaPanel.gameObject.SetActive(false);
            katakanaPanel.gameObject.SetActive(true);
            ShowKatakanaScores();
        }
        else if (katakanaPanel.gameObject.activeSelf == true) {
            katakanaPanel.gameObject.SetActive(false);
            statsPanel.gameObject.SetActive(true);
            ShowStats();
        }
        else if (statsPanel.gameObject.activeSelf == true) {
            statsPanel.gameObject.SetActive(false);
            hiraganaPanel.gameObject.SetActive(true);
            ShowHiraganaScores();
        }
    }

    public void Back() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
