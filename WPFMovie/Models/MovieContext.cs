using MovieMVVM.Interfaces;
using MovieMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WPFMovieManager.Models
{
    public class MovieContext : FileDataContext
    {
        #region Champs

        /// <summary>
        /// Liste des films
        /// </summary>
        private ObservableCollection<Movie> _Movies;

        #endregion

        #region Propriétés

        /// <summary>
        /// Liste des films
        /// </summary>
        public ObservableCollection<Movie> Movies
        {
            get => this.Movies;
            private set => this.SetProperty(nameof(this.Movies), ref this._Movies, value);
        }
        #endregion

        #region Constructeur

        public MovieContext(string apiRequestedUrl) : base(apiRequestedUrl)
        {
            this._Movies = new ObservableCollection<Movie>();
        }

        #endregion

        #region Méthodes

        public override ObservableCollection<T> GetItems<T>()
        {
            ObservableCollection<T> result;

            if (typeof(T) == typeof(Movie))
            {
                result = this.Movies as ObservableCollection<T>;
            }
            else
            {
                throw new Exception("Le type spécifié n'est pas valide");
            }

            return result;
        }

        #endregion
    }
}