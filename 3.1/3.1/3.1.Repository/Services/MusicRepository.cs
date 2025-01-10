using _3._1.DataAccess.Entities;
using System.Text.Json;

namespace _3._1.Repository.Services;

public class MusicRepository : IMusicRepository
{
    private readonly string _path;
    private readonly List<Music> _music;

    public MusicRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Music.json");

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _music = GetAllMusic();
    }

    public Guid AddMusic(Music music)
    {
        _music.Add(music);
        SaveDate();
        return music.Id;
    }

    public void DeleteMusic(Guid id)
    {
        var music = GetMusicById(id);
        _music.Remove(music);
        SaveDate();
    }

    public List<Music> GetAllMusic()
    {
        var musicJson = File.ReadAllText(_path);
        var musicList = JsonSerializer.Deserialize<List<Music>>(musicJson);
        return musicList;
    }

    public Music GetMusicById(Guid id)
    {
        var music = _music.FirstOrDefault(m => m.Id == id);
        if (music == null)
        {
            throw new Exception($"{id}: bunday qo'shiq yo'q");
        }
        return music;
    }

    public void UpdateMusic(Music updatedMusic)
    {
        var music = GetMusicById(updatedMusic.Id);
        var index = _music.IndexOf(music);
        _music[index] = updatedMusic;
        SaveDate();
    }

    private void SaveDate()
    {
        var musicJson = JsonSerializer.Serialize(_music);
        File.WriteAllText(_path, musicJson);
    }
}
