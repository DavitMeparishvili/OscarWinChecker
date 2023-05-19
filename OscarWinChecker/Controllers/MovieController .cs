using Microsoft.AspNetCore.Mvc;
using OscarWinChecker.Exceptions;
using OscarWinChecker.Services.Abstract;

namespace OscarWinChecker.Controllers
{
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("movie/{title}")]
        public async Task<IActionResult> GetMovieInfo(string title)
        {
            try
            {
                var movie = await _movieService.SearchMovieByTitleAsync(title);
                var actor = await _movieService.GetFirstActorFromMovieAsync(movie);
                var ImdbActor = await _movieService.GetActorAwardsAsync(actor);
                var wonOscar = _movieService.HasWonOscar(ImdbActor);

                if (wonOscar)
                {
                    return Ok("End:Success");
                }
                else
                {
                    return BadRequest("End:Error");
                }
            }
            catch(NotFoundException ex)
            {
                return BadRequest("End:Error");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
