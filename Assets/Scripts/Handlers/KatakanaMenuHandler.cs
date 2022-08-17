/// <summary>
/// This class handles all uses of Katakana practice in the app.
/// Implemented functions:
///     -> user practices by seeing Katakana symbols
///     -> user practices by seeing random Katakana symbols
///     -> user practices by seeing romaji for Katakana
///     -> user practices by seeing random romaji for Katakana symbols
///     -> the user can challenge themselves with a timer to correctly 
///     guess random Katakana symbols and receive a score
///     -> the user can go back to the main menu
/// 
/// The handler functions by enabling and disabling various Panels in the
/// scene. the default 'menuPanel' is enabled on Awake of the scene and all
/// other Panels are disabled. Upon selecting an option for practice, a
/// corresponding panel will be enabled while the previous panel is disabled.
/// For example, selecting 'Practice Katakana' will disable the 'menuPanel'
/// and enable the  KatakanaPanel'. This hides the menu from view and only
/// shows the user the panel for practicing Katakana.
/// 
/// In order to be interacted with, the UI elements must be serialized and
/// listed inside of the KatakanaMenuHandler Class.
/// </summary>

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class KatakanaMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject katakanaPanel;
    [SerializeField] private GameObject romajiPanel;
    [SerializeField] private GameObject challengePanel;
    [SerializeField] private GameObject NextKatakanaButton;
    [SerializeField] private GameObject NextRandomKatakanaButton;
    [SerializeField] private GameObject NextRomajiButton;
    [SerializeField] private GameObject NextRandomRomajiButton;
    [SerializeField] private TMP_Text romajiText;
    [SerializeField] private TMP_Text showKatakanaText;
    [SerializeField] private TMP_Text showKatakanaSecondaryText;
    [SerializeField] private TMP_Text katakanaText;
    [SerializeField] private TMP_Text showRomajiText;
    [SerializeField] private TMP_InputField answer;
    [SerializeField] private TMP_Text points;
    [SerializeField] private TMP_Text highScore;
    [SerializeField] private TMP_Text challengeKatakana;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private TMP_Text timeLeft;

    private int bookmark; // The bookmark refers to the current position in the dictionary
    private float score;
    private float timeAdder;
    private System.Random rand;

    // Make sure at Awake that the menuPanel is the only GameObject active
    private void Awake() {
        menuPanel.gameObject.SetActive(true);
        katakanaPanel.gameObject.SetActive(false);
        romajiPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(false);
    }

    // Initialize the objects and other values
    private void Start() {
        rand = new System.Random();
        bookmark = 0;
        Timer.instance.StartTimer();
    }

    #region Button Methods

    // Enables the romaji menu and begins ordered practice
    public void RomajiClicked() 
    {
        menuPanel.gameObject.SetActive(false);
        romajiPanel.gameObject.SetActive(true);
        NextRomajiButton.SetActive(true);
        NextRandomRomajiButton.SetActive(false);
        bookmark = -1;
        NextRomaji();
    }

    // Enables the romaji menu and begins random practice
    public void RandomRomajiClicked() 
    {
        menuPanel.gameObject.SetActive(false);
        romajiPanel.gameObject.SetActive(true);
        NextRomajiButton.SetActive(false);
        NextRandomRomajiButton.SetActive(true);
        NextRandomRomaji();
    }

    // Enables the katakana menu and begins ordered practice
    public void KatakanaClicked() 
    {
        menuPanel.gameObject.SetActive(false);
        katakanaPanel.gameObject.SetActive(true);
        NextKatakanaButton.SetActive(true);
        NextRandomKatakanaButton.SetActive(false);
        bookmark = -1;
        NextKatakana();
    }

    // Enables the katakana menu and begins random practice
    public void RandomKatakanaClicked() 
    {
        menuPanel.gameObject.SetActive(false);
        katakanaPanel.gameObject.SetActive(true);
        NextKatakanaButton.SetActive(false);
        NextRandomKatakanaButton.SetActive(true);
        NextRandomKatakana();
    }

    // displays the next romaji in the sequence
    public void NextRomaji() 
    {
        SoundManager.instance.Play("Bloop 1");
        bookmark++;
        if (bookmark >= JapaneseDictionaries.KatakanaToEnglish.Count) 
        {
            bookmark = 0;
        }
        showKatakanaText.text = "";
        showKatakanaSecondaryText.text = "";
        romajiText.text = JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Value;
    }

    // displays the next random romaji in the sequence
    public void NextRandomRomaji() 
    {
        SoundManager.instance.Play("Bloop 1");
        showKatakanaText.text = "";
        showKatakanaSecondaryText.text = "";
        // this loop is to ensure that characters are not repeated
        int oldBookmark = bookmark;
        while (oldBookmark == bookmark) 
        {
            bookmark = rand.Next(0, JapaneseDictionaries.KatakanaToEnglish.Count);
        }
        romajiText.text = JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Value;
    }

    // displays the next katakana in the sequence
    public void NextKatakana() 
    {
        SoundManager.instance.Play("Bloop 1");
        bookmark++;
        if (bookmark >= JapaneseDictionaries.KatakanaToEnglish.Count) 
        {
            bookmark = 0;
        }
        showRomajiText.text = "";
        katakanaText.text = JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Key;
    }

    // displays the next random katakana in the sequence
    public void NextRandomKatakana() 
    {
        SoundManager.instance.Play("Bloop 1");
        showRomajiText.text = "";
        // this loop is to ensure that characters are not repeated
        int oldBookmark = bookmark;
        while (oldBookmark == bookmark) 
        {
            bookmark = rand.Next(0, JapaneseDictionaries.KatakanaToEnglish.Count);
        }
        katakanaText.text = JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Key;
    }

    // Method to show the Katakana of the associated romaji being pointed to by the bookmark
    public void ShowKatakana() 
    {
        SoundManager.instance.Play("Bloop 1");
        showKatakanaText.text = JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Key;
        // Have to check for the katakana characters that have the same pronunciation
        if (bookmark == 52)
            showKatakanaSecondaryText.text = "ヂ";
        if (bookmark == 53)
            showKatakanaSecondaryText.text = "ジ";
        if (bookmark == 54)
            showKatakanaSecondaryText.text = "ヅ";
        if (bookmark == 55)
            showKatakanaSecondaryText.text = "ズ";
    }

    // Method to show the Romaji of the associated katakana being pointed to by the bookmark
    public void ShowRomaji() {
        SoundManager.instance.Play("Bloop 1");
        showRomajiText.text = JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Value;
    }

    #endregion

    #region Challenge Mode

    // Initalizes the panel for the challenge mode. If a high score exists, display it. 
    public void ShowChallengeMenu() {
        SoundManager.instance.Play("Bloop 1");
        menuPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(true);
        answer.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        highScore.text = SaveSystem.LoadKatakanaScore().ToString("0.##");
        endText.text = "";
        points.text = "0";
        score = 0;
        answer.ActivateInputField();
        NextChallengeKatakana();
        StartCoroutine(CountDown());
    }

    // displays a new random hiragana in challenge mode
    private void NextChallengeKatakana() 
    {
        challengeKatakana.text = "";
        // this loop is to ensure that characters are not repeated
        int oldBookmark = bookmark;
        while (oldBookmark == bookmark) 
        {
            bookmark = rand.Next(0, JapaneseDictionaries.KatakanaToEnglish.Count);
        }
        challengeKatakana.text = JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Key;
    }

    // takes the string the user input and lightly sanitizes it, then compares
    // the result to the value at the bookmark in the dictionary. If it is correct,
    // the challenge continues, a new katakana character is displayed, the timer is
    // reset, and the score is added to. If the answer was incorrect, the mistake 
    // is recorded by the SaveSystem and it is then determined if the current score
    // is a new highscore or not.
    public void Submit() {
        string input = answer.text;
        input = input.Trim(' ', '*', '!', '@', '#', '$', '%', '^', '&');
        if (input.ToLower() == JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Value) 
        {
            SoundManager.instance.Play("Bloop 1");
            score += 1 + (10 - timeAdder) / 2;
            points.text = score.ToString("0.##");
            answer.text = "";
            answer.ActivateInputField();

            NextChallengeKatakana();
            StopAllCoroutines();
            StartCoroutine(CountDown());
        }
        else 
        {
            StopAllCoroutines();
            answer.gameObject.SetActive(false);
            challengeKatakana.text = "";
            // update the value for the missed katakana
            SaveSystem.UpdateKatakanaStats(bookmark);

            // if a new highscore was achieved, UpdateKatakanaHighscore will return true
            if (SaveSystem.UpdateKatakanaHighscore(score)) 
            {
                SoundManager.instance.Play("Bloop 2");
                highScore.text = score.ToString("0.##");
                endText.text = "The Correct Answer Was: " + JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Value + 
                "\nNEW HIGH SCORE: " + score.ToString("0.##") + "!";
            }
            else 
            {
                SoundManager.instance.Play("Bloop 4");
                endText.text = "The Correct Answer Was: " + JapaneseDictionaries.KatakanaToEnglish.ElementAt(bookmark).Value + 
                "\nYour Score: " + score.ToString("0.##");
            }
            retryButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
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
        katakanaPanel.gameObject.SetActive(false);
        romajiPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(false);
    }

    public void BackToMain() {
        SoundManager.instance.Play("Bloop 1");
        Timer.instance.AddTimePassed();
        SceneManager.LoadScene("MainMenu");
    }
}
