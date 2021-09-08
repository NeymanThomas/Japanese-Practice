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
    private int bookmark;
    private float score;
    private float timeAdder;
    private System.Random random;

    private void Awake() {
        menuPanel.gameObject.SetActive(true);
        hiraganaPanel.gameObject.SetActive(false);
        romanjiPanel.gameObject.SetActive(false);
        challengePanel.gameObject.SetActive(false);
    }

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

    #region romanji

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

    public void ShowRandomRomanjiMenu() {
        menuPanel.gameObject.SetActive(false);
        romanjiPanel.gameObject.SetActive(true);
        showHiraganaText.gameObject.SetActive(false);
        showHiraganaSecondaryText.gameObject.SetActive(false);

        ShuffleList();
        NextRomanji();
    }

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

    #region hiragana

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

    public void ShowRandomHiraganaMenu() {
        menuPanel.gameObject.SetActive(false);
        hiraganaPanel.gameObject.SetActive(true);
        showRomanjiText.gameObject.SetActive(false);
        showAltHiragana.gameObject.SetActive(false);

        ShuffleList();
        NextHiragana();
    }

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

    public void ShowRomanji() {
        SoundManager.instance.Play("Bloop 1");
        showRomanjiText.gameObject.SetActive(true);
        showRomanjiText.text = selectedhiragana;
    }

    #endregion

    #region challenge

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
