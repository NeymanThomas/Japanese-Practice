/// <summary>
/// A simple class that is used to hold the raw data for the application. All mistakes
/// are saved as an integer for the associated values in the class. Upon class creation
/// all values are set to 0. The add_H_Stat and add_K_Stat functions then take a specific
/// input and increment the associated value by 1. The class is then re-serialized by the 
/// SaveSystem class.
/// </summary>


public class StatisticalData
{

    public int[] hiraganaMistakes = new int[JapaneseDictionaries.HiraganaToEnglish.Count];
    public int[] katakanaMistakes = new int[JapaneseDictionaries.KatakanaToEnglish.Count];
    public float hiraganaHighscore;
    public float katakanaHighscore;
    public float timeSpentPracticing;

    public StatisticalData() 
    {
        for (int i = 0; i < JapaneseDictionaries.HiraganaToEnglish.Count; i++) 
        {
            hiraganaMistakes[i] = 0;
        }
        for (int j = 0; j < JapaneseDictionaries.KatakanaToEnglish.Count; j++) 
        {
            katakanaMistakes[j] = 0;
        }
        hiraganaHighscore = 0;
        katakanaHighscore = 0;
        timeSpentPracticing = 0;
    }
}
