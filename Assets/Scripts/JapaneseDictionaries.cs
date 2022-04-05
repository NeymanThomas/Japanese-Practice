using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class JapaneseDictionaries
{
    /// <summary>
    /// Static utility function that sanitizes a lookup string then compares the string itself
    /// as a key to entires in the EnglishToJapanese dictionary. 
    /// </summary>
    /// <param name="lookup">The string being searched for in the dictionary</param>
    /// <returns>The japanese translation if true, the string "Error" if false</returns>
    public static string DictionaryLookup(string lookup) {
        Regex rgx = new Regex("[^a-zA-Z -]");
        lookup = rgx.Replace(lookup, "");
        lookup = lookup.ToLower();
        if(EnglishToJapanese.ContainsKey(lookup)) {
            return EnglishToJapanese[lookup];
        }
        return "Error";
    }

    #region Japanese-to-English
    // Dictionary containing the list of vocabulary from Japanese into English
    public static readonly Dictionary<string, string> JapaneseToEnglish = new Dictionary<string, string>
    {
        #region chapter 1
        {"ともだち", "friend"},
        {"英語", "english language"},
        {"はい", "yes"},
        {"ええ", "yes"},
        {"いま", "now"},
        {"学生", "student"},
        {"高校", "high school"},
        {"午後", "p.m."},
        {"午前", "a.m."},
        {"専攻", "major"},
        {"先生", "teacher"},
        {"そうです", "that's right"},
        {"そうですか", "is that so?"},
        {"大学", "college"},
        {"電話", "telephone"},
        {"名前", "name"},
        {"何", "what"},
        {"日本", "japan"},
        {"半", "half"},
        {"番号", "number"},
        {"留学生", "international student"},
        {"私", "i"},
        {"アメリカ", "america"},
        {"イギリス", "britain"},
        {"オーストラリア", "australia"},
        {"韓国", "korea"},
        {"中国", "china"},
        {"スウェーデン", "sweden"},
        {"科学", "science"},
        {"経済", "economics"},
        {"国際関係", "international relations"},
        {"コンピューター", "computer"},
        {"政治", "politics"},
        {"ビジネス", "business"},
        {"文学", "literature"},
        {"歴史", "history"},
        {"仕事", "job"},
        {"医者", "doctor"},
        {"会社員", "office worker"},
        {"高校生", "high school student"},
        {"主婦", "housewife"},
        {"大学院生", "graduate student"},
        {"大学生", "college student"},
        {"弁護士", "lawyer"},
        {"お母さん", "mother"},
        {"お父さん", "father"},
        {"お姉さん", "older sister"},
        {"お兄さん", "older brother"},
        {"いもうと", "younger sister"},
        {"妹", "younger sister"},
        {"おとうと", "younger brother"},
        {"弟", "younger brother"},
        #endregion
        {"月曜日", "monday"},
        {"火曜日", "tuesday"},
        {"水曜日", "wednesday"},
        {"木曜日", "thursday"},
        {"金曜日", "friday"},
        {"土曜日", "saturday"},
        {"日曜日", "sunday"}
    };

    #endregion

    #region English-to-Japanese
    // Dictionary containing the list of vocabulary from English into Japanese
    public static readonly Dictionary<string, string> EnglishToJapanese = new Dictionary<string, string>
    {
        #region chapter 1
        {"friend", "ともだち"},
        {"english language", "英語"},
        {"yes", "ええ, はい"},
        {"now", "いま"},
        {"student", "学生"},
        {"high school", "高校"},
        {"p.m.", "午後"},
        {"a.m.", "午前"},
        {"major", "専攻"},
        {"teacher", "先生"},
        {"that's right", "そうです"},
        {"is that so?", "そうですか"},
        {"college", "大学"},
        {"telephone", "電話"},
        {"name", "名前"},
        {"what", "何"},
        {"japan", "日本"},
        {"half", "半"},
        {"number", "番号"},
        {"international student", "留学生"},
        {"i", "私"},
        {"america", "アメリカ"},
        {"britain", "イギリス"},
        {"australia", "オーストラリア"},
        {"korea", "韓国"},
        {"china", "中国"},
        {"sweden", "スウェーデン"},
        {"science", "科学"},
        {"economics", "経済"},
        {"international relations", "国際関係"},
        {"computer", "コンピューター"},
        {"politics", "政治"},
        {"business", "ビジネス"},
        {"literature", "文学"},
        {"history", "歴史"},
        {"job", "仕事"},
        {"doctor", "医者"},
        {"office worker", "会社員"},
        {"high school student", "高校生"},
        {"housewife", "主婦"},
        {"graduate student", "大学院生"},
        {"college student", "大学生"},
        {"lawyer", "弁護士"},
        {"mother", "お母さん"},
        {"father", "お父さん"},
        {"older sister", "お姉さん"},
        {"older brother", "お兄さん"},
        {"younger sister", "妹, いもうと"},
        {"younger brother", "弟, おとうと"}
        #endregion
    };

    #endregion

    #region Kanji-to-Hiragana
    // Dictionary for converting kanji characters into hiragana pronunciations
    public static readonly Dictionary<string, string> KanjiToHiragana = new Dictionary<string, string> 
    {
        #region chapter 1
        {"英語", "えいご"},
        {"学生", "がくせい"},
        {"高校", "こうこう"},
        {"午後", "ごご"},
        {"午前", "ごぜん"},
        {"専攻", "せんこう"},
        {"先生", "せんせい"},
        {"大学", "だいがく"},
        {"電話", "でんわ"},
        {"名前", "なまえ"},
        {"何", "なに / なん"},
        {"日本", "にほん"},
        {"半", "はん"},
        {"番号", "ばんごう"},
        {"留学生", "りゅうがくせい"},
        {"私", "わたし"},
        {"韓国", "かんこく"},
        {"中国", "ちゅうごく"},
        {"科学", "かがく"},
        {"経済", "けいざい"},
        {"国際関係", "こくさいかんけい"},
        {"政治", "せいじ"},
        {"文学", "ぶんがく"},
        {"歴史", "れきし"},
        {"仕事", "しごと"},
        {"医者", "いしゃ"},
        {"会社員", "かいしゃいん"},
        {"高校生", "こうこうせい"},
        {"主婦", "しゅふ"},
        {"大学院生", "だいがくいんせい"},
        {"大学生", "だいがくせい"},
        {"弁護士", "べんごし"},
        {"お母さん", "おかあさん"},
        {"お父さん", "おとうさん"},
        {"お姉さん", "おねえさん"},
        {"お兄さん", "おにいさん"},
        {"妹", "いもうと"},
        {"弟", "おとうと"}
        #endregion
    };

    #endregion
}
