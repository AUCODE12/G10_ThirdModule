namespace ConsoleApp1;

internal class Program
{
    static async Task Main(string[] args)
    {
    }

    public static async Task<string> GetChoy()
    {
        var boiledWatherTask = BoilWater();

        Console.WriteLine("Shikafdan choknakni oldik");
        Console.WriteLine("Choynakga quruq soy soldik");
        await BoilWater();
        var res = $"Choynakga {boiledWatherTask.Result}ni quydik";
        Console.WriteLine(res);
        return res;
    }

    public static async Task<string> BoilWater()
    {
        Console.WriteLine("Tefalni oldik");
        Console.WriteLine("Tefalga suvni quydik");
        Console.WriteLine("Tefalni yoqdik");
        await Task.Delay(5000);
        Console.WriteLine("Suv qayndi");
        var res = "Qaynagan suv";

        return res;
    }
}
