
using Microsoft.Extensions.DependencyInjection;
using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels;
using System;
using WPFMovieManager.ViewModels.Abstract;

namespace WPFMovie.ViewModels
{
    public class ViewModelMoviesMain : ViewModelList<IObservableObject, IDataContext>, IViewModelMain
    {
        #region Champs

        private readonly IServiceProvider _ServiceProvider;

        private IViewModelMovie _ViewModelMovie;

        private IViewModelMyMovies _ViewModelMyMovies;

        #endregion

        #region Propriétés
        public IViewModelMovie ViewModelMovie
        {
            get => this._ViewModelMovie;
            private set => this.SetProperty(nameof(this.ViewModelMovie), ref this._ViewModelMovie, value);
        }

        public IViewModelMyMovies ViewModelMyMovies
        {
            get => this._ViewModelMyMovies;
            private set => this.SetProperty(nameof(this.ViewModelMyMovies), ref this._ViewModelMyMovies, value);
        }

        #endregion

        #region Constructeur
        public ViewModelMoviesMain(IServiceProvider serviceProvider) 
            : base(serviceProvider.GetService<IDataContext>())
        {
            this._ServiceProvider = serviceProvider;

            this._ViewModelMovie = this._ServiceProvider.GetService<IViewModelMovie>();
            this._ViewModelMyMovies = this._ServiceProvider.GetService<IViewModelMyMovies>();
        }
        #endregion
    }
}