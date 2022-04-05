﻿/// <summary>
/// This is the main menu class for the Japanese Practice application.
/// It's primary purpose is to provide the main UI Elements that navigate the user
/// to different parts of the application. functions implemented include:
///     -> Directing user to Hiragana Scene
///     -> Directing user to Katakana Scene
///     -> Allowing user to see their stats 
///     -> Allowing user to Delete their stats
///     -> Allowing user to Delete their scores
///     -> Quit button to exit the application
/// </summary>

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Button btnDeleteStats;
    [SerializeField] private Button btnDeleteScores;
    [SerializeField] private GameObject pnlSettings;
    [SerializeField] private GameObject pnlDictionary;
    [SerializeField] private TMP_Text txtVolumeNumber;
    [SerializeField] private TMP_Text txtResult;
    [SerializeField] private Slider scrollbar;
    [SerializeField] private TMP_InputField dictionaryInput;
    private bool statsFlag, scoresFlag;

    void Start() {
        initSettings();
        pnlSettings.SetActive(false);
        pnlDictionary.SetActive(false);
    }

    /// <summary>
    /// Function that will handle loading in all of the user data and settings
    /// that need to be taken care of.
    /// </summary>
    private void initSettings() {

    }

    public void LoadHiragana() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("HiraganaMenu");
    }

    public void LoadKatakana() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("KatakanaMenu");
    }

    public void LoadTopics() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("TopicsMenu");
    }

    public void LoadStats() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("StatisticsMenu");
    }

    public void DeleteStats() {
        SoundManager.instance.Play("Bloop 3");
        if (statsFlag == false) {
            btnDeleteStats.image.color = new Color32(255, 0, 0, 255);
            btnDeleteStats.GetComponentInChildren<TMP_Text>().text = "ARE YOU SURE?";
            statsFlag = true;
        }
        else {
            SaveSystem.DeleteStats();
            btnDeleteStats.image.color = new Color32(255, 255, 255, 255);
            btnDeleteStats.GetComponentInChildren<TMP_Text>().text = "Stats Deleted";
        }
    }

    public void DeleteScores() {
        SoundManager.instance.Play("Bloop 3");
        if (scoresFlag == false) {
            btnDeleteScores.image.color = new Color32(255, 0, 0, 255);
            btnDeleteScores.GetComponentInChildren<TMP_Text>().text = "ARE YOU SURE?";
            scoresFlag = true;
        }
        else {
            SaveSystem.DeleteScores();
            btnDeleteScores.image.color = new Color32(255, 255, 255, 255);
            btnDeleteScores.GetComponentInChildren<TMP_Text>().text = "Scores Deleted";
        }
    }

    #region Dictionary Methods

    public void LoadDictionary() {
        SoundManager.instance.Play("Bloop 1");
        pnlDictionary.SetActive(true);
        txtResult.text = "日本語";
        dictionaryInput.text = "";
    }

    public void WordLookup() {
        string result = JapaneseDictionaries.DictionaryLookup(dictionaryInput.text);
        txtResult.text = result;
        Debug.Log(result);
    }

    public void BackToMainMenu() {
        SoundManager.instance.Play("Bloop 1");
        pnlDictionary.SetActive(false);
    }

    #endregion

    #region Settings Methods

    public void OpenSettings() {
        SoundManager.instance.Play("Bloop 1");
        pnlSettings.SetActive(true);
        scrollbar.value = SoundManager.instance.sounds[0].source.volume;
    }

    public void AdjustVolume(float newVolume) {
        SoundManager.instance.ChangeAudioVolume(newVolume);
        txtVolumeNumber.text = Mathf.RoundToInt(newVolume * 100).ToString();
    }

    public void SettingsBack() {
        SoundManager.instance.Play("Bloop 1");
        pnlSettings.SetActive(false);
    }

    #endregion

    public void Quit() {
        Application.Quit();
    }
}
