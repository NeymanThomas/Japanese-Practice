using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using System;

public class VocabularySceneHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text QuestionText;
    [SerializeField] private TMP_Text AnswerText;
    [SerializeField] private TMP_Text PronunciationText;
    private System.Random rand;
    private int currentIndex;
    private int chapterIndexStart, chapterIndexEnd;

    private void Start()
    {
        rand = new System.Random();
        init();
        AnswerText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(chapterIndexStart, chapterIndexEnd);
        QuestionText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key;
    }

    private void init() {
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
                chapterIndexStart = 0;
                chapterIndexEnd = 1;
                break;
        }
    }

    public void NextQuestion() {
        SoundManager.instance.Play("Bloop 1");
        AnswerText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(chapterIndexStart, chapterIndexEnd);
        QuestionText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key;
    }

    public void ShowAnswer() {
        SoundManager.instance.Play("Bloop 1");
        PronunciationText.text = "";
        AnswerText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Value;
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
}
