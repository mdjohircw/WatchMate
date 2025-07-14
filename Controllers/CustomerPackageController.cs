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
    public class CustomerPackageController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _cache;
        private const int userId = 1;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerPackageController(IUserRepository userRepository, IMemoryCache cache, IUnitOfWork unitOfWork, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("user-packages")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> GetUserPackages()
        {
            try
            {
                string cacheKey = "user_packages";
                if (!_cache.TryGetValue(cacheKey, out List<CustomerPackage> cachedList))
                {
                    var userPackages = await _unitOfWork.UserPackages.GetAllAsync();
                    if (userPackages == null || !userPackages.Any())
                        return NotFound(new { StatusCode = 404, message = "User packages not found." });

                    var list = userPackages.ToList();
                    _cache.Set(cacheKey, list, TimeSpan.FromMinutes(1));
                    return Ok(new { StatusCode = 200, message = "Success", data = list });
                }

                return Ok(new { StatusCode = 200, message = "Success", data = cachedList });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "An error occurred", error = ex.Message });
            }
        }

        [HttpGet]
        [Route("user-package/{id}")]
        public async Task<IActionResult> GetUserPackage(int id)
        {
            try
            {
                string cacheKey = $"user_package_{id}";
                if (!_cache.TryGetValue(cacheKey, out CustomerPackage cachedItem))
                {
                    var result = await _unitOfWork.UserPackages.GetByIdAsync(id);
                    if (result == null)
                        return NotFound(new { StatusCode = 404, message = "User package not found." });

                    _cache.Set(cacheKey, result, TimeSpan.FromMinutes(1));
                    return Ok(new { StatusCode = 200, message = "Success", data = result });
                }

                return Ok(new { StatusCode = 200, message = "Success", data = cachedItem });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "Error retrieving user package", error = ex.Message });
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserPackage([FromBody] CustomerPackageCreateDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { StatusCode = 400, message = "User package data is null." });

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Get the package from the database
                var package = await _unitOfWork.Package.GetByIdAsync(dto.PackageId);
                if (package == null)
                    return NotFound(new { StatusCode = 404, message = "Package not found." });

                var startDate = DateTime.Now;
                var expiryDate = package.ValidityDays.HasValue
                    ? startDate.AddDays(package.ValidityDays.Value)
                    : (DateTime?)null;

                var userPackage = new CustomerPackage
                {
                    CustomerId = dto.CustomerId,
                    PackageId = dto.PackageId,
                    StartDate = startDate,
                    ExpiryDate = (DateTime)expiryDate,
                    IsActive = dto.IsActive,
                    CreatedAt = DateTime.Now,
                    CreatedBy = dto.UserId
                };

                await _unitOfWork.UserPackages.AddAsync(userPackage);
                await _unitOfWork.Save();

                _cache.Remove("user_packages");

                return Ok(new { StatusCode = 200, message = "User package created successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "An error occurred", error = ex.Message });
            }
        }


        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateUserPackage(int id, [FromBody] CustomerPackageCreateDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { StatusCode = 400, message = "Invalid data." });

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existing = await _unitOfWork.UserPackages.GetByIdAsync(id);
                if (existing == null)
                    return NotFound(new { StatusCode = 404, message = "User package not found." });

                existing.CustomerId = dto.CustomerId;
                existing.PackageId = dto.PackageId;
                existing.StartDate = DateTime.Now;
                existing.IsActive = dto.IsActive;
                existing.UpdatedAt = DateTime.Now;
                existing.UpdatedBy=dto.UserId;

                await _unitOfWork.UserPackages.UpdateAsync(existing);
                await _unitOfWork.Save();

                _cache.Remove("user_packages");
                _cache.Remove($"user_package_{id}");

                return Ok(new { StatusCode = 200, message = "User package updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "Update failed", error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUserPackage(int id)
        {
            try
            {
                 _unitOfWork.UserPackages.DeleteAsync(id);

                _cache.Remove("user_packages");
                _cache.Remove($"user_package_{id}");

                return Ok(new { StatusCode = 200, message = "User package deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "Deletion failed", error = ex.Message });
            }
        }
    }
}
