// See https://aka.ms/new-console-template for more information

string pathToFile = "coding_qual_input.txt";
var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
List<string> listOfStrings  = File.ReadLines(baseDirectory+pathToFile).ToList();
Dictionary<int,string> dictionary = CreateTheDictionary(listOfStrings);
List<int> numbersList = dictionary.Keys.ToList();
List<int> latestNumbers = LatestByPyramid(numbersList);
string textFromCodedText = GetTextFromNumberAndDictionary(latestNumbers, dictionary);
Console.Write("The code from the text File is ",textFromCodedText);

Dictionary<int, string> CreateTheDictionary(List<string> listOfStrings)
{
    Dictionary<int, string> mainDictionary;
    mainDictionary = new Dictionary<int, string>();
    foreach (string numberWordPair in listOfStrings)
    {
        try
        {
            var separatedWord = numberWordPair.Trim().Split(' ');
            int.TryParse(separatedWord.First().Trim(),out int number);
            string word = separatedWord.Last();
            mainDictionary.Add(number,word);
        }
        catch(Exception ex)
        {
            continue;
        }
    }

    return mainDictionary;
}

List<int> LatestByPyramid(List<int> numbersFromDictionary)
{
    numbersFromDictionary.Sort();
    List<int> listToReturn = new List<int>();
    int currentLevelSize = 1;
    int currentIndex = 0;
    while (currentIndex < numbersFromDictionary.Count())
    {
        listToReturn.Add(numbersFromDictionary[currentIndex+currentLevelSize-1]);
        currentIndex += currentLevelSize;
        currentLevelSize++;
    }

    return listToReturn;
}

String GetTextFromNumberAndDictionary(List<int> numbers, Dictionary<int, string> dictionaryToUse)
{
    List<String> stringsFromThisNumbersList = [];
    
    numbers.Sort();
    foreach (int number in numbers)
    {
        stringsFromThisNumbersList.Add(dictionaryToUse[number]);
    }
    
    return String.Join(' ',stringsFromThisNumbersList);
}