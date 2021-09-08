using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StatsMenuHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text h_scoreBlock_1, h_scoreBlock_2, h_scoreBlock_3, h_scoreBlock_4, h_scoreBlock_5, h_scoreBlock_6, h_scoreBlock_7;
    [SerializeField] 
    private TMP_Text k_scoreBlock_1, k_scoreBlock_2, k_scoreBlock_3, k_scoreBlock_4, k_scoreBlock_5, k_scoreBlock_6, k_scoreBlock_7;
    [SerializeField]
    private GameObject hiraganaPanel, katakanaPanel;
    StatisticalData stats;
    private void Start() {
        hiraganaPanel.gameObject.SetActive(true);
        katakanaPanel.gameObject.SetActive(false);
        if (SaveSystem.Stats_Exist()) {
            stats = SaveSystem.Load_Stats();
            UpdateHiraganaScores();
        }
    }

    public void UpdateHiraganaScores() {
        h_scoreBlock_1.text = stats.h_A.ToString();
        h_scoreBlock_1.text += "\n" + stats.h_I.ToString();
        h_scoreBlock_1.text += "\n" + stats.h_U.ToString();
        h_scoreBlock_1.text += "\n" + stats.h_E.ToString();
        h_scoreBlock_1.text += "\n" + stats.h_O.ToString();
        h_scoreBlock_1.text += "\n" + stats.h_Ka.ToString();
        h_scoreBlock_1.text += "\n" + stats.h_Ki.ToString();
        h_scoreBlock_1.text += "\n" + stats.h_Ku.ToString();
        h_scoreBlock_1.text += "\n" + stats.h_Ke.ToString();
        h_scoreBlock_1.text += "\n" + stats.h_Ko.ToString();

        h_scoreBlock_2.text = stats.h_Sa.ToString();
        h_scoreBlock_2.text += "\n" + stats.h_Shi.ToString();
        h_scoreBlock_2.text += "\n" + stats.h_Su.ToString();
        h_scoreBlock_2.text += "\n" + stats.h_Se.ToString();
        h_scoreBlock_2.text += "\n" + stats.h_So.ToString();
        h_scoreBlock_2.text += "\n" + stats.h_Ta.ToString();
        h_scoreBlock_2.text += "\n" + stats.h_Chi.ToString();
        h_scoreBlock_2.text += "\n" + stats.h_Tsu.ToString();
        h_scoreBlock_2.text += "\n" + stats.h_Te.ToString();
        h_scoreBlock_2.text += "\n" + stats.h_To.ToString();

        h_scoreBlock_3.text = stats.h_Na.ToString();
        h_scoreBlock_3.text += "\n" + stats.h_Ni.ToString();
        h_scoreBlock_3.text += "\n" + stats.h_Nu.ToString();
        h_scoreBlock_3.text += "\n" + stats.h_Ne.ToString();
        h_scoreBlock_3.text += "\n" + stats.h_No.ToString();
        h_scoreBlock_3.text += "\n" + stats.h_Ha.ToString();
        h_scoreBlock_3.text += "\n" + stats.h_Hi.ToString();
        h_scoreBlock_3.text += "\n" + stats.h_Fu.ToString();
        h_scoreBlock_3.text += "\n" + stats.h_He.ToString();
        h_scoreBlock_3.text += "\n" + stats.h_Ho.ToString();

        h_scoreBlock_4.text = stats.h_Ma.ToString();
        h_scoreBlock_4.text += "\n" + stats.h_Mi.ToString();
        h_scoreBlock_4.text += "\n" + stats.h_Mu.ToString();
        h_scoreBlock_4.text += "\n" + stats.h_Me.ToString();
        h_scoreBlock_4.text += "\n" + stats.h_Mo.ToString();
        h_scoreBlock_4.text += "\n" + stats.h_Ya.ToString();
        h_scoreBlock_4.text += "\n" + stats.h_Yu.ToString();
        h_scoreBlock_4.text += "\n" + stats.h_Yo.ToString();
        h_scoreBlock_4.text += "\n" + stats.h_Wa.ToString();
        h_scoreBlock_4.text += "\n" + stats.h_Wo.ToString();

        h_scoreBlock_5.text = stats.h_Ra.ToString();
        h_scoreBlock_5.text += "\n" + stats.h_Ri.ToString();
        h_scoreBlock_5.text += "\n" + stats.h_Ru.ToString();
        h_scoreBlock_5.text += "\n" + stats.h_Re.ToString();
        h_scoreBlock_5.text += "\n" + stats.h_Ro.ToString();
        h_scoreBlock_5.text += "\n" + stats.h_N.ToString();
        h_scoreBlock_5.text += "\n" + stats.h_Ga.ToString();
        h_scoreBlock_5.text += "\n" + stats.h_Gi.ToString();
        h_scoreBlock_5.text += "\n" + stats.h_Gu.ToString();
        h_scoreBlock_5.text += "\n" + stats.h_Ge.ToString();

        h_scoreBlock_6.text = stats.h_Go.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_Za.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_Ji_1.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_Zu_1.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_Ze.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_Zo.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_Da.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_Ji_2.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_Zu_2.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_De.ToString();
        h_scoreBlock_6.text += "\n" + stats.h_Do.ToString();

        h_scoreBlock_7.text = stats.h_Ba.ToString();
        h_scoreBlock_7.text += "\n" + stats.h_Bi.ToString();
        h_scoreBlock_7.text += "\n" + stats.h_Bu.ToString();
        h_scoreBlock_7.text += "\n" + stats.h_Be.ToString();
        h_scoreBlock_7.text += "\n" + stats.h_Bo.ToString();
        h_scoreBlock_7.text += "\n" + stats.h_Pa.ToString();
        h_scoreBlock_7.text += "\n" + stats.h_Pi.ToString();
        h_scoreBlock_7.text += "\n" + stats.h_Pu.ToString();
        h_scoreBlock_7.text += "\n" + stats.h_Pe.ToString();
        h_scoreBlock_7.text += "\n" + stats.h_Po.ToString();
    }

    public void UpdateKatakanaScores() {
        k_scoreBlock_1.text = stats.k_A.ToString();
        k_scoreBlock_1.text += "\n" + stats.k_I.ToString();
        k_scoreBlock_1.text += "\n" + stats.k_U.ToString();
        k_scoreBlock_1.text += "\n" + stats.k_E.ToString();
        k_scoreBlock_1.text += "\n" + stats.k_O.ToString();
        k_scoreBlock_1.text += "\n" + stats.k_Ka.ToString();
        k_scoreBlock_1.text += "\n" + stats.k_Ki.ToString();
        k_scoreBlock_1.text += "\n" + stats.k_Ku.ToString();
        k_scoreBlock_1.text += "\n" + stats.k_Ke.ToString();
        k_scoreBlock_1.text += "\n" + stats.k_Ko.ToString();

        k_scoreBlock_2.text = stats.k_Sa.ToString();
        k_scoreBlock_2.text += "\n" + stats.k_Shi.ToString();
        k_scoreBlock_2.text += "\n" + stats.k_Su.ToString();
        k_scoreBlock_2.text += "\n" + stats.k_Se.ToString();
        k_scoreBlock_2.text += "\n" + stats.k_So.ToString();
        k_scoreBlock_2.text += "\n" + stats.k_Ta.ToString();
        k_scoreBlock_2.text += "\n" + stats.k_Chi.ToString();
        k_scoreBlock_2.text += "\n" + stats.k_Tsu.ToString();
        k_scoreBlock_2.text += "\n" + stats.k_Te.ToString();
        k_scoreBlock_2.text += "\n" + stats.k_To.ToString();

        k_scoreBlock_3.text = stats.k_Na.ToString();
        k_scoreBlock_3.text += "\n" + stats.k_Ni.ToString();
        k_scoreBlock_3.text += "\n" + stats.k_Nu.ToString();
        k_scoreBlock_3.text += "\n" + stats.k_Ne.ToString();
        k_scoreBlock_3.text += "\n" + stats.k_No.ToString();
        k_scoreBlock_3.text += "\n" + stats.k_Ha.ToString();
        k_scoreBlock_3.text += "\n" + stats.k_Hi.ToString();
        k_scoreBlock_3.text += "\n" + stats.k_Fu.ToString();
        k_scoreBlock_3.text += "\n" + stats.k_He.ToString();
        k_scoreBlock_3.text += "\n" + stats.k_Ho.ToString();

        k_scoreBlock_4.text = stats.k_Ma.ToString();
        k_scoreBlock_4.text += "\n" + stats.k_Mi.ToString();
        k_scoreBlock_4.text += "\n" + stats.k_Mu.ToString();
        k_scoreBlock_4.text += "\n" + stats.k_Me.ToString();
        k_scoreBlock_4.text += "\n" + stats.k_Mo.ToString();
        k_scoreBlock_4.text += "\n" + stats.k_Ya.ToString();
        k_scoreBlock_4.text += "\n" + stats.k_Yu.ToString();
        k_scoreBlock_4.text += "\n" + stats.k_Yo.ToString();
        k_scoreBlock_4.text += "\n" + stats.k_Wa.ToString();
        k_scoreBlock_4.text += "\n" + stats.k_Wo.ToString();

        k_scoreBlock_5.text = stats.k_Ra.ToString();
        k_scoreBlock_5.text += "\n" + stats.k_Ri.ToString();
        k_scoreBlock_5.text += "\n" + stats.k_Ru.ToString();
        k_scoreBlock_5.text += "\n" + stats.k_Re.ToString();
        k_scoreBlock_5.text += "\n" + stats.k_Ro.ToString();
        k_scoreBlock_5.text += "\n" + stats.k_N.ToString();
        k_scoreBlock_5.text += "\n" + stats.k_Ga.ToString();
        k_scoreBlock_5.text += "\n" + stats.k_Gi.ToString();
        k_scoreBlock_5.text += "\n" + stats.k_Gu.ToString();
        k_scoreBlock_5.text += "\n" + stats.k_Ge.ToString();

        k_scoreBlock_6.text = stats.k_Go.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_Za.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_Ji_1.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_Zu_1.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_Ze.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_Zo.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_Da.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_Ji_2.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_Zu_2.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_De.ToString();
        k_scoreBlock_6.text += "\n" + stats.k_Do.ToString();

        k_scoreBlock_7.text = stats.k_Ba.ToString();
        k_scoreBlock_7.text += "\n" + stats.k_Bi.ToString();
        k_scoreBlock_7.text += "\n" + stats.k_Bu.ToString();
        k_scoreBlock_7.text += "\n" + stats.k_Be.ToString();
        k_scoreBlock_7.text += "\n" + stats.k_Bo.ToString();
        k_scoreBlock_7.text += "\n" + stats.k_Pa.ToString();
        k_scoreBlock_7.text += "\n" + stats.k_Pi.ToString();
        k_scoreBlock_7.text += "\n" + stats.k_Pu.ToString();
        k_scoreBlock_7.text += "\n" + stats.k_Pe.ToString();
        k_scoreBlock_7.text += "\n" + stats.k_Po.ToString();
    }

    public void Next() {
        SoundManager.instance.Play("Bloop 1");
        if (hiraganaPanel.gameObject.activeSelf == true) {
            hiraganaPanel.gameObject.SetActive(false);
            katakanaPanel.gameObject.SetActive(true);
            UpdateKatakanaScores();
        }
        else if (katakanaPanel.gameObject.activeSelf == true) {
            hiraganaPanel.gameObject.SetActive(true);
            katakanaPanel.gameObject.SetActive(false);
            UpdateHiraganaScores();
        }
    }

    public void Back() {
        SoundManager.instance.Play("Bloop 1");
        if (hiraganaPanel.gameObject.activeSelf == true) {
            hiraganaPanel.gameObject.SetActive(false);
            katakanaPanel.gameObject.SetActive(true);
            UpdateKatakanaScores();
        }
        else if (katakanaPanel.gameObject.activeSelf == true) {
            hiraganaPanel.gameObject.SetActive(true);
            katakanaPanel.gameObject.SetActive(false);
            UpdateHiraganaScores();
        }
    }

    public void Exit() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("MainMenu");
    }
}
