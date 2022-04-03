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
    private System.Random rand;
    private int currentIndex;

    private void Start()
    {
        rand = new System.Random();
        AnswerText.text = "";
        currentIndex = rand.Next(0, JapaneseDictionaries.EnglishToJapanese.Count);
        QuestionText.text = JapaneseDictionaries.EnglishToJapanese.ElementAt(currentIndex).Value;
    }

    public void NextQuestion() {
        SoundManager.instance.Play("Bloop 1");
        AnswerText.text = "";
        currentIndex = rand.Next(0, JapaneseDictionaries.EnglishToJapanese.Count);
        QuestionText.text = JapaneseDictionaries.EnglishToJapanese.ElementAt(currentIndex).Value;
    }

    public void ShowAnswer() {
        SoundManager.instance.Play("Bloop 1");
        AnswerText.text = JapaneseDictionaries.JapaneseToEnglish.ElementAt(currentIndex).Value;
    }

    public void BackToTopicsMenu() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("TopicsMenu");
    }
}
