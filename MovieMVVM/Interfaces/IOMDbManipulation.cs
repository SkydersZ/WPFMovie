using MovieMVVM.DTO;
using System.Collections.ObjectModel;

namespace MovieMVVM.Interfaces
{
    /// <summary>
    /// Interface contenant les actions réalisable avec l'API
    /// </summary>
   public interface IOMDbManipulation<T>
    {
        /// <summary>
        /// Recherche un film par son identifiant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T SearchMovieById<T>(int Id) where T: OMDbMovieObject;

        /// <summary>
        /// Recherche un film par son nom
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Name"></param>
        /// <returns></returns>
        public ObservableCollection<T> SearchMovieByName<T>(string Name) where T: OMDbMovieObject;    
    }
}
