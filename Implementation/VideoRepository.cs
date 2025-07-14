using WatchMate_API.Entities;
using WatchMate_API.Repository;

namespace WatchMate_API.Implementation
{
    public class VideoRepository : GenericRepository<AdVideo>, IVideoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VideoRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> SaveVideoAsync(IFormFile videoFile, HttpRequest request)
        {
            if (videoFile == null || videoFile.Length == 0)
                throw new Exception("No video file uploaded.");

            var extension = Path.GetExtension(videoFile.FileName);
            var allowedExtensions = new[] { ".mp4", ".mov", ".avi", ".webm", ".mkv" };

            if (!allowedExtensions.Contains(extension.ToLower()))
                throw new Exception("Unsupported video format.");

            var videoFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "videos");
            if (!Directory.Exists(videoFolder))
                Directory.CreateDirectory(videoFolder);

            var fileName = Guid.NewGuid().ToString() + extension;
            var filePath = Path.Combine(videoFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await videoFile.CopyToAsync(stream);
            }

            // Return public URL
            return $"{request.Scheme}://{request.Host}/videos/{fileName}";
        }
    }
}
