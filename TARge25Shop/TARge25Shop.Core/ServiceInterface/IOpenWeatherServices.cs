using System.Threading.Tasks;
using TARge25Shop.Core.Dto;

namespace TARge25Shop.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
        Task<OpenWeatherDto> GetWeatherAsync(string cityName);
    }
}