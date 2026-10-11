using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using TARge25Shop.Data;

namespace TARge25Shop.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _environment;
        private readonly TARge25ShopContext _context;

        public FileServices(IHostEnvironment environment, TARge25ShopContext context)
        {
            _environment = environment;
            _context = context;
        }

        public async Task FilesToApi(KindergardenDto dto, Kindergarden domain)
        {
            if (dto.Files == null || dto.Files.Count == 0) return;

            var uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "multipleFileUpload");
            Directory.CreateDirectory(uploadsFolder);

            foreach (var file in dto.Files)
            {
                if (file == null || file.Length == 0) continue;

                var uniqueFileName = $"{Guid.NewGuid():N}_{Path.GetFileName(file.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                await using (var stream = new FileStream(filePath, FileMode.CreateNew))
                {
                    await file.CopyToAsync(stream);
                }

                await _context.FileToApis.AddAsync(new FileToApi
                {
                    Id = Guid.NewGuid(),
                    ExistingFilePath = uniqueFileName,
                    KindergardenId = domain.Id
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<FileToApi?> RemoveImageFromApi(FileToApiDto dto)
        {
            var image = await _context.FileToApis.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (image == null) return null;

            DeleteUploadedFile(image.ExistingFilePath);
            _context.FileToApis.Remove(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos)
        {
            var removedImages = new List<FileToApi>();
            foreach (var dto in dtos)
            {
                var image = await _context.FileToApis.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (image == null) continue;

                DeleteUploadedFile(image.ExistingFilePath);
                _context.FileToApis.Remove(image);
                removedImages.Add(image);
            }

            await _context.SaveChangesAsync();
            return removedImages;
        }

        private void DeleteUploadedFile(string? fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return;
            var uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "multipleFileUpload");
            var filePath = Path.Combine(uploadsFolder, Path.GetFileName(fileName));
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}
