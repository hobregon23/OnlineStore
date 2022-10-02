using Microsoft.AspNetCore.Mvc;
using OnlineStore.UoW;
using OnlineStore.Data.Services;
using Microsoft.AspNetCore.Http;

namespace OnlineStore.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableRequestSizeLimit]

    public class UploadController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;

        public UploadController(
            IUploadService uploadService,
            IUnitOfWork unitOfWork)
        {
            _uploadService = uploadService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("category")]
        public IActionResult Category(IFormFile file)
        {
            try
            {
                _uploadService.UploadCategory(file);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
