using Domain;

namespace Application.Services.Movie.EditMovie
{
    public interface IEditMovie 
    { 
        Task EditAsync(Domain.Movie movie);
     }
}
