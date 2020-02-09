using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels;
using System;
using WPFMovieManager.Models;
using Microsoft.Extensions.DependencyInjection;
using WPFMovieManager.ViewModels.Abstract;
using WPFMovieManager.Models.DTO;
using WPFMovieManager.Interfaces;
using WPFMovie.Services;

namespace WPFMovie.ViewModels
{
    public class ViewModelMovies : ViewModelList<Movie, IDataContext>, IViewModelMovies
    {
        #region Champs
        private readonly IServiceProvider _ServiceProvider;

        //private readonly OMDbService _OMDbService;

        #endregion

        #region Propriétés
        public string Title => "Tous les Films";
        
        public string DataContent => "Voici la page des films disponibles";

        //public OMDbMovieSearchList MovieCollection { get; set; }

        #endregion

        #region Constructeur
        public ViewModelMovies(IServiceProvider serviceProvider) : base(serviceProvider.GetService<IDataContext>())
        {
            this._ServiceProvider = serviceProvider;

            this.LoadData();
        }
        #endregion

        #region Méthodes

        #endregion
    }
}