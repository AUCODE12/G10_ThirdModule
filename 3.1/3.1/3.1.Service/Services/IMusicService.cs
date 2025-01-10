using _3._1.Service.DTOs;

namespace _3._1.Service.Services;

public interface IMusicService
{
    Guid AddMusic(MusicDto musicDto);

    List<MusicDto> GetAllMusic();

    MusicDto GetMusicById(Guid id);

    void DeleteMusic(Guid id);

    void UpdateMusic(MusicDto updatedMusicDto);

}