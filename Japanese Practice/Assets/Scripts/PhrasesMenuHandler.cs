/// <summary>
/// This Scene will be used to practice popular Japanese Vocabulary and Phrases
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhrasesMenuHandler : MonoBehaviour
{
    public void BackToMain() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
