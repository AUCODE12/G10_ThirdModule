using System.Text.Json;

namespace ConsoleApp1;

internal class ValyutaGetApiBroker
{
    private HttpClient _httpClient;
    private string _baseUrl;

    public ValyutaGetApiBroker()
    {
        _baseUrl = "https://cbu.uz/uz/arkhiv-kursov-valyut";
        _httpClient = new HttpClient();
    }

    public void GetAll()
    {
        var url = $"{_baseUrl}/json/";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        string responseContent = response.Content.ReadAsStringAsync().Result;
        response.EnsureSuccessStatusCode();
        
        var result = JsonSerializer.Deserialize<List<Valyuta>>(responseContent);
        if (result != null)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item); // Example action
            }
        }
    }
}
