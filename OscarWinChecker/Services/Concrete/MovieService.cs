using OscarWinChecker.Exceptions;
using OscarWinChecker.Models;
using OscarWinChecker.Services.Abstract;

namespace OscarWinChecker.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private const string _apiKey = "k_oe24b9zc";
        private const string _baseApiAdress = "https://imdb-api.com";
        private const string _academyAwardName = "Academy Awards, USA";
        private const string _oscarWinName = "Winner Oscar";

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Movie> SearchMovieByTitleAsync(string title)
        {
            var response = await _httpClient.GetFromJsonAsync<MovieJson>($"{_baseApiAdress}/en/API/SearchMovie/{_apiKey}/{title}");
            if (response != null && response.Results != null && response.Results?.Count > 0)
            {
                var firstResult = response.Results[0];
                return new Movie
                {
                    Id = firstResult.Id,
                    Title = firstResult.Title
                };
            }
            throw new NotFoundException();
        }

        public async Task<Actor> GetFirstActorFromMovieAsync(Movie movie)
        {
            if (movie != null && !string.IsNullOrEmpty(movie.Id))
            {
                var response = await _httpClient.GetFromJsonAsync<MovieTitle>($"{_baseApiAdress}/en/API/Title/{_apiKey}/{movie.Id}");
                if (response != null && response.StarList?.Count > 0)
                {
                    var firstActor = response.StarList.FirstOrDefault();
                    return new Actor
                    {
                        Id = firstActor.Id,
                        Name = firstActor.Name
                    };
                }
            }
            throw new NotFoundException();
        }

        public bool HasWonOscar(IMBDActor actor)
        {
            var awardEvent = actor.Items.Find(award => award.EventTitle == _academyAwardName);

            if (awardEvent != null)
            {
                return awardEvent.NameAwardEventDetails.Any(item =>
                {
                    return item.Title.Contains(_oscarWinName);
                });
            }
            else
            {
                return false;
            }
        }

        public async Task<IMBDActor> GetActorAwardsAsync(Actor actor)
        {
            if (actor != null && !string.IsNullOrEmpty(actor.Id))
            {
                var response =  await _httpClient.GetFromJsonAsync<IMBDActor>($"{_baseApiAdress}/en/API/NameAwards/{_apiKey}/{actor.Id}");

                if (response != null)
                {
                    return response;
                }
            
            }
            throw new NotFoundException();
        }
    }
}
