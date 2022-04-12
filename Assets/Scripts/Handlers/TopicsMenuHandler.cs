using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TopicsMenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown ChapterSelect;
    [SerializeField] private TMP_Dropdown TopicSelect;
    [SerializeField] private TMP_Text ModeButtonText;
    public static Chapter SelectedChapter;
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
        JapaneseToEnglish = true;
        ChapterSelect.value = (int)SelectedChapter;
        TopicSelect.value = 0;
    }

    public void LoadNextScene() {
        switch(TopicSelect.value) {
            case (int)Topic.All:
                SelectedChapter = (Chapter)ChapterSelect.value;
                SoundManager.instance.Play("Bloop 1");
                SceneManager.LoadScene("VocabularyScene");
                break;
            case (int)Topic.Nouns:
                SoundManager.instance.Play("Bloop 1");
                SceneManager.LoadScene("NounScene");
                break;
            case (int)Topic.Verbs:
                SoundManager.instance.Play("Bloop 1");
                SceneManager.LoadScene("NounScene");
                break;
            case (int)Topic.Adjectives:
                SoundManager.instance.Play("Bloop 1");
                SceneManager.LoadScene("NounScene");
                break;
            case (int)Topic.Adverbs:
                SoundManager.instance.Play("Bloop 1");
                SceneManager.LoadScene("NounScene");
                break;
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

    public void BackToMain() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
