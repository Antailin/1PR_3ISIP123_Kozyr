using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
List<Text> texts = new List<Text>();
int id = 1;
bool a = true;
while (a == true)
{
    Console.WriteLine("Выберите действие:\n1 - Ввести новый текст\n2 - Показать статистику по прошлым текстам\n3 - Выйти");
    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            WriteNewText();
            break;
        case 2:
            ShowStatistic();
            break;
        case 3:
            a = false;
            break;
    }
}
void WriteNewText()
{
    string input = ChekInput();
    if (input == "Error")
    {
        Console.WriteLine("Слишком мало символов");
    }
    else
    {
        Text TextStatistic = AnalyzeText(input);
        texts.Add(TextStatistic);
        TextStatistic.PrintInfo();
        id++;
    }

}
static string ChekInput()
{
    Console.WriteLine("Введите текст (минимум 100 символов):");
    string input = Console.ReadLine();
    if (input.Length < 100)
    {
        Console.WriteLine("Слишком мало символов!");
        return "Error";
    }
    else
    {
        return input;
    }
}
Text AnalyzeText(string input)
{
    string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r', '\t' });
    int wordsCount = words.Length;
    string shortest = "";
    string longest = "";
    if (words.Length > 0)
    {
        shortest = CleanWord(words[0]);
        longest = CleanWord(words[0]);

        for (int i = 1; i < words.Length; i++)
        {
            string cleanWord = CleanWord(words[i]);
            if (cleanWord.Length == 0) continue;

            if (cleanWord.Length < shortest.Length)
                shortest = cleanWord;
            if (cleanWord.Length > longest.Length)
                longest = cleanWord;
        }
    }

    string[] sentences = input.Split(new char[] { '.', '!', '?' });
    int sentencesCount = sentences.Length;
    int vowelsCount = 0;
    int consonantsCount = 0;
    Dictionary<char, int> lettersFrequency = new Dictionary<char, int>();

    foreach (char c in input.ToLower())
    {
        if (char.IsLetter(c))
        {
            if (lettersFrequency.ContainsKey(c))
                lettersFrequency[c]++;
            else
                lettersFrequency[c] = 1;
            if (IsVowel(c))
                vowelsCount++;
            else
                consonantsCount++;
        }
    }

    // ДОБАВЛЕНО: возврат объекта Text со всеми параметрами
    return new Text(id, wordsCount, shortest, sentencesCount, vowelsCount, consonantsCount, longest, lettersFrequency);
}
static string CleanWord(string word)
{
    string cleanWord = "";
    foreach (char c in word)
    {
        if (char.IsLetter(c))
        {
            cleanWord += c;
        }
    }
    return cleanWord;
}

public class Text
{
    public int TextID { get; set; }
    public int WordsCount { get; set; }
    public string MostShort { get; set; }
    public int SentenceCount { get; set; }
    public int VowelCount { get; set; }
    public int ConsonantsCount { get; set; }
    public string MostLong {  get; set; }


     public Text(int TextID, int WordsCount, string MostShort, int SentenceCount, int VowelCount, int ConsonantsCount, string MostLong)
    {
        this.TextID = TextID;
        this.WordsCount = WordsCount;
        this.MostShort = MostShort;
        this.SentenceCount = SentenceCount;
        this.VowelCount = VowelCount;
        this.ConsonantsCount = ConsonantsCount;
        this.MostLong = MostLong;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"ID: {TextID}");
        Console.WriteLine($"Количесвто слов: {WordsCount}");
        Console.WriteLine($"Самое короткое слово: {MostShort}");
        Console.WriteLine($"Количесвто предложений: {SentenceCount}");
        Console.WriteLine($"Количество согласных букв: {VowelCount}");
        Console.WriteLine($"Количество гласных букв: {ConsonantsCount}");
        Console.WriteLine($"Самое длиннное слово: {MostLong}");
    }
}