using ServiceLibrary.Models;

namespace ServiceLibrary
{
    public interface IRandomDriverApiService
    {
        Task<Driver> GetRandomDriver();
    }
}
