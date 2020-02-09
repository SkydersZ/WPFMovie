
using Microsoft.Extensions.DependencyInjection;
using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels;
using System;
using System.Collections.ObjectModel;
using WPFMovieManager.ViewModels.Abstract;

namespace WPFMovie.ViewModels
{
    /// <summary>
    /// ViewModel principal contenant l'ensemble des autres ViewModels.
    /// </summary>
    public class ViewModelMain : ViewModelList<IObservableObject, IDataContext>, IViewModelMain
    {
        #region Champs

        private readonly IServiceProvider _ServiceProvider;

        private IViewModelMovies _ViewModelMovies;

        private IViewModelMyMovies _ViewModelMyMovies;

        private IViewModelSearch _ViewModelSearch;

        #endregion

        #region Propriétés

        /// <summary>
        /// Permet d'obtenir ou défibir le ViewModelMovies
        /// </summary>
        public IViewModelMovies ViewModelMovies
        {
            get => this._ViewModelMovies;
            private set => this.SetProperty(nameof(this.ViewModelMovies), ref this._ViewModelMovies, value);
        }

        /// <summary>
        /// Permet d'obtenir ou défibir le ViewModelMyMovies
        /// </summary>
        public IViewModelMyMovies ViewModelMyMovies
        {
            get => this._ViewModelMyMovies;
            private set => this.SetProperty(nameof(this.ViewModelMyMovies), ref this._ViewModelMyMovies, value);
        }

        /// <summary>
        /// Permet d'obtenir ou défibir le ViewModelSearch
        /// </summary>
        public IViewModelSearch ViewModelSearch
        {
            get => this._ViewModelSearch;
            private set => this.SetProperty(nameof(this.ViewModelSearch), ref this._ViewModelSearch, value);
        }
        #endregion

        #region Constructeur
        public ViewModelMain(IServiceProvider serviceProvider) 
            : base(serviceProvider.GetService<IDataContext>())
        {
            this._ServiceProvider = serviceProvider;
            this._ViewModelMovies = this._ServiceProvider.GetService<IViewModelMovies>();
            this._ViewModelMyMovies = this._ServiceProvider.GetService<IViewModelMyMovies>();
            this._ViewModelSearch = this._ServiceProvider.GetService<IViewModelSearch>();

            this.LoadData();
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Chargement des ViewModels dans le ViewModelMain
        /// </summary>
        public override void LoadData()
        {
            this.ItemsSource = new ObservableCollection<IObservableObject>(new IObservableObject[] { this._ViewModelSearch, this._ViewModelMovies, this._ViewModelMyMovies });
            this.SelectedItem = this._ViewModelSearch;
        }


        #endregion
    }
}