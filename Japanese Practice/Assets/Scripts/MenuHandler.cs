using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Button btnDeleteStats;
    [SerializeField] private Button btnDeleteScores;
    private bool statsFlag, scoresFlag;

    public void LoadHiragana() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("HiraganaMenu");
    }

    public void LoadKatakana() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("KatakanaMenu");
    }

    public void LoadPhrases() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("PhrasesMenu");
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

    public void Quit() {
        Application.Quit();
    }
}
