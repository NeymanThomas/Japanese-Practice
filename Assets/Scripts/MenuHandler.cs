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

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Button btnDeleteStats;
    [SerializeField] private Button btnDeleteScores;
    [SerializeField] private GameObject pnlSettings;
    private bool statsFlag, scoresFlag;

    void Start() {
        pnlSettings.SetActive(false);
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

    public void OpenSettings() {
        SoundManager.instance.Play("Bloop 1");
        pnlSettings.SetActive(true);
        SoundManager.instance.ChangeAudioVolume();
    }

    public void SettingsBack() {
        SoundManager.instance.Play("Bloop 1");
        pnlSettings.SetActive(false);
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
        if (!scoresFlag == false) {
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

    public void Quit() {
        Application.Quit();
    }
}
