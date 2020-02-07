using MovieMVVM;
using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFMovieManager.Models;
using WPFMovieManager.ViewModels.Abstract;

namespace WPFMovie.ViewModels
{
    public class ViewModelMyMovies : ViewModelList<Movie, IDataContext>, IViewModelMovies
    {
        #region Propriétés
        public string Title => "Vos films";
        public string Data => "Tous les films que vous avez ajouté à votre collection";
        #endregion

        #region Constructeur
        public ViewModelMyMovies(IDataContext dataContext) : base(dataContext)
        {
            LoadData();
        }
        #endregion
    }
}