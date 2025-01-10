using _3._1.DataAccess.Entities;

namespace _3._1.Repository.Services;

public interface IMusicRepository
{
    Guid AddMusic(Music music);

    List<Music> GetAllMusic();

    Music GetMusicById(Guid id);

    void DeleteMusic(Guid id);

    void UpdateMusic(Music updatedMusic);
}