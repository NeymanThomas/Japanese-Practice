/// <summary>
/// This class handles all uses of Hiragana practice in the app.
/// Implemented functions:
///     -> user practices by seeing hiragana symbols
///     -> user practices by seeing random hiragana symbols
///     -> user practices by seeing romanji for hiragana
///     -> user practices by seeing random romanji for hiragana symbols
///     -> the user can challenge themselves with a timer to correctly 
///     guess random hiragana symbols and receive a score
///     -> the user can go back to the main menu
/// 
/// The handler functions by enabling and disabling various Panels in the
/// scene. the default 'menuPanel' is enabled on Awake of the scene and all
/// other Panels are disabled. Upon selecting an option for practice, a
/// corresponding panel will be enabled while the previous panel is disabled.
/// For example, selecting 'Practice Hiragana' will disable the 'menuPanel'
/// and enable the 'hiraganaPanel'. This hides the menu from view and only
/// shows the user the panel for practicing Hiragana.
/// 
/// In order to be interacted with, the UI elements must be serialized and
/// listed inside of the HiraganaMenuHandler Class.
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class HiraganaMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject hiraganaPanel;
    [SerializeField] private GameObject romajiPanel;
    [SerializeField] private GameObject challengePanel;
    [SerializeField] private TMP_Text romajiText;
    [SerializeField] private TMP_Text showHiraganaText;
    [SerializeField] private TMP_Text showHiraganaSecondaryText;
    [SerializeField] private TMP_Text hiraganaText;
    [SerializeField] private TMP_Text showRomajiText;
    [SerializeField] private TMP_InputField answer;
    [SerializeField] private TMP_Text points;
    [SerializeField] private TMP_Text highScore;
    [SerializeField] private TMP_Text challengeHiragana;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private TMP_Text timeLeft;

    private int bookmark; // The bookmark refers to the current position in the dictionary
    private float score;
    private float timeAdder;
    private System.Random rand;

    // Make sure at Awake that the menuPanel is the only GameObject active
    private void Awake() {
        menuPanel.gameObject.SetActive(true);
        hiraganaPanel.gameObject.SetActive(false);
        romajiPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(false);
    }

    // Initialize the objects and other values
    private void Start() {
        rand = new System.Random();
        bookmark = 0;
    }

    #region Button Methods

    // Enables the romaji menu and begins ordered practice
    public void RomajiClicked() 
    {
        menuPanel.gameObject.SetActive(false);
        romajiPanel.gameObject.SetActive(true);
        bookmark = -1;
        NextRomaji();
    }

    // Enables the romaji menu and begins random practice
    public void RandomRomajiClicked() 
    {
        menuPanel.gameObject.SetActive(false);
        romajiPanel.gameObject.SetActive(true);
        NextRandomRomaji();
    }

    // Enables the hiragana menu and begins ordered practice
    public void HiraganaClicked() 
    {
        menuPanel.gameObject.SetActive(false);
        hiraganaPanel.gameObject.SetActive(true);
        bookmark = -1;
        NextHiragana();
    }

    // Enables the hiragana menu and begins random practice
    public void RandomHiraganaClicked() 
    {
        menuPanel.gameObject.SetActive(false);
        hiraganaPanel.gameObject.SetActive(true);
        NextRandomHiragana();
    }

    public void NextRomaji() 
    {
        SoundManager.instance.Play("Bloop 1");
        bookmark++;
        if (bookmark >= JapaneseDictionaries.HiraganaToEnglish.Count) 
        {
            bookmark = 0;
        }
        showHiraganaText.text = "";
        showHiraganaSecondaryText.text = "";
        romajiText.text = JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Value;
    }

    public void NextRandomRomaji() 
    {
        SoundManager.instance.Play("Bloop 1");
        showHiraganaText.text = "";
        showHiraganaSecondaryText.text = "";
        bookmark = rand.Next(0, JapaneseDictionaries.HiraganaToEnglish.Count);
        romajiText.text = JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Value;
    }

    public void NextHiragana() 
    {
        SoundManager.instance.Play("Bloop 1");
        bookmark++;
        if (bookmark >= JapaneseDictionaries.HiraganaToEnglish.Count) 
        {
            bookmark = 0;
        }
        showRomajiText.text = "";
        hiraganaText.text = JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Key;
    }

    public void NextRandomHiragana() 
    {
        SoundManager.instance.Play("Bloop 1");
        showRomajiText.text = "";
        bookmark = rand.Next(0, JapaneseDictionaries.HiraganaToEnglish.Count);
        romajiText.text = JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Key;
    }

    // Method to show the Hiragana of the associated romaji being pointed to by the bookmark
    public void ShowHiragana() 
    {
        SoundManager.instance.Play("Bloop 1");
        showHiraganaText.text = JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Key;
        // Have to check for the hiragana characters that have the same pronunciation
        if (bookmark == 52)
            showHiraganaSecondaryText.text = "ぢ";
        if (bookmark == 53)
            showHiraganaSecondaryText.text = "じ";
        if (bookmark == 54)
            showHiraganaSecondaryText.text = "づ";
        if (bookmark == 55)
            showHiraganaSecondaryText.text = "ず";
    }

    // Method to show the Romaji of the associated hiragana being pointed to by the bookmark
    public void ShowRomaji() {
        SoundManager.instance.Play("Bloop 1");
        showRomajiText.text = JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Value;
    }

    #endregion

    #region challenge Mode

    // Initalizes the panel for the challenge mode. If a high score exists, display it. 
    public void ShowChallengeMenu() {
        SoundManager.instance.Play("Bloop 1");
        menuPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(true);
        answer.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(false);

        highScore.text = SaveSystem.LoadHiraganaScore().ToString("0.##");
        endText.text = "";
        points.text = "0";
        score = 0;
        answer.ActivateInputField();
        NextChallengeHiragana();
        StartCoroutine(CountDown());
    }

    // displays a new random hiragana in challenge mode
    private void NextChallengeHiragana() 
    {
        challengeHiragana.text = "";
        bookmark = rand.Next(0, JapaneseDictionaries.HiraganaToEnglish.Count);
        challengeHiragana.text = JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Key;
    }

    /// <summary>
    /// yeah
    /// </summary>
    public void Submit() {
        string input = answer.text;
        input = input.Trim(' ', '*', '!', '@', '#', '$', '%', '^', '&');
        if (input.ToLower() == JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Value) 
        {
            SoundManager.instance.Play("Bloop 1");
            score += 1 + (10 - timeAdder) / 2;
            points.text = score.ToString("0.##");
            answer.text = "";
            answer.ActivateInputField();

            NextChallengeHiragana();
            StopAllCoroutines();
            StartCoroutine(CountDown());
        }
        else 
        {
            StopAllCoroutines();
            answer.gameObject.SetActive(false);
            challengeHiragana.text = "";

            // if a new highscore was achieved, UpdateHiraganaHighscore will return true
            if (SaveSystem.UpdateHiraganaHighscore(score)) 
            {
                SoundManager.instance.Play("Bloop 2");
                highScore.text = score.ToString("0.##");
                endText.text = "The Correct Answer Was: " + JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Value + 
                "\nNEW HIGH SCORE: " + score.ToString("0.##") + "!";
            }
            else 
            {
                SoundManager.instance.Play("Bloop 4");
                endText.text = "The Correct Answer Was: " + JapaneseDictionaries.HiraganaToEnglish.ElementAt(bookmark).Value + 
                "\nYour Score: " + score.ToString("0.##");
            }
            retryButton.gameObject.SetActive(true);
        }
    }

    // Simple countdown timer method. Once the timer reaches 0, it will
    // automatically call the Submit() method, forcing the answer 
    // validation to occur
    private IEnumerator CountDown() {
        float duration = 10f;
        float timeSpent = 0;
        while (timeSpent <= duration) {
            timeSpent += Time.deltaTime;
            timeAdder = timeSpent;
            timeLeft.text = (duration - timeSpent).ToString("0.##");
            yield return null;
        }
        Submit();
    }

    #endregion

    public void BackToMenu() {
        SoundManager.instance.Play("Bloop 1");
        menuPanel.gameObject.SetActive(true);
        hiraganaPanel.gameObject.SetActive(false);
        romajiPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(false);
    }

    public void BackToMain() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
