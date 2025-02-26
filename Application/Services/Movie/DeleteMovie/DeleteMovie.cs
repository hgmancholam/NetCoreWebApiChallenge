using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;

namespace Application.Services.Movie.DeleteMovie
{
    public class DeleteMovie(IMovieRepository movieRepository) : IDeleteMovie
    {
        private readonly IMovieRepository _movieRepository = movieRepository;
        public async Task DeleteAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie != null)
            {
                await _movieRepository.DeleteAsync(movie);
            }
        }
    }
}
