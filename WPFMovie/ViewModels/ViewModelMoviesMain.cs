using MovieMVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WPFMovie.ViewModels
{
    public class ViewModelMoviesMain : ObservableObject
    {
        #region Champs
        private ViewModelMovie _ViewModelAllMovies;
        private ViewModelMyMovies _ViewModelMyMovies;
        private ObservableCollection<ObservableObject> _ViewsModels;
        #endregion

        #region Propriétés
        public ViewModelMovie ViewModelAllMovies
        {
            get => this._ViewModelAllMovies;
            private set => this.SetProperty(nameof(this.ViewModelAllMovies), ref this._ViewModelAllMovies, value);
        }

        public ViewModelMyMovies ViewModelMyMovies
        {
            get => this._ViewModelMyMovies;
            private set => this.SetProperty(nameof(this.ViewModelMyMovies), ref this._ViewModelMyMovies, value);
        }

        public ObservableCollection<ObservableObject> ViewModels
        {
            get => this._ViewsModels;
            private set => this.SetProperty(nameof(this.ViewModels), ref this._ViewsModels, value);
        }
        #endregion

        #region Constructeur
        public ViewModelMoviesMain()
        {
            this.ViewModels = new ObservableCollection<ObservableObject>();
            this.ViewModelAllMovies = new ViewModelMovie();
            this.ViewModelMyMovies = new ViewModelMyMovies();

            this.ViewModels.Add(ViewModelAllMovies);
            this.ViewModels.Add(ViewModelMyMovies);
        }
        #endregion
    }
}