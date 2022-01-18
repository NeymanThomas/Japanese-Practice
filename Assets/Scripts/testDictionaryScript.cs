using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testDictionaryScript : MonoBehaviour
{
    public Dictionary<string, string> dict;
    [SerializeField] private TMP_Text sampleText;

    void Start()
    {
        dict = new Dictionary<string, string>() 
        {
            {"carp", "こい"},
            {"hill", "おか"},
            {"pond", "いけ"},
            {"above", "うえ"},
            {"autumn", "あき"},
            {"write", "かく"}
        };

        sampleText.text = dict["carp"] + " " + dict["hill"];
    }
}
