using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IUploadService
    {
        Task UploadCategory(IFormFile file);
    }

    public class UploadService : IUploadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;
        private readonly IWebHostEnvironment _environment;

        public UploadService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment environment)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public async Task UploadCategory(IFormFile file)
        {
            await UploadFile(file);
        }

        public async Task UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\img\categories";
                var uploadPath = _environment.WebRootPath + imagePath;
                var fullPath = Path.Combine(uploadPath, file.FileName);
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
        }

    }
}
