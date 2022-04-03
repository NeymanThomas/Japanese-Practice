using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TopicsMenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text test;
    void Start()
    {
        test.text = JapaneseDictionaries.EnglishToJapanese["student"];
    }

    public void BackToMain() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
