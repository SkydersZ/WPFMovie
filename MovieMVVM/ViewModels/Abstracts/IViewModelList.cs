﻿using MovieMVVM;
using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels.Abstracts;

namespace WPFMovieManager.ViewModels.Abstract
{
    public interface IViewModelList<T> : IViewModelWithDataContext<T>
        where T : IDataContext
    {
        #region Propriétés
       
        /// <summary>
        /// Obtient la commande pour supprimer un film
        /// </summary>
        RelayCommand DeleteCommand { get; }

        #endregion

        #region Méthodes

        /// <summary>
        /// Méthode de chargement des données
        /// </summary>
        void LoadData();

        #endregion
    }
}