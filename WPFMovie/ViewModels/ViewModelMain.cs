
using Microsoft.Extensions.DependencyInjection;
using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels;
using System;
using System.Collections.ObjectModel;
using WPFMovieManager.ViewModels.Abstract;

namespace WPFMovie.ViewModels
{
    public class ViewModelMain : ViewModelList<IObservableObject, IDataContext>, IViewModelMain
    {
        #region Champs

        private readonly IServiceProvider _ServiceProvider;

        private IViewModelMovies _ViewModelMovies;

        private IViewModelMyMovies _ViewModelMyMovies;

        private IViewModelHome _ViewModelHome;

        #endregion

        #region Propriétés
        public IViewModelMovies ViewModelMovies
        {
            get => this._ViewModelMovies;
            private set => this.SetProperty(nameof(this.ViewModelMovies), ref this._ViewModelMovies, value);
        }

        public IViewModelMyMovies ViewModelMyMovies
        {
            get => this._ViewModelMyMovies;
            private set => this.SetProperty(nameof(this.ViewModelMyMovies), ref this._ViewModelMyMovies, value);
        }

        public IViewModelHome ViewModelHome
        {
            get => this._ViewModelHome;
            private set => this.SetProperty(nameof(this.ViewModelHome), ref this._ViewModelHome, value);
        }
        #endregion

        #region Constructeur
        public ViewModelMain(IServiceProvider serviceProvider) 
            : base(serviceProvider.GetService<IDataContext>())
        {
            this._ServiceProvider = serviceProvider;
            this._ViewModelMovies = this._ServiceProvider.GetService<IViewModelMovies>();
            this._ViewModelMyMovies = this._ServiceProvider.GetService<IViewModelMyMovies>();
            this._ViewModelHome = this._ServiceProvider.GetService<IViewModelHome>();

            this.LoadData();
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Chargement des ViewModels dans le ViewModelMain
        /// </summary>
        public override void LoadData()
        {
            this.ItemsSource = new ObservableCollection<IObservableObject>(new IObservableObject[] { this._ViewModelHome, this._ViewModelMovies, this._ViewModelMyMovies });
            this.SelectedItem = this._ViewModelMovies;
        }


        #endregion
    }
}