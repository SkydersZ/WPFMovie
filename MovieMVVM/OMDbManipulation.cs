using MovieMVVM.DTO;
using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Net;

namespace MovieMVVM
{
    /// <summary>
    /// Classe contenant les actions réalisable avec l'API
    /// </summary>
    public abstract class OMDbManipulation : ObservableObject
    {
        #region Champs
        private ObservableCollection<OMDbManipulation> _UserMovies;
        #endregion

        #region Propriétés
        public ObservableCollection<OMDbManipulation> UserMovies
        {
            get => this._UserMovies;
            set => SetProperty(nameof(this.UserMovies), ref this._UserMovies, value);
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Recherche un film par son identifiant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        public abstract T SearchMovieById<T>(int Id) where T : OMDbMovieObject;

        /// <summary>
        /// Recherche un film par son nom
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract ObservableCollection<T> SearchMovieByName<T>(string Name) where T : OMDbMovieObject;

        //OMDbMovieOject = JsonConvert.DeserializeObject(JsonString);
        //UserMovies.Add(OMDbMovieOjbect);
        #endregion
    }
}
