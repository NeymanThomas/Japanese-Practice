/// <summary>
/// Stores the statistical data for the application. This includes the list of mistakes
/// made when determining hiragana and katakana in challenge modes, highscores, and
/// time spent practicing. The class itself is used to be stored as a json file for
/// easy storage of data.
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
