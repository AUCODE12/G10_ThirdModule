using MusicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repository.Services;

public interface IMusicRepository
{
    Task<Guid> AddMusicAsync(Music music);
    Task DeleteMusicAsync(Guid id);
    Task UpdateMusicAsync(Music music);
    Task<Music> GetMusicByIdAsync(Guid id);
    Task<List<Music>> GetAllMusicAsync();
}