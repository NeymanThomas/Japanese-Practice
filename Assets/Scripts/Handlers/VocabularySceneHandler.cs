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

    private void Start()
    {
        rand = new System.Random();
        AnswerText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(0, JapaneseDictionaries.JapaneseToEnglish.Count);
        QuestionText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Key;
    }

    public void NextQuestion() {
        SoundManager.instance.Play("Bloop 1");
        AnswerText.text = "";
        PronunciationText.text = "";
        currentIndex = rand.Next(0, JapaneseDictionaries.JapaneseToEnglish.Count);
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
