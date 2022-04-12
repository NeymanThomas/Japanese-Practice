using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class VocabularySceneHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text QuestionText;
    [SerializeField] private TMP_Text AnswerText;
    [SerializeField] private TMP_Text PronunciationText;
    [SerializeField] private GameObject NextJapaneseButton;
    [SerializeField] private GameObject NextEnglishButton;
    [SerializeField] private GameObject ShowEnglishButton;
    [SerializeField] private GameObject ShowJapaneseButton;

    private System.Random rand;
    private int currentIndex;
    private int chapterIndexStart, chapterIndexEnd;

    private void Start()
    {
        rand = new System.Random();
        QuestionText.text = "";
        AnswerText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(chapterIndexStart, chapterIndexEnd);
        initVocabSettings();
    }

    private void initVocabSettings() {
        // Check if the user selected Japanese to English or
        // English to Japanese, then activate the appropriate buttons.
        if (TopicsMenuHandler.JapaneseToEnglish) {
            NextJapaneseButton.SetActive(true);
            ShowEnglishButton.SetActive(true);
            NextEnglishButton.SetActive(false);
            ShowJapaneseButton.SetActive(false);
            QuestionText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key;
        } else {
            NextJapaneseButton.SetActive(false);
            ShowEnglishButton.SetActive(false);
            NextEnglishButton.SetActive(true);
            ShowJapaneseButton.SetActive(true);
            AnswerText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Value;
        }

        // Sets the limits on what the random number generator can generate based
        // on what the user selected for a chapter. The full dictionary is used
        // if all chapters option was selected.
        switch(TopicsMenuHandler.SelectedChapter) {
            case TopicsMenuHandler.Chapter.All:
                chapterIndexStart = 0;
                chapterIndexEnd = JapaneseDictionaries.JapaneseToEnglish.Count;
                break;
            case TopicsMenuHandler.Chapter.Chapter_1:
                chapterIndexStart = 0;
                chapterIndexEnd = 138;
                break;
            case TopicsMenuHandler.Chapter.Chapter_2:
                chapterIndexStart = 138;
                chapterIndexEnd = 209;
                break;
            case TopicsMenuHandler.Chapter.Chapter_3:
                chapterIndexStart = 209;
                chapterIndexEnd = 263;
                break;
            case TopicsMenuHandler.Chapter.Chapter_4:
                chapterIndexStart = 263;
                chapterIndexEnd = 351;
                break;
            case TopicsMenuHandler.Chapter.Chapter_5:
                chapterIndexStart = 351;
                chapterIndexEnd = 405;
                break;
            case TopicsMenuHandler.Chapter.Chapter_6:
                chapterIndexStart = 405;
                chapterIndexEnd = 452;
                break;
        }
    }

    #region Button Methods

    public void NextJapaneseQuestion() {
        SoundManager.instance.Play("Bloop 1");
        AnswerText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(chapterIndexStart, chapterIndexEnd);
        QuestionText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key;
    }

    public void ShowEnglishAnswer() {
        SoundManager.instance.Play("Bloop 1");
        PronunciationText.text = "";
        AnswerText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Value;
    }

    public void NextEnglishQuestion() {
        SoundManager.instance.Play("Bloop 1");
        QuestionText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(chapterIndexStart, chapterIndexEnd);
        AnswerText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Value;
    }

    public void ShowJapaneseAnswer() {
        SoundManager.instance.Play("Bloop 1");
        QuestionText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key;
    }

    public void ShowPronunciation() {
        if (JapaneseDictionaries.KanjiToHiragana.ContainsKey(JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key)) {
            AnswerText.text = "";
            SoundManager.instance.Play("Bloop 1");
            PronunciationText.text = JapaneseDictionaries.KanjiToHiragana[JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key];
        }
    }

    public void BackToTopicsMenu() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("TopicsMenu");
    }

    #endregion
}
