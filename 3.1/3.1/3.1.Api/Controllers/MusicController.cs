using _3._1.Service.DTOs;
using _3._1.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3._1.Api.Controllers
{
    [Route("api/music")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController()
        {
            _musicService = new MusicService();
        }


        [HttpPost("addMusic")]
        public Guid AddMusic(MusicDto musicDto)
        {
            var id = _musicService.AddMusic(musicDto);
            return id;
        }

        [HttpPut("updateMusic")]
        public void updateMusic(MusicDto updatedMusicDto)
        {
            _musicService.UpdateMusic(updatedMusicDto);
        }

        [HttpGet("getAllMusic")]
        public List<MusicDto> GetAllMusic()
        {
            return _musicService.GetAllMusic();
        }

        [HttpDelete("deleteMusic")]
        public void DeleteMusic(Guid id)
        {
            _musicService.DeleteMusic(id);
        }

        [HttpGet("getMusicById")]
        public MusicDto GetMusicById(Guid id)
        {
            return _musicService.GetMusicById(id);
        }
    }
}
