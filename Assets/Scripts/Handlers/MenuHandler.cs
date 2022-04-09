/// <summary>
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
using System.Collections.Generic;

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
    [SerializeField] private TMP_Dropdown graphicsDropdown;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private bool statsFlag, scoresFlag;

    void Start() {
        initSettings();
        pnlSettings.SetActive(false);
        pnlDictionary.SetActive(false);
    }

    // Function that will handle loading in all of the user data and settings that need to be taken care of.
    private void initSettings() {
        // load user settings
        // Volume setting, graphic setting, resolution, fullscreen
        // check to see if save files exist
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

    #region Dictionary Methods

    // Initializes the dictionary panel 
    public void LoadDictionary() {
        SoundManager.instance.Play("Bloop 1");
        pnlDictionary.SetActive(true);
        txtResult.text = "日本語";
        dictionaryInput.text = "";
    }

    /// <summary>
    /// Called by the main menu when a word is entered into the dictionary input field.
    /// The string from the input field is sent to the static JapaneseDictionaries class
    /// and passed to the DictionaryLookup function. If the DictionaryLookup finds a match
    /// for the key sent, it will then send back the element matched with the key. If the
    /// word has no match, instead a literal string of "Error" will be sent back instead.
    /// </summary>
    public void WordLookup() {
        string result = JapaneseDictionaries.DictionaryLookup(dictionaryInput.text);
        if (result != "Error") 
        {
            SoundManager.instance.Play("Bloop 1");
            txtResult.text = result;
        } 
        else 
        {
            SoundManager.instance.Play("Bloop 4");
            dictionaryInput.text = "Word Not Found!";
        }
    }

    public void WordPronunciation() {
        SoundManager.instance.Play("Bloop 1");
        Debug.LogWarning("Not Implemented");
    }

    // Returns to the main menu from the dictionary panel
    public void BackToMainMenu() {
        SoundManager.instance.Play("Bloop 1");
        pnlDictionary.SetActive(false);
    }

    #endregion

    #region Settings Methods

    public void OpenSettings() {
        SoundManager.instance.Play("Bloop 1");
        pnlSettings.SetActive(true);

        // set the scrollbar value to the current sound setting
        scrollbar.value = SoundManager.instance.sounds[0].source.volume;

        // set the graphics setting to the current graphics quality
        graphicsDropdown.value = QualitySettings.GetQualityLevel();

        // Add the available screen resolutions to the dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        int currentResolution = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolution = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void AdjustVolume(float newVolume) {
        SoundManager.instance.ChangeAudioVolume(newVolume);
        txtVolumeNumber.text = Mathf.RoundToInt(newVolume * 100).ToString();
    }

    public void AdjustGraphics(int quality) {
        QualitySettings.SetQualityLevel(quality);
    }

    public void AdjustFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SettingsBack() {
        SoundManager.instance.Play("Bloop 1");
        pnlSettings.SetActive(false);
    }

    public void AdjustResolution(int resolutionIndex) {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
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

    #endregion

    public void Quit() {
        Application.Quit();
    }
}
