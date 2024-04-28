using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image); 
    }
}
