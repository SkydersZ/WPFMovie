using MovieMVVM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WPFMovie.Services;
using WPFMovieManager.Models.DTO;
using WPFMovieManager.ViewModels.Abstract;

namespace WPFMovieManager.Interfaces
{
    //Interface du OMDbService
   public interface IOMDbService
    {
        ObservableCollection<OMDbShortMovieObject> SearchMovieByName(string MovieName);
    }
}
