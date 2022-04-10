using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TopicsMenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown ChapterSelect;
    [SerializeField] private TMP_Dropdown TopicSelect;
    [SerializeField] private TMP_Text ModeButtonText;
    public static Chapter SelectedChapter;
    public static Topic SelectedTopic;
    public static bool JapaneseToEnglish;

    public enum Chapter {
        All,
        Chapter_1,
        Chapter_2,
        Chapter_3,
        Chapter_4,
        Chapter_5,
        Chapter_6
    }

    public enum Topic {
        All,
        Nouns,
        Verbs,
        Adjectives,
        Adverbs
    }

    private void Start() {
        SelectedChapter = Chapter.All;
        SelectedTopic = Topic.All;
        JapaneseToEnglish = true;
        ChapterSelect.value = (int)SelectedChapter;
        TopicSelect.value = (int)SelectedTopic;
    }

    public void LoadJapaneseToEnglish() {
        if (validateSelection()) {
            SelectedChapter = (Chapter)ChapterSelect.value;
            SelectedTopic = (Topic)TopicSelect.value;
            SoundManager.instance.Play("Bloop 1");
            SceneManager.LoadScene("VocabularyScene");
        } else {
            SoundManager.instance.Play("Bloop 4");
        }
    }

    public void ChangeMode() {
        SoundManager.instance.Play("Bloop 1");
        if (JapaneseToEnglish) {
            JapaneseToEnglish = false;
            ModeButtonText.text = "ENG to JPN";
        } else {
            JapaneseToEnglish = true;
            ModeButtonText.text = "JPN to ENG";
        }
    }

    private bool validateSelection() {
        return true;
    }

    public void BackToMain() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
