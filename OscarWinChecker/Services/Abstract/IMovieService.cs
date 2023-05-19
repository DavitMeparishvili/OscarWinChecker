using OscarWinChecker.Models;

namespace OscarWinChecker.Services.Abstract
{
    public interface IMovieService
    {
        Task<Movie> SearchMovieByTitleAsync(string title);

        Task<Actor> GetFirstActorFromMovieAsync(Movie movie);

        Task<IMBDActor> GetActorAwardsAsync(Actor actor);

        bool HasWonOscar(IMBDActor actor);
    }
}
