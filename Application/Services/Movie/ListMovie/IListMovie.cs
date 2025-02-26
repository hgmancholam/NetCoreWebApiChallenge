
namespace Application.Services.Movie.ListMovie
{
    public interface IListMovie
    {
        Task<List<Domain.Movie>> GetAsync();
    }
}
