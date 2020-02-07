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
using System.ComponentModel;

namespace WPFMovie.ViewModels
{
    public class ViewModelMovies : ViewModelList<Movie, IDataContext>, IViewModelMovies
    {
        #region Champs
        private readonly IServiceProvider _ServiceProvider;

        private readonly Movie movie;
        #endregion

        #region Propriétés
        public string Title => "Tous les Films";

        public string DataContent => "Voici la page des films disponibles";

        #endregion

        #region Constructeur
        public ViewModelMovies(IServiceProvider serviceProvider) : base(serviceProvider.GetService<IDataContext>())
        {
            this._ServiceProvider = serviceProvider;
            this.movie = this._ServiceProvider.GetService<Movie>();
            this.LoadData();
        }
        #endregion

        #region Méthodes

        #endregion
    }
}