using MoviesGQL.Models;
using MoviesGQL.Services;
using System.Threading.Tasks;

namespace MoviesGQL.GraphQL
{
    public class Mutation
    {
        #region Property  
        private readonly IMovieService _MovieService;
        #endregion

        #region Constructor  
        public Mutation(IMovieService movieService)
        {
            _MovieService = movieService;
        }
        #endregion
        public async Task<Movie> Create(Movie movie) => await _MovieService.Create(movie);
        public async Task<bool> Update(Movie movie) => await _MovieService.Update(movie);
        public async Task<bool> Delete(int id) => await _MovieService.Delete(id);

    }
}

