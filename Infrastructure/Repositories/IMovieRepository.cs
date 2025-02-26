using Domain;

public interface IMovieRepository
{
    Task<List<Movie>> GetAllAsync();
    Task<Movie> GetByIdAsync(int id);
    Task AddAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(Movie movie);
}
