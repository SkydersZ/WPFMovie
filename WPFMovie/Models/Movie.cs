using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WPFMovieManager.Models.DTO;

namespace WPFMovieManager.Models
{
    public class Movie : OMDbMovieObject
    {
        #region Propriétés

        public ObservableCollection<OMDbMovieObject> _AllMovies {
            get => this._AllMovies;
            private set => this.SetProperty(nameof(_AllMovies), () => this._AllMovies, (v) => this._AllMovies = v, value); 
        }

        #endregion

        #region Constructeur

        public Movie()
        {
            this._AllMovies = new ObservableCollection<OMDbMovieObject>(); 
        }
        #endregion
    }
}
