namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        //// Faylga yozish
        //using (FileStream fs = new FileStream("file.bin", FileMode.Create))
        //{
        //    byte[] data = { 1, 2, 3, 4, 5 };
        //    fs.Write(data, 0, data.Length);
        //}

        //// Fayldan o‘qish
        //using (FileStream fs = new FileStream("file.bin", FileMode.Open))
        //{
        //    byte[] data = new byte[fs.Length];
        //    fs.Read(data, 0, data.Length);
        //    Console.WriteLine(string.Join(", ", data));
        //}
        //File.Delete("file.bin");

        // StreamWriter yordamida faylga yozish
        //using (StreamWriter writer = new StreamWriter("textfile.txt", append: true))
        //{
        //    writer.WriteLine("sad");
        //    writer.WriteLine("sadsdada");
        //}

        // StreamReader yordamida fayldan o‘qish
        //using (StreamReader reader = new StreamReader("textfile.txt"))
        //{
        //    string content = reader.ReadToEnd();
        //    Console.WriteLine(content);
        //}

        //FileInfo sad = new FileInfo("D:\\a.txt");
        
        
        //Console.WriteLine(DestCity([["London", "Nyu-York"], ["Nyu-York", "Lima"], ["Lima", "San-Paulu"]]));
    }
    public static string DestCity(IList<IList<string>> paths)
    {
        return paths.Last().Last();
    }

    //public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    //{
        
    //}
}
