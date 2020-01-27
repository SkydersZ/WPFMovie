using MovieMVVM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFMovieManager.Models;

namespace WPFMovieManager.ViewModels.Abstract
{
    public interface IViewModelMovie : IViewModelList<Movie, IDataContext>
    { 
    }
}