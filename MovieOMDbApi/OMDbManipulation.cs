using MovieOMDbApi.DTO;
using MovieOMDbApi.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Net;

namespace MovieOMDbApi
{
    /// <summary>
    /// Interface contenant les actions réalisable avec l'API
    /// </summary>
    public class OMDbManipulation : IOMDbManipulation
    {
        #region Champs
        private Collection<OMDbManipulation> _Movies;
        #endregion

        #region
        public Collection<OMDbManipulation> Movies
        {
            get => 
        }
        #endregion

        #region Méthodes
        public Collection<OMDbMovieObject> GetAllMovies()
        {
            
        }

        public OMDbMovieObject SearchMovieById(int Id)
        {
            throw new NotImplementedException();
        }

        public OMDbMovieObject SearchMovieByName(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
