using MovieMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFMovie.ViewModels
{
    public class ViewModelAllMovies : ObservableObject
    {
        #region Champs
        private string _Title;
        private string _Data;
        #endregion

        #region Propriétés
        public string Title {
            get => this._Title;
            set => this.SetProperty(nameof(this.Title), ref this._Title, value);
        }

        public string Data
        {
            get => this._Data;
            set => this.SetProperty(nameof(this.Data), ref this._Data, value);
        }
        #endregion

        #region Constructeur
        public ViewModelAllMovies()
        {
            this.Title = "Tous les films disponibles";
            this.Data = "Récupération des films issus de la base de données";
        }
        #endregion
    }
}