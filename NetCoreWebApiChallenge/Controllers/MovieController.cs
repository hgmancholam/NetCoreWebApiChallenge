using Application.Services.Movie.CreateMovie;
using Application.Services.Movie.DeleteMovie;
using Application.Services.Movie.EditMovie;
using Application.Services.Movie.ListMovie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApiChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IListMovie _listMovieService;
        private readonly ICreateMovie _createMovieService;
        private readonly IEditMovie _editMovieService;
        private readonly IDeleteMovie _deleteMovieService;

        public MovieController(IListMovie listMovie, ICreateMovie createMovie, IEditMovie editMovie, IDeleteMovie deleteMovie)
        {
            this._listMovieService = listMovie;
            this._createMovieService = createMovie;
            this._editMovieService = editMovie;
            this._deleteMovieService = deleteMovie;
        }

        [HttpGet]
        public async Task<ActionResult<List<Domain.Movie>>> Get()
        {
            try
            {
                var movies = await _listMovieService.GetAsync();
                return Ok(movies);
            }
            catch(Exception e)
            {
                throw;
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Movie movieModel)
        {
            try
            {
                await _createMovieService.CreateAsync(movieModel);
                return CreatedAtAction(nameof(Get), movieModel);
            }
            catch(Exception e)
            {
                throw;
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Domain.Movie movieModel)
        {
            try
            {
                await _editMovieService.EditAsync(movieModel);
                return NoContent();
            }
            catch(Exception e)
            {
                throw;
            }
         
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _deleteMovieService.DeleteAsync(id);
                return NoContent();
            }
            catch(Exception e)
            {
                throw;
            }
         
        }

    }
}
