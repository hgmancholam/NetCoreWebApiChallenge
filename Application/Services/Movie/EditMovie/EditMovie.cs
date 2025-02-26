using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Movie.EditMovie
{
    public class EditMovie(IMovieRepository movieRepository) : IEditMovie
    {
        private readonly IMovieRepository _movieRepository = movieRepository;
        public async Task EditAsync(Domain.Movie movie)
        {
            await _movieRepository.UpdateAsync(movie);
        }
    }
}
