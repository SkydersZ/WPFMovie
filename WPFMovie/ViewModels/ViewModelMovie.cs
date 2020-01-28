using MovieMVVM;
using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFMovieManager.Models;

namespace WPFMovie.ViewModels
{
    public class ViewModelMovie : ViewModelList<Movie, IDataContext>
    {
        #region Propriétés

        public string Title => "Tous les Films";

        #endregion

        #region Constructeur
        public ViewModelMovie(IDataContext dataContext) : base(dataContext)
        {  
            this.LoadData();
        }
        #endregion

        #region Méthodes
        
        #endregion
    }
}