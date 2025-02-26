using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Services.Movie.CreateMovie
{
    public class CreateMovie(IMovieRepository movieRepository) : ICreateMovie
    {
        private readonly IMovieRepository _movieRepository = movieRepository;

        public async Task CreateAsync(Domain.Movie model)
        {
            await _movieRepository.AddAsync(model);
        }
    }
}
