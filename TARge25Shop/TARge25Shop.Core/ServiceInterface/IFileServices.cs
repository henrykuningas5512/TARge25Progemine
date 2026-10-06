using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;

namespace TARge25Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(KindergardenDto dto, Kindergarden domain);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        void UploadFilesToDatabase(KindergardenDto dto, Kindergarden domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
        Task<FileToDatabase> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
    }
}