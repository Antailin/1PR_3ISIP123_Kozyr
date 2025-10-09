using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
List<Text> texts = new List<Text>();
while (true)
{
    string input = "";
    int TextId = texts.Count + 1;
    Console.WriteLine("Введите текст(минимум 100 символов):");
    input = Console.ReadLine();
    while (input.Length < 100)
    {
        Console.WriteLine("Слишком мало символов! Введите текст еще раз:");
        input = Console.ReadLine();
    }
    StatisticText(TextId, input);
    Console.WriteLine("Хотите ввести еще один текст? (1 - да/2 - нет)");
    int contin = Convert.ToInt32(Console.ReadLine());
    if (contin == 2)
    {
        break;
    }
}
Console.WriteLine("Хотите посмотреть статистику по всем текстам? (1 - да/2 - нет");
int show = Convert.ToInt32(Console.ReadLine());
if (show == 2)
{
    AllStatistic();
}
void StatisticText(int TextId, string text)
{
    string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    int WordsCount = words.Length;
    string ShortestWord = words[0];
    string LongestWord = words[0];
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].Length < ShortestWord.Length)
        {
            ShortestWord = words[i];
        }
        if (words[i].Length > LongestWord.Length)
        {
            LongestWord = words[i];
        }
    }
    string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
    int SentencesCount = sentences.Length;
    char[] vowels = { 'а', 'у', 'о', 'и', 'э', 'ы', 'я', 'ю', 'е', 'ё',
                     'А', 'У', 'О', 'И', 'Э', 'Ы', 'Я', 'Ю', 'Е', 'Ё' };
    char[] consonants = { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п',
                         'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ',
                         'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П',
                         'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ' };
    int VowelsCount = 0;
    int ConsonantsCount = 0;
    Dictionary<char, int> HowOftenLetter = new Dictionary<char, int>();
    for (int i = 0; i < text.Length; i++)
    {
        char CurrentChar = text[i];
        if (char.IsLetter(CurrentChar))
        {
            bool ItVowel = vowels.Contains(CurrentChar);
            bool ItConsonants = consonants.Contains(CurrentChar);
            if (ItVowel == true)
            {
                VowelsCount++;
            }
            else if (ItConsonants == true)
            {
                ConsonantsCount++;
            }
            if (HowOftenLetter.ContainsKey(CurrentChar))
            {
                HowOftenLetter[CurrentChar]++;
            }
            else
            {
                HowOftenLetter.Add(CurrentChar, 1);
            }
        }
    }
    Text NewText = new Text(TextId, WordsCount, ShortestWord, SentencesCount, VowelsCount, ConsonantsCount, LongestWord, HowOftenLetter);
    texts.Add(NewText);
    Console.WriteLine("\nСтатистика по текущему тексту:");
    NewText.PrintInfo();
}
void AllStatistic()
{
    Console.WriteLine("\nСтатистика по всем текстам:");

    if (texts.Count == 0)
    {
        Console.WriteLine("Нет данных для отображения");
        return;
    }

    foreach (Text text in texts)
    {
        text.PrintInfo();
        Console.WriteLine();
    }

}
public class Text
{
    public int TextID { get; set; }
    public int WordsCount { get; set; }
    public string MostShort { get; set; }
    public int SentenceCount { get; set; }
    public int VowelCount { get; set; }
    public int ConsonantsCount { get; set; }
    public string MostLong { get; set; }
    public Dictionary<char, int> HowOftenLetter { get; set; }


    public Text(int TextID, int WordsCount, string MostShort, int SentenceCount, int VowelCount, int ConsonantsCount, string MostLong, Dictionary<char, int> HowOftenLetter)
    {
        this.TextID = TextID;
        this.WordsCount = WordsCount;
        this.MostShort = MostShort;
        this.SentenceCount = SentenceCount;
        this.VowelCount = VowelCount;
        this.ConsonantsCount = ConsonantsCount;
        this.MostLong = MostLong;
        this.HowOftenLetter = HowOftenLetter;
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
        Console.WriteLine("Частота встречаемости букв:");
        foreach (var pair in HowOftenLetter)
        {
            Console.WriteLine($"  {pair.Key}: {pair.Value} раз");
        }

    }
}

//Комсомольцы трудились день и ночь, не покладая рук, не вставая с постели. Летом, мы с пацанами ходили в поход с ночевкой, и с собой взяли только необходимое. Картошку, палатку и Марию Ивановну. Умер М. Ю. Лермонтов на Кавказе, но любил он его не поэтому! Плюшкин навалил у себя в углу целую кучу и каждый день туда подкладывал. Ленский вышел на дуэль в панталонах. Они разошлись и раздался выстрел. Дантес не стоил выеденного яйца Пушкина Во двор въехали две лошади. Это были сыновья Тараса Бульбы. Онегину нравился Байрон, поэтому он и повесил его над кроватью. Герасим поставил на пол блюдечко, и стал тыкать в него мордочкой. У Онегина было тяжело внутри, и он пришел к Татьяне облегчиться. Андрей Болконский часто ездил поглядеть тот дуб, на который он был похож как две капли воды. Лермонтов родился у бабушки в деревне, когда его родители жили в Петербурге. Герасим налил Муме щей. Бедная Лиза рвала цветы и этим кормила свою мать. Хлестаков сел в бричку и крикнул: "Гони, голубчик, в аэропорт! ".Отец Чацкого умер в детстве. Вдруг Герман услыхал скрип рессор. Это была старая княгиня. У Ростовых было три дочери: Наташа, Соня и Николай. Из всех женских прелестей у Марии Болконской были только глаза. Тарас сел на коня. Конь согнулся, а потом засмеялся. Душа Татьяны полна любви и ждёт не дождётся, как бы обдать ею кого-нибудь. Шел полк французов и кутузов. Онегин был богатый человек: по утрам он сидел в уборной, а потом ехал в цирк. Петр Первый соскочил с пьедестала и побежал за Евгением, громко цокая копытами. Нос Гоголя наполнен глубочайшим содержанием. Глухонемой Герасим не любил сплетен и говорил только правду. Тургенева не удовлетворяют ни отцы, ни дети. Такие девушки, как Ольга, уже давно надоели Онегину, да и Пушкину тоже. С Михаилом Юрьевичем Лермонтовым я познакомилась в детском саду. Герасим ел за четверых, а работал один. Базаров любил разных насекомых и делал им прививки. Пугачев пожаловал шубу и лошадь со своего плеча. У Чичикова много положительных черт: он всегда выбрит и пахнет. Базаров умер молодым человеком и сбыча его мечт не произошла. Сыновья приехали к Тарасу и стали с ним знакомиться. Чичиков ехал в карете с поднятым задом. По дороге в Богучарово Андрей Болконский, как старый дуб, расцвел и зазеленел. Фамусов осуждает свою дочь за то, что Софья с самого утра и уже с мужчиной. Наташа была истинно русской натурой, очень любила природу и часто ходила на двор. Герасим бросил Татьяну и связался с Муму. Грушницкий тщательно целил в лоб, пуля оцарапала колено. Поэты XIX века были легкоранимыми людьми: их часто убивали на дуэлях. Здесь он впервые узнал разговорную русскую речь от няни Арины Родионовны. Первые успехи Пьера Безухова в любви были плохие - он сразу женился. В результате из Тихона вырос не мужчина, а самый настоящий овца. Язык у Базарова был тупой, но потом заострился в спорах. Мне нравится то, что с таким талантом Пушкин не побоялся стать народным поэтом.Троекуров был хотя не глуп, но немного с приветом. Так как Печорин - человек лишний, то и писать о нем - лишняя трата времени.