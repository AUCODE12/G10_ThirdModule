using _3._1.DataAccess.Entities;
using _3._1.Repository.Services;
using _3._1.Service.DTOs;

namespace _3._1.Service.Services;

public class MusicService : IMusicService
{
    private readonly IMusicRepository _musicRepository;

    public MusicService()
    {
        _musicRepository = new MusicRepository();
    }

    //Crud
    public Guid AddMusic(MusicDto musicDto)
    {
        var musicId = _musicRepository.AddMusic(ConvertToMusicEntity(musicDto));
        return musicId;
    }

    public void DeleteMusic(Guid id)
    {
        _musicRepository.DeleteMusic(id);
    }

    public List<MusicDto> GetAllMusic()
    {
        var music = _musicRepository.GetAllMusic();
        return music.Select(m => ConvertToMusicDto(m)).ToList();
    }

    public MusicDto GetMusicById(Guid id)
    {
        return ConvertToMusicDto(_musicRepository.GetMusicById(id));
    }

    public void UpdateMusic(MusicDto updatedMusicDto)
    {
        _musicRepository.UpdateMusic(ConvertToMusicEntity(updatedMusicDto));
    }

    //Convert
    private Music ConvertToMusicEntity(MusicDto musicDto)
    {
        return new Music()
        {
            AuthorName = musicDto.AuthorName,
            Description = musicDto.Description,
            MB = musicDto.MB,
            Name = musicDto.Name,
            QuentityLikes = musicDto.QuentityLikes,
            Id = musicDto.Id ?? Guid.NewGuid(),
        };
    }

    private MusicDto ConvertToMusicDto(Music music)
    {
        return new MusicDto()
        {
            AuthorName = music.AuthorName,
            Description = music.Description,
            MB = music.MB,
            Name = music.Name,
            Id = music.Id,
            QuentityLikes = music.QuentityLikes,
        };
    }
}
