using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WatchMate_API.DTO.Settings;
using WatchMate_API.Entities;
using WatchMate_API.Repository;

namespace WatchMate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _cache;
        private const int userId = 1;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VideoController(IUserRepository userRepository, IMemoryCache cache, IUnitOfWork unitOfWork, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("video/{id}")]
        public async Task<IActionResult> GetAdVideoById(int id)
        {
            try
            {
                var video = await _unitOfWork.Video.GetByIdAsync(id);
                if (video == null)
                {
                    return NotFound(new { StatusCode = 404, message = "Ad video not found." });
                }

                return Ok(new { StatusCode = 200, message = "Success", data = video });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "An error occurred", error = ex.Message });
            }
        }


        [HttpGet]
        [Route("videos")]
        public async Task<IActionResult> GetAdVideos()
        {
            try
            {
                var videos = await _unitOfWork.Video.GetAllAsync();
                if (videos == null || !videos.Any())
                {
                    return NotFound(new { StatusCode = 404, message = "Ad videos not found." });
                }

                return Ok(new { StatusCode = 200, message = "Success", data = videos });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "An error occurred", error = ex.Message });
            }
        }

        [HttpPost("create")]
        [RequestSizeLimit(524288000)]
        public async Task<IActionResult> Create([FromForm] AdVideoCreateDTO dto, IFormFile videoFile)
        {
            if (!ModelState.IsValid || dto.PackageIds == null || !dto.PackageIds.Any())
                return BadRequest("Invalid data.");

            string videoUrl;
            try
            {
                videoUrl = await _unitOfWork.Video.SaveVideoAsync(videoFile, Request);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            var video = new AdVideo
            {
                Title = dto.Title,
                VideoUrl = videoUrl,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate, 
                RewardPerView = dto.RewardPerView,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now,
                PackageIds = dto.PackageIds,
            };

            await _unitOfWork.Video.AddAsync(video);
            await _unitOfWork.Save();
            _cache.Remove("ad_videos");

            return Ok(new { StatusCode = 200, message = "Ad video created with upload.", videoUrl });
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var video = await _unitOfWork.Video.GetByIdAsync(id);
            if (video == null)
                return NotFound(new { StatusCode = 404, message = "Ad video not found." });

            // Delete video file from server
            var videoPath = video.VideoUrl;
            var fileName = Path.GetFileName(new Uri(videoPath).AbsolutePath);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "videos", fileName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            // Delete from database
            _unitOfWork.Video.DeleteAsync(id);
            await _unitOfWork.Save();

            // Remove cache
            _cache.Remove("ad_videos");

            return Ok(new { StatusCode = 200, message = "Ad video deleted successfully." });
        }

    }
}
