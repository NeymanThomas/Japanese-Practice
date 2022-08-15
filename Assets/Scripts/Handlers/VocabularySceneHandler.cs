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
        Timer.instance.StartTimer();
        rand = new System.Random();
        QuestionText.text = "";
        AnswerText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(chapterIndexStart, chapterIndexEnd);
        initVocabSettings();
    }

    private void initVocabSettings()
    {
        // Check if the user selected Japanese to English or
        // English to Japanese, then activate the appropriate buttons.
        if (TopicsMenuHandler.JapaneseToEnglish)
        {
            NextJapaneseButton.SetActive(true);
            ShowEnglishButton.SetActive(true);
            NextEnglishButton.SetActive(false);
            ShowJapaneseButton.SetActive(false);
            QuestionText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key;
        }
        else
        {
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

    // This function prints the Japanese word at the current element, but ensures
    // that if the word becomes too long in length, the font will shrink according
    // to the word's length
    private void generateJapaneseString(TMP_Text t) 
    {
        t.fontSize = 240;
        string temp = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key;

        if (temp.Length > 6) 
        {
            for (int i = 6; i < temp.Length; i++)
            {
                t.fontSize -= 20;
            }
        }
        t.text = temp;
    }

    // This function prints the English word at the current element, but ensures
    // that if the word becomes too long in length, the font will shrink according
    // to the word's length
    private void generateEnglishString(TMP_Text t) 
    {
        t.fontSize = 180;
        string temp = AnswerText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Value;

        if (temp.Length > 16) 
        {
            for (int i = 16; i < temp.Length; i++) 
            {
                if (t.fontSize > 90)
                {
                    t.fontSize -= 10;
                }
            }
        }
        t.text = temp;
    }

    // This function prints the hiragana pronunciation at the current element, but ensures
    // that if the word becomes too long in length, the font will shrink according
    // to the word's length
    private void generatePronunciationString(TMP_Text t) 
    {
        t.fontSize = 180;
        string temp = JapaneseDictionaries.KanjiToHiragana[JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key];

        if (temp.Length > 8) 
        {
            for (int i = 8; i < temp.Length; i++)
            {
                if (t.fontSize > 90)
                {
                    t.fontSize -= 10;
                }
            }
        }
        t.text = temp;
    }

    #region Button Methods

    public void NextJapaneseQuestion() {
        SoundManager.instance.Play("Bloop 1");
        AnswerText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(chapterIndexStart, chapterIndexEnd);
        generateJapaneseString(QuestionText);
    }

    public void ShowEnglishAnswer() {
        SoundManager.instance.Play("Bloop 1");
        PronunciationText.text = "";
        generateEnglishString(AnswerText);
    }

    public void NextEnglishQuestion() {
        SoundManager.instance.Play("Bloop 1");
        QuestionText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(chapterIndexStart, chapterIndexEnd);
        generateEnglishString(AnswerText);
    }

    public void ShowJapaneseAnswer() {
        SoundManager.instance.Play("Bloop 1");
        generateJapaneseString(QuestionText);
    }

    public void ShowPronunciation() {
        if (JapaneseDictionaries.KanjiToHiragana.ContainsKey(JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key)) {
            AnswerText.text = "";
            SoundManager.instance.Play("Bloop 1");
            generatePronunciationString(PronunciationText);
        }
    }

    public void BackToTopicsMenu() {
        SoundManager.instance.Play("Bloop 1");
        Timer.instance.AddTimePassed();
        SceneManager.LoadScene("TopicsMenu");
    }

    #endregion
}
