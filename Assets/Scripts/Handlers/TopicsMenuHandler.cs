using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TopicsMenuHandler : MonoBehaviour
{
    public void LoadJapaneseToEnglish() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("VocabularyScene");
    }

    public void BackToMain() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
