using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;

namespace TARge25Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship domain);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);

        Task UploadFilesToDatabase(RealEstateDto dto, RealEstate domain);
        Task UploadFilesToDatabase(KindergartenDto dto, Kindergarten domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
        Task<FileToDatabase> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
    }
}