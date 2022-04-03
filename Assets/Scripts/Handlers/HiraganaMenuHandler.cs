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

// TODO
// allow the application to interact with a JSON file that contains the
// list of the alphabet instead of creating the list inside of the class.
// ======================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class HiraganaMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject hiraganaPanel;
    [SerializeField] private GameObject romanjiPanel;
    [SerializeField] private GameObject challengePanel;
    [SerializeField] private TMP_Text romanjiText;
    [SerializeField] private TMP_Text showHiraganaText;
    [SerializeField] private TMP_Text showHiraganaSecondaryText;
    [SerializeField] private TMP_Text hiraganaText;
    [SerializeField] private TMP_Text showRomanjiText;
    [SerializeField] private TMP_Text showAltHiragana;
    [SerializeField] private TMP_InputField answer;
    [SerializeField] private TMP_Text points;
    [SerializeField] private TMP_Text highScore;
    [SerializeField] private TMP_Text challengeHiragana;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private TMP_Text timeLeft;

    private List<string> alphabet;
    private string selectedhiragana;
    private int bookmark; // The bookmark refers to the current position in the alphabet
    private float score;
    private float timeAdder;
    private System.Random random;

    // Make sure at Awake that the menuPanel is the only GameObject active
    private void Awake() {
        menuPanel.gameObject.SetActive(true);
        hiraganaPanel.gameObject.SetActive(false);
        romanjiPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(false);
    }

    // Initialize the objects and other values
    private void Start() {
        CreateList();
        random = new System.Random();
        bookmark = 0;
    }

    private void CreateList() {
        alphabet = new List<string>();

        alphabet.Add("A");
        alphabet.Add("I");
        alphabet.Add("U");
        alphabet.Add("E");
        alphabet.Add("O");
        alphabet.Add("Ka");
        alphabet.Add("Ki");
        alphabet.Add("Ku");
        alphabet.Add("Ke");
        alphabet.Add("Ko");
        alphabet.Add("Sa");
        alphabet.Add("Shi");
        alphabet.Add("Su");
        alphabet.Add("Se");
        alphabet.Add("So");
        alphabet.Add("Ta");
        alphabet.Add("Chi");
        alphabet.Add("Tsu");
        alphabet.Add("Te");
        alphabet.Add("To");
        alphabet.Add("Na");
        alphabet.Add("Ni");
        alphabet.Add("Nu");
        alphabet.Add("Ne");
        alphabet.Add("No");
        alphabet.Add("Ha");
        alphabet.Add("Hi");
        alphabet.Add("Fu");
        alphabet.Add("He");
        alphabet.Add("Ho");
        alphabet.Add("Ma");
        alphabet.Add("Mi");
        alphabet.Add("Mu");
        alphabet.Add("Me");
        alphabet.Add("Mo");
        alphabet.Add("Ya");
        alphabet.Add("Yu");
        alphabet.Add("Yo");
        alphabet.Add("Ra");
        alphabet.Add("Ri");
        alphabet.Add("Ru");
        alphabet.Add("Re");
        alphabet.Add("Ro");
        alphabet.Add("Wa");
        alphabet.Add("Wo");
        alphabet.Add("N");

        alphabet.Add("Ga");
        alphabet.Add("Gi");
        alphabet.Add("Gu");
        alphabet.Add("Ge");
        alphabet.Add("Go");
        alphabet.Add("Za");
        alphabet.Add("Ji");
        alphabet.Add("Zu");
        alphabet.Add("Ze");
        alphabet.Add("Zo");
        alphabet.Add("Da");
        alphabet.Add("De");
        alphabet.Add("Do");
        alphabet.Add("Ba");
        alphabet.Add("Bi");
        alphabet.Add("Bu");
        alphabet.Add("Be");
        alphabet.Add("Bo");
        alphabet.Add("Pa");
        alphabet.Add("Pi");
        alphabet.Add("Pu");
        alphabet.Add("Pe");
        alphabet.Add("Po");
    }

    private void SelectRandom() {
        int rnd = random.Next(0, alphabet.Count);
        if (selectedhiragana == alphabet[rnd]) {
            SelectRandom();
            return;
        }
        bookmark = rnd;
        selectedhiragana = alphabet[rnd];
    }

    // A simple fucntion that takes the list and shuffles its contents
    private void ShuffleList() {
        int n = alphabet.Count;
        while (n > 1) {
            n--;
            int k = random.Next(n + 1);
            string symbol = alphabet[k];
            alphabet[k] = alphabet[n];
            alphabet[n] = symbol;
        }
    }

    // This function takes in the pheonetic sound from the alphabet
    // and associates it with the correct symbol from the list of
    // Hiragana. The Font Asset being used has mappings that correspond
    // to the switch statement below. For example, if the selectedhiragana
    // is "sa", the font is mapped to "a" which corresponds to the symbol for "sa"
    public string RetrieveHiragana() {
        switch (selectedhiragana) {
            case "A":
                return "1";
            case "I":
                return "2";
            case "U":
                return "3";
            case "E":
                return "4";
            case "O":
                return "5";
            case "Ka":
                return "q";
            case "Ki":
                return "w";
            case "Ku":
                return "e";
            case "Ke":
                return "r";
            case "Ko":
                return "t";
            case "Sa":
                return "a";
            case "Shi":
                return "s";
            case "Su":
                return "d";
            case "Se":
                return "f";
            case "So":
                return "g";
            case "Ta":
                return "z";
            case "Chi":
                return "x";
            case "Tsu":
                return "c";
            case "Te":
                return "v";
            case "To":
                return "b";
            case "Na":
                return "6";
            case "Ni":
                return "7";
            case "Nu":
                return "8";
            case "Ne":
                return "9";
            case "No":
                return "0";
            case "Ha":
                return "y";
            case "Hi":
                return "u";
            case "Fu":
                return "i";
            case "He":
                return "o";
            case "Ho":
                return "p";
            case "Ma":
                return "h";
            case "Mi":
                return "j";
            case "Mu":
                return "k";
            case "Me":
                return "l";
            case "Mo":
                return ";";
            case "Ya":
                return ",";
            case "Yu":
                return ".";
            case "Yo":
                return "/";
            case "Ra":
                return "-";
            case "Ri":
                return "=";
            case "Ru":
                return "[";
            case "Re":
                return "]";
            case "Ro":
                return "\\";
            case "Wa":
                return "'";
            case "Wo":
                return "n";
            case "N":
                return "m";
            case "Ga":
                return "!";
            case "Gi":
                return "@";
            case "Gu":
                return "#";
            case "Ge":
                return "$";
            case "Go":
                return "%";
            case "Za":
                return "A";
            case "Ji":
                return "S";
            case "Zu":
                return "D";
            case "Ze":
                return "F";
            case "Zo":
                return "G";
            case "Da":
                return "Z";
            case "De":
                return "V";
            case "Do":
                return "B";
            case "Ba":
                return "^";
            case "Bi":
                return "&";
            case "Bu":
                return "*";
            case "Be":
                return "(";
            case "Bo":
                return ")";
            case "Pa":
                return "H";
            case "Pi":
                return "J";
            case "Pu":
                return "K";
            case "Pe":
                return "L";
            case "Po":
                return ":";
            default: return "O";
        }
    }

    // Region for all of the romanji based functions
    #region romanji

    // Function for practicing romanji in alphabetical order
    // the bookmark is set to 0 as it is the first index in the list
    public void ShowRomanjiMenu() {
        menuPanel.gameObject.SetActive(false);
        romanjiPanel.gameObject.SetActive(true);
        showHiraganaText.gameObject.SetActive(false);
        showHiraganaSecondaryText.gameObject.SetActive(false);

        bookmark = 0;
        if (alphabet != null) {
            CreateList();
        }
        NextRomanji();
    }

    // Function for practicing romanji in random order
    // the bookmark does not need to be set because the list is randomized
    public void ShowRandomRomanjiMenu() {
        menuPanel.gameObject.SetActive(false);
        romanjiPanel.gameObject.SetActive(true);
        showHiraganaText.gameObject.SetActive(false);
        showHiraganaSecondaryText.gameObject.SetActive(false);

        ShuffleList();
        NextRomanji();
    }

    // Method for showing the romanji for what the bookmark is currently 
    // pointing to. It then increments the bookmark to point to the next
    // symbol in the list. Each time a new romanji is retrieved, the
    // showHiraganaText and showHiraganaSecondaryText objects must be
    // disabled so that if the user revealed what the answer was, the next
    // answer will not also be revealed.
    public void NextRomanji() {
        SoundManager.instance.Play("Bloop 1");
        showHiraganaText.gameObject.SetActive(false);
        showHiraganaSecondaryText.gameObject.SetActive(false);
        romanjiText.text = alphabet[bookmark];
        selectedhiragana = alphabet[bookmark];
        bookmark++;
        if (bookmark >= alphabet.Count) {
            bookmark = 0;
        }
    }

    // Method to show the Hiragana of the associated romanji being pointed
    // to by the bookmark. Because Japanese language has some sounds that
    // can apply to 2 symbols, we must add a case to check if the text
    // is displaying one of these symbols. If it is, we must also display
    // the alternative symbol for the associated sound.
    public void ShowHiragana() {
        SoundManager.instance.Play("Bloop 1");
        showHiraganaText.gameObject.SetActive(true);
        showHiraganaText.text = RetrieveHiragana();
        if (showHiraganaText.text == "S") {
            showHiraganaSecondaryText.gameObject.SetActive(true);
            showHiraganaSecondaryText.text = "X";
        }
        if (showHiraganaText.text == "D") {
            showHiraganaSecondaryText.gameObject.SetActive(true);
            showHiraganaSecondaryText.text = "C";
        }
    }

    #endregion

    // Region for all the Hiragana based functions
    #region hiragana

    // Function for practicing Hiragana in alphabetical order
    // the bookmark is set to 0 as it is the first index in the list
    public void ShowHiraganaMenu() {
        menuPanel.gameObject.SetActive(false);
        hiraganaPanel.gameObject.SetActive(true);
        showRomanjiText.gameObject.SetActive(false);
        showAltHiragana.gameObject.SetActive(false);

        bookmark = 0;
        if (alphabet != null) {
            CreateList();
        }
        NextHiragana();
    }

    // Function for practicing Hiragana in random order
    // the bookmark does not need to be set because the list is randomized
    public void ShowRandomHiraganaMenu() {
        menuPanel.gameObject.SetActive(false);
        hiraganaPanel.gameObject.SetActive(true);
        showRomanjiText.gameObject.SetActive(false);
        showAltHiragana.gameObject.SetActive(false);

        ShuffleList();
        NextHiragana();
    }

    // Method for showing the Hiragana for what the bookmark is currently 
    // pointing to. It then increments the bookmark to point to the next
    // symbol in the list. Each time a new hiragana is retrieved, the
    // showRomanjiText and showAltHiragana objects must be
    // disabled so that if the user revealed what the answer was, the next
    // answer will not also be revealed.
    public void NextHiragana() {
        SoundManager.instance.Play("Bloop 1");
        showRomanjiText.gameObject.SetActive(false);
        showAltHiragana.gameObject.SetActive(false);
        selectedhiragana = alphabet[bookmark];
        hiraganaText.text = RetrieveHiragana();

        if (alphabet[bookmark] == "Ji") {
            showAltHiragana.gameObject.SetActive(true);
            showAltHiragana.text = "X";
        }
        if (alphabet[bookmark] == "Zu") {
            showAltHiragana.gameObject.SetActive(true);
            showAltHiragana.text = "C";
        }

        bookmark++;
        if (bookmark >= alphabet.Count) {
            bookmark = 0;
        }
    }

    // Method to show the Romanji of the associated Hiragana being pointed
    // to by the bookmark
    public void ShowRomanji() {
        SoundManager.instance.Play("Bloop 1");
        showRomanjiText.gameObject.SetActive(true);
        showRomanjiText.text = selectedhiragana;
    }

    #endregion

    // Region to handle all of the functions for the challenge mode
    #region challenge

    // Initalizes the panel for the challenge mode. If a high score exists,
    // display it. 
    public void ShowChallengeMenu() {
        menuPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(true);
        endText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        if (SaveSystem.H_Score_Exists()) {
            highScore.text = SaveSystem.Load_H_Score().ToString("0.##");
        }
        points.text = "0";
        score = 0;
        answer.gameObject.SetActive(true);
        answer.ActivateInputField();

        SelectRandom();
        StartCoroutine(CountDown());
        challengeHiragana.text = RetrieveHiragana();
    }

    // Method that accepts input from the user to process their answer. Light 
    // sanitation is used to trim unwanted characters and change all characters
    // to lower case. 
    //
    // If the input matches what the bookmark is pointing to, 
    // the score is incremented, the answer field is whiped, and the focus is
    // put back into the input field so the user does not have to select it over
    // and over again. The coroutine for the timer is restarted and a new hiragana
    // is retrieved.
    //
    // Otherwise if the answer is wrong or the timer runs down to 0, the save system
    // will record which Hiragana failed you as well as your score. If your score is
    // higher than your last saved high score, it will be overwritten. The method then
    // shows the user the correct answer and prompts them if they want to play again.
    public void Submit() {
        string input = answer.text;
        input = input.Trim(' ', '*', '!', '@', '#', '$', '%', '^', '&');
        if (input.ToLower() == alphabet[bookmark].ToLower()) {
            SoundManager.instance.Play("Bloop 1");
            score += 1 + (10 - timeAdder) / 2;
            points.text = score.ToString("0.##");
            answer.text = "";
            answer.ActivateInputField();

            SelectRandom();
            StopAllCoroutines();
            StartCoroutine(CountDown());
            challengeHiragana.text = RetrieveHiragana();

            if (RetrieveHiragana() == "S") {
                int x = random.Next(0,2);
                if (x == 0) {
                    challengeHiragana.text = "S";
                }
                else {
                    challengeHiragana.text = "X";
                }
            }

            if (RetrieveHiragana() == "D") {
                int x = random.Next(0,2);
                if (x == 0) {
                    challengeHiragana.text = "D";
                }
                else {
                    challengeHiragana.text = "C";
                }
            }
        }
        else {
            StopAllCoroutines();
            if (RetrieveHiragana() == "S") {
                SaveSystem.Save_Hiragana("Ji_1");
            }
            else if (RetrieveHiragana() == "D") {
                SaveSystem.Save_Hiragana("Zu_1");
            }
            else if (RetrieveHiragana() == "X") {
                SaveSystem.Save_Hiragana("Ji_2");
            }
            else if (RetrieveHiragana() == "C") {
                SaveSystem.Save_Hiragana("Zu_2");
            }
            else {
                SaveSystem.Save_Hiragana(alphabet[bookmark]);
            }

            answer.gameObject.SetActive(false);
            challengeHiragana.text = "";
            endText.gameObject.SetActive(true);
            endText.text = "The Correct Answer Was: " + alphabet[bookmark] + "\nYour Score: " + score.ToString("0.##");
            retryButton.gameObject.SetActive(true);

            if (SaveSystem.H_Score_Exists()) {
                if (score > SaveSystem.Load_H_Score()) {
                    SoundManager.instance.Play("Bloop 2");
                    SaveSystem.Save_H_Score(score);
                    highScore.text = score.ToString("0.##");
                    endText.text = "The Correct Answer Was: " + alphabet[bookmark] + "\nNEW HIGH SCORE: " + score.ToString("0.##") + "!";
                }
                else {
                    SoundManager.instance.Play("Bloop 4");
                }
            }
            else if (score > 0) {
                SoundManager.instance.Play("Bloop 2");
                SaveSystem.Save_H_Score(score);
                highScore.text = score.ToString("0.##");
                endText.text = "The Correct Answer Was: " + alphabet[bookmark] + "\nNEW HIGH SCORE: " + score.ToString("0.##") + "!";
            }
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
        romanjiPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(false);
    }

    public void BackToMain() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
