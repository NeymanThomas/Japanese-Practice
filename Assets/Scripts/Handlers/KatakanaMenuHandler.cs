/// <summary>
/// This class handles all uses of Katakana practice in the app.
/// Implemented functions:
///     -> user practices by seeing Katakana symbols
///     -> user practices by seeing random Katakana symbols
///     -> user practices by seeing romanji for Katakana
///     -> user practices by seeing random romanji for Katakana symbols
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

// TODO
// allow the application to interact with a JSON file that contains the
// list of the alphabet instead of creating the list inside of the class.
// ======================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class KatakanaMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject katakanaPanel;
    [SerializeField] private GameObject romanjiPanel;
    [SerializeField] private GameObject challengePanel;
    [SerializeField] private TMP_Text romanjiText;
    [SerializeField] private TMP_Text showKatakanaText;
    [SerializeField] private TMP_Text showKatakanaSecondaryText;
    [SerializeField] private TMP_Text katakanaText;
    [SerializeField] private TMP_Text showRomanjiText;
    [SerializeField] private TMP_Text showAltKatakana;
    [SerializeField] private TMP_InputField answer;
    [SerializeField] private TMP_Text points;
    [SerializeField] private TMP_Text highScore;
    [SerializeField] private TMP_Text challengeKatakana;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private TMP_Text timeLeft;
    private List<string> alphabet;
    private string selectedKatakana;
    private int bookmark; // The bookmark refers to the current position in the alphabet
    private float score;
    private float timeAdder;
    private System.Random random;

    // Make sure at Awake that the menuPanel is the only GameObject active
    private void Awake() {
        menuPanel.gameObject.SetActive(true);
        katakanaPanel.gameObject.SetActive(false);
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
        if (selectedKatakana == alphabet[rnd]) {
            SelectRandom();
            return;
        }
        bookmark = rnd;
        selectedKatakana = alphabet[rnd];
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
    // Katakana. The Font Asset being used has mappings that correspond
    // to the switch statement below. For example, if the selectedKatakana
    // is "sa", the font is mapped to "a" which corresponds to the symbol for "sa"
    public string RetrieveKatakana() {
        switch (selectedKatakana) {
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

    // BELOW SECTIONS OF CODE
    // For documentation on how the methods are being used, refer to the HiraganaMenuHandler
    // Class as the implement the same methods under different titles.
    #region romanji

    public void ShowRomanjiMenu() {
        menuPanel.gameObject.SetActive(false);
        romanjiPanel.gameObject.SetActive(true);
        showKatakanaText.gameObject.SetActive(false);
        showKatakanaSecondaryText.gameObject.SetActive(false);

        bookmark = 0;
        if (alphabet != null) {
            CreateList();
        }
        NextRomanji();
    }

    public void ShowRandomRomanjiMenu() {
        menuPanel.gameObject.SetActive(false);
        romanjiPanel.gameObject.SetActive(true);
        showKatakanaText.gameObject.SetActive(false);
        showKatakanaSecondaryText.gameObject.SetActive(false);

        ShuffleList();
        NextRomanji();
    }

    public void NextRomanji() {
        SoundManager.instance.Play("Bloop 1");
        showKatakanaText.gameObject.SetActive(false);
        showKatakanaSecondaryText.gameObject.SetActive(false);
        romanjiText.text = alphabet[bookmark];
        selectedKatakana = alphabet[bookmark];
        bookmark++;
        if (bookmark >= alphabet.Count) {
            bookmark = 0;
        }
    }

    public void ShowKatakana() {
        SoundManager.instance.Play("Bloop 1");
        showKatakanaText.gameObject.SetActive(true);
        showKatakanaText.text = RetrieveKatakana();
        if (showKatakanaText.text == "S") {
            showKatakanaSecondaryText.gameObject.SetActive(true);
            showKatakanaSecondaryText.text = "X";
        }
        if (showKatakanaText.text == "D") {
            showKatakanaSecondaryText.gameObject.SetActive(true);
            showKatakanaSecondaryText.text = "C";
        }
    }

    #endregion

    #region katakana

    public void ShowKatakanaMenu() {
        menuPanel.gameObject.SetActive(false);
        katakanaPanel.gameObject.SetActive(true);
        showRomanjiText.gameObject.SetActive(false);
        showAltKatakana.gameObject.SetActive(false);

        bookmark = 0;
        if (alphabet != null) {
            CreateList();
        }
        NextKatakana();
    }

    public void ShowRandomKatakanaMenu() {
        menuPanel.gameObject.SetActive(false);
        katakanaPanel.gameObject.SetActive(true);
        showRomanjiText.gameObject.SetActive(false);
        showAltKatakana.gameObject.SetActive(false);

        ShuffleList();
        NextKatakana();
    }

    public void NextKatakana() {
        SoundManager.instance.Play("Bloop 1");
        showRomanjiText.gameObject.SetActive(false);
        showAltKatakana.gameObject.SetActive(false);
        selectedKatakana = alphabet[bookmark];
        katakanaText.text = RetrieveKatakana();

        if (alphabet[bookmark] == "Ji") {
            showAltKatakana.gameObject.SetActive(true);
            showAltKatakana.text = "X";
        }
        if (alphabet[bookmark] == "Zu") {
            showAltKatakana.gameObject.SetActive(true);
            showAltKatakana.text = "C";
        }

        bookmark++;
        if (bookmark >= alphabet.Count) {
            bookmark = 0;
        }
    }

    public void ShowRomanji() {
        SoundManager.instance.Play("Bloop 1");
        showRomanjiText.gameObject.SetActive(true);
        showRomanjiText.text = selectedKatakana;
    }

    #endregion

    #region challenge

    /*
    public void ShowChallengeMenu() {
        menuPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(true);
        endText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        if (SaveSystem.K_Score_Exists()) {
            highScore.text = SaveSystem.Load_K_Score().ToString("0.##");
        }
        points.text = "0";
        score = 0;
        answer.gameObject.SetActive(true);
        answer.ActivateInputField();

        SelectRandom();
        StartCoroutine(CountDown());
        challengeKatakana.text = RetrieveKatakana();
    }

    public void Submit() {
        string input = answer.text;
        input = input.Trim(' ', '*');
        if (input.ToLower() == alphabet[bookmark].ToLower()) {
            SoundManager.instance.Play("Bloop 1");
            score += 1 + (10 - timeAdder) / 2;
            points.text = score.ToString("0.##");
            answer.text = "";
            answer.ActivateInputField();

            SelectRandom();
            StopAllCoroutines();
            StartCoroutine(CountDown());
            challengeKatakana.text = RetrieveKatakana();

            if (RetrieveKatakana() == "S") {
                int x = random.Next(0,2);
                if (x == 0) {
                    challengeKatakana.text = "S";
                }
                else {
                    challengeKatakana.text = "X";
                }
            }

            if (RetrieveKatakana() == "D") {
                int x = random.Next(0,2);
                if (x == 0) {
                    challengeKatakana.text = "D";
                }
                else {
                    challengeKatakana.text = "C";
                }
            }
        }
        else {
            StopAllCoroutines();
            if (RetrieveKatakana() == "S") {
                SaveSystem.Save_Katakana("Ji_1");
            }
            else if (RetrieveKatakana() == "D") {
                SaveSystem.Save_Katakana("Zu_1");
            }
            else if (RetrieveKatakana() == "X") {
                SaveSystem.Save_Katakana("Ji_2");
            }
            else if (RetrieveKatakana() == "C") {
                SaveSystem.Save_Katakana("Zu_2");
            }
            else {
                SaveSystem.Save_Katakana(alphabet[bookmark]);
            }

            answer.gameObject.SetActive(false);
            challengeKatakana.text = "";
            endText.gameObject.SetActive(true);
            endText.text = "The Correct Answer Was: " + alphabet[bookmark] + "\nYour Score: " + score.ToString("0.##");
            retryButton.gameObject.SetActive(true);

            if (SaveSystem.K_Score_Exists()) {
                if (score > SaveSystem.Load_K_Score()) {
                    SoundManager.instance.Play("Bloop 2");
                    SaveSystem.Save_K_Score(score);
                    highScore.text = score.ToString("0.##");
                    endText.text = "The Correct Answer Was: " + alphabet[bookmark] + "\nNEW HIGH SCORE: " + score.ToString("0.##") + "!";
                }
                else {
                    SoundManager.instance.Play("Bloop 4");
                }
            }
            else if (score > 0) {
                SoundManager.instance.Play("Bloop 2");
                SaveSystem.Save_K_Score(score);
                highScore.text = score.ToString("0.##");
                endText.text = "The Correct Answer Was: " + alphabet[bookmark] + "\nNEW HIGH SCORE: " + score.ToString("0.##") + "!";
            }
        }
        answer.ActivateInputField();
    }

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
    */

    #endregion

    public void BackToMenu() {
        SoundManager.instance.Play("Bloop 1");
        menuPanel.gameObject.SetActive(true);
        katakanaPanel.gameObject.SetActive(false);
        romanjiPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(false);
    }

    public void BackToMain() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
