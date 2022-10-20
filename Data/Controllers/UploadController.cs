using Microsoft.AspNetCore.Mvc;
using OnlineStore.UoW;
using OnlineStore.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace OnlineStore.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableRequestSizeLimit]

    public class UploadController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

        public UploadController(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        [HttpPost("category")]
        public async Task<IActionResult> Category(IFormFile file, string filename)
        {
            try
            {
                var imagePath = @"\img\categories";
                await UploadFile(file, imagePath, filename);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("product")]
        public async Task<IActionResult> Product(IFormFile file, string filename)
        {
            try
            {
                var imagePath = @"\img\products";
                await UploadFile(file, imagePath, filename);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("qr_tarjeta")]
        public async Task<IActionResult> Qr_tarjeta(IFormFile file, string filename)
        {
            try
            {
                var imagePath = @"\img\tarjetas";
                await UploadFile(file, imagePath, filename);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("top_banner")]
        public async Task<IActionResult> Top_banner(IFormFile file, string filename)
        {
            try
            {
                var imagePath = @"\img\hero";
                await UploadFile(file, imagePath, filename);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("bottom_banner")]
        public async Task<IActionResult> Bottom_banner(IFormFile file, string filename)
        {
            try
            {
                var imagePath = @"\img\banner";
                await UploadFile(file, imagePath, filename);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        private async Task UploadFile(IFormFile file, string imagePath, string filename)
        {
            if (file != null && file.Length > 0)
            {
                var uploadPath = _environment.WebRootPath + imagePath;
                var fullPath = Path.Combine(uploadPath, filename);
                using FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                await file.CopyToAsync(fileStream);
            }
        }
    }
}
