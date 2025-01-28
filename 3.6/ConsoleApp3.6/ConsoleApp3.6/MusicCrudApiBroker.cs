using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

namespace ConsoleApp3._6;

public class MusicCrudApiBroker
{
    private HttpClient _httpClient;
    private string _baseUrl;
    public MusicCrudApiBroker()
    {
        _baseUrl = "http://localhost:5044/api/music";
        _httpClient = new HttpClient();
        //Add();
        //Remove();
        //Put();
        //GetAll();
    }

    public void GetAll()
    {
        var url = $"{_baseUrl}/getAllMusic";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        string responseContent = response.Content.ReadAsStringAsync().Result;
       
        response.EnsureSuccessStatusCode();
        
        if(response.IsSuccessStatusCode == false)
        {
            throw new Exception("response qoniqarli emas");
        }

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;
        
         var music = JsonSerializer.Deserialize<Music[]>(responseContent, options);
        
        foreach(var m in music)
        {
            Console.WriteLine(m);
        }
    }

    public void Add(Music music)
    {
        var url = $"{_baseUrl}/addMusic";
        //var music = new Music()
        //{
        //    Name = "Bandaman",
        //    MB = 4.8,
        //    AuthorName = "Sherali Jo'rayev",
        //    Description = "Yaxshi",
        //    QuentityLikes = 45
        //};

        var json = JsonSerializer.Serialize(music); 
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


        var response = _httpClient.PostAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);

    }   

    public void Remove(Guid id)
    {
        //var id = Guid.Parse("ff72653c-e76d-41e3-aa69-1aec9ba7b292");
        var url = $"{_baseUrl}/deleteMusic?id={id}";


        var response = _httpClient.DeleteAsync(url).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);
    }

    public void Put(Music music)
    {
        var url = $"{_baseUrl}/updateMusic";
        //var music = new Music()
        //{
        //    Id = Guid.Parse("e4f2aa58-205c-4d32-a33e-753add5def22"),
        //    Name = "sdfdsfsdfsdfsdfsdfdsfdsfsdfsfsd",
        //    MB = 1,
        //    AuthorName = "boy rfdsfg",
        //    Description = "ogesfes'riq bor",
        //    QuentityLikes = 69
        //};

        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = _httpClient.PutAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);
    }

    public void GetAllMusicByAuthorName(string authorName)
    {
        var url = $"{_baseUrl}/getAllMusicByAuthorName?name={authorName}";

        var response = _httpClient.GetAsync(url).Result;
        var responsContent = response.Content.ReadAsStringAsync().Result;
        response.EnsureSuccessStatusCode();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<List<Music>>(responsContent);

        foreach (var item in music)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item.AuthorName);
            Console.WriteLine();
        }
    }

    public void GetMostLikedMusic()
    {
        var url = $"{_baseUrl}/getMostLikedMusic";

        var response = _httpClient.GetAsync(url).Result;
        var responsContent = response.Content.ReadAsStringAsync().Result;
        response.EnsureSuccessStatusCode();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<Music>(responsContent);

        Console.WriteLine(music.AuthorName);
    }

    public void GetAllMusicAboveSize(double minSizeMb)
    {
        var url = $"{_baseUrl}/getAllMusicAboveSize?minSizeMB={minSizeMb}";

        var response = _httpClient.GetAsync(url).Result;
        var responseContent = response.Content.ReadAsStringAsync().Result;
        response.EnsureSuccessStatusCode();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<List<Music>>(responseContent);

        foreach (var item in music)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Name);
            Console.WriteLine(item.AuthorName);
            Console.WriteLine(item.MB);
            Console.WriteLine();

        }
        {
            
        }
    }

    public void GetTopMostLikedMusic(int count)
    {
        var url = $"{_baseUrl}/GetTopMostLikedMusic?count={count}";

        var respons = _httpClient.GetAsync(url).Result;
        var responsContent = respons.Content.ReadAsStringAsync().Result;
        respons.EnsureSuccessStatusCode();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<List<Music>>(responsContent);

        foreach (var item in music)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Name);
            Console.WriteLine(item.AuthorName);
            Console.WriteLine(item.QuentityLikes);
            Console.WriteLine();
        }
    }

    public void GetMusicByDescriptionKeyword(string keyword)
    {
        var url = $"{_baseUrl}/getMusicByDescriptionKeyword?keyword={keyword}";

        var respons = _httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<List<Music>>(respons);

        foreach (var item in music)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Name);
            Console.WriteLine(item.AuthorName);
            Console.WriteLine(item.Description);
            Console.WriteLine(item.QuentityLikes);
        }
    }

    public void GetAllUniqueAuthors()
    {
        var url = $"{_baseUrl}/getAllUniqueAuthors";

        var response = _httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        Console.WriteLine(response);
    }
}
