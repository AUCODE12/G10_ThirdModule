using System;
using System.IO;
using System.Threading.Tasks;
using Xabe.FFmpeg;

class Program
{
    static async Task Main()
    {
        // Video faylning to'liq manzilini kiriting
        string videoFilePath = @"C:\Users\user\Downloads\Telegram Desktop\video.mp4";
        await GenerateScreenshots(videoFilePath);
    }

    static async Task GenerateScreenshots(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Xatolik: Video fayli mavjud emas!");
            return;
        }

        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots", fileName);
        Directory.CreateDirectory(outputDir);

        // Videoning davomiyligini olish
        var mediaInfo = await FFmpeg.GetMediaInfo(filePath);
        int duration = (int)mediaInfo.Duration.TotalSeconds; // Umumiy soniyalar

        // Har daqiqada bitta screenshot olish
        for (int i = 1; i <= duration / 60; i++)
        {
            string outputPath = Path.Combine(outputDir, $"screenshot_{i}.jpg");

            await FFmpeg.Conversions.New()
                .AddParameter($"-ss {i * 60} -i \"{filePath}\" -vframes 1 -q:v 2 \"{outputPath}\"")
                .Start();

            Console.WriteLine($"Screenshot {i} yaratildi ({i} daqiqada).");
        }

        Console.WriteLine("Barcha screenshotlar muvaffaqiyatli yaratildi!");
    }
}
