using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;

namespace Application.Services.Movie.ListMovie
{
    public class ListMovie(IMovieRepository movieRepository) : IListMovie
    {
        private readonly IMovieRepository _movieRepository = movieRepository;
        public async Task<List<Domain.Movie>> GetAsync()
        {
            return await _movieRepository.GetAllAsync();
        }
    }
}
