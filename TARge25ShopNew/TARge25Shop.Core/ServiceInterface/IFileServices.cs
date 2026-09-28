using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;

namespace TARge25Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship domain);
        Task<FileToApi> RemoveImagesFromApi(FileToApiDto dto);
        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dto);

    }
}
