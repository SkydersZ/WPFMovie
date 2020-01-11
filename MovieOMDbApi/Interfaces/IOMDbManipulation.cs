using MovieOMDbApi.DTO;
using System.Collections.ObjectModel;

namespace MovieOMDbApi.Interfaces
{
    /// <summary>
    /// Interface contenant les actions réalisable avec l'API
    /// </summary>
    interface IOMDbManipulation
    {
        public OMDbMovieObject SearchMovieById(int Id);
        public OMDbMovieObject SearchMovieByName(int Id);
        public Collection<OMDbMovieObject> GetAllMovies();
    }
}
