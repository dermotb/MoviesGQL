using MoviesGQL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesGQL.Services
{
    public interface IMovieService
    {
        Task<Movie> Create(Movie movie);
        Task<bool> Update(Movie movie);
        Task<bool> Delete(int id);
        IQueryable<Movie> GetAll();
    }
}
