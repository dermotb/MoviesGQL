using MoviesGQL.Models;
using MoviesGQL.Services;
using System.Linq;

namespace MoviesGQL.GraphQL
{
    public class Query
    {
        #region Property  
        private readonly IMovieService _movieService;
        #endregion

        #region Constructor  
        public Query(IMovieService movieService)
        {
            _movieService = movieService;
        }
        #endregion

        public IQueryable<Movie> Movies => _movieService.GetAll();
    }
}
