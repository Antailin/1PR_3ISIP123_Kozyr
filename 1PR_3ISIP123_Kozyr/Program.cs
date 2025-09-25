using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
List<Text> texts = new List<Text>();
int max = -1;
int min = 999999;
string input = "";
Console.WriteLine("Введите текст(минимум 100 символов):");
input  = Console.ReadLine();
while (input.Length < 100)
{
    LongChek();
}
int id = 1;
 void LongChek()
{
    if (input.Length< 100)
    {
        Console.WriteLine("Слишком мало символов!");
    }
    Console.WriteLine("Введите текст(минимум 100 символов):");
    input = Console.ReadLine();
    
}
void FindAll()
{

    string shortest="";
    string longest="";
    string[] words = input.Split(new char[] { ' ' });
    int WordsCount = words.Length;
    for(int i = 0; i < words.Length; i++)
    {   
        if (words[i].Length < min)
        {
            shortest = words[i];
        }
        if (words[i].Length > max)
        {
            longest = words[i];
        }

    }
    string MostShort = shortest;
    string MostLong = longest;
    string[] sentences = input.Split(new char[] { '.' });
    int SentencesCount = sentences.Length;
    string[] volwels = { "а", "у", "о", "и", "э", "ы", "я", "ю", "е", "ё"};
    string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" };
    int VowelCount = 0;
    int ConsonantsCount = 0;
    for (int i = 0;i < input.Length;i++)
    {
        for (int j = 0; j < volwels.Length; j++)
        {
            if (input[i] == volwels[j])
            {
                VowelCount++;
            }
        }
        for (int j = 0;j < consonants.Length; j++)
        {
            if (input[i] == consonants[j])
            {
                ConsonantsCount++;
            }
        }
    }
    texts.Add(new Text(id,WordsCount, MostShort, SentencesCount, VowelCount, ConsonantsCount, MostLong));
}
FindAll();
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