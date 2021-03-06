﻿using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFMovieManager.Models;

namespace WPFMovieManager.ViewModels.Abstract
{
    /// <summary>
    /// Interface du ViewModelMovies
    /// </summary>
    public interface IViewModelMovies : IViewModelList<Movie, IDataContext>
    { 
    }
}