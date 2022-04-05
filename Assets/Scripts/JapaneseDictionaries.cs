using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class JapaneseDictionaries
{
    public static Regex rgx = new Regex("[^a-zA-Z -]");

    public static string DictionaryLookup(string lookup) {
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
        {"ええ, はい", "yes"},
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
        {"妹, いもうと", "younger sister"},
        {"弟, おとうと", "younger brother"},
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
}
