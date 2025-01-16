namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        var filePath = @"C:\Users\user\Downloads\Telegram Desktop\testTXT.txt";
        var numberOfDigitsEachLine = GetNumberOfDigitsEachLine(filePath);

        foreach (var item in numberOfDigitsEachLine)
        {
            Console.WriteLine(item);
        }
    }

    public static List<int> GetNumberOfDigitsEachLine(string filePath)
    {
        var numsCountInLine = new List<int>();
        using (var streamReader = new StreamReader(filePath))
        {
            while (true)
            {
                var line = streamReader.ReadLine();
                if (line == null) break;
                var digitCount = line.Count(l => char.IsDigit(l));
                numsCountInLine.Add(digitCount);
            }
        }
        return numsCountInLine;
    }
}
