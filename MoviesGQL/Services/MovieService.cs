using Microsoft.EntityFrameworkCore;
using MoviesGQL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesGQL.Services
{
    public class MovieService : IMovieService
    {
        #region Property  
        private readonly MoviesContext _dbContext;
        #endregion

        #region Constructor  
        public MovieService(MoviesContext databaseContext)
        {
            _dbContext = databaseContext;
        }
        #endregion

        public async Task<Movie> Create(Movie movie)
        {
            var data = new Movie
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Cert = movie.Cert,
                ReleaseDate = movie.ReleaseDate,
                AvgRating = movie.AvgRating
            };
            await _dbContext.Movies.AddAsync(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }

        public IQueryable<Movie> GetAll()
        {
            return _dbContext.Movies.AsQueryable();
        }

        public async Task<bool> Delete(int id)
        {
            Task<Movie> mvTask = _dbContext.Movies.FirstOrDefaultAsync(p => p.MovieID == id);
            Movie mv = mvTask.Result;
            if (mv==null)
            {
                return false;
            }

            _dbContext.Remove(mv);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Movie movie)
        {
            Task<Movie> mvTask = _dbContext.Movies.FirstOrDefaultAsync(p => p.MovieID == movie.MovieID);
            Movie mv = mvTask.Result;
            if (mv == null)
            {
                return false;
            }

            mv.Title = movie.Title;
            mv.Genre = movie.Genre;
            mv.Cert = movie.Cert;
            mv.ReleaseDate = movie.ReleaseDate;
            mv.AvgRating = movie.AvgRating;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }


}

