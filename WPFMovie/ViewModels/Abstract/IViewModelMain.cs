using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WPFMovieManager.ViewModels.Abstract
{
    /// <summary>
    /// Interface du ViewModel Main regroupant l'ensemble des ViewModels
    /// </summary>
    public interface IViewModelMain : IViewModelList<IObservableObject, IDataContext>
    {
    }
}