using MovieMVVM;
using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFMovieManager.Models;
using Microsoft.Extensions.DependencyInjection;
using WPFMovieManager.ViewModels.Abstract;

namespace WPFMovie.ViewModels
{
    public class ViewModelMyMovies : ViewModelList<Movie, IDataContext>, IViewModelMyMovies
    {
        #region Champs
        private readonly IServiceProvider _ServiceProvider;

        private readonly Movie movie;
        #endregion

        #region Propriétés
        public string Title => "Vos films";
        public string DataContent => "Tous les films que vous avez ajouté à votre collection";
        #endregion

        #region Constructeur
        public ViewModelMyMovies(IServiceProvider serviceProvider) : base(serviceProvider.GetService<IDataContext>())
        {
            this._ServiceProvider = serviceProvider;
            this.movie = this._ServiceProvider.GetService<Movie>();
            this.LoadData();
        }
        #endregion
    }
}