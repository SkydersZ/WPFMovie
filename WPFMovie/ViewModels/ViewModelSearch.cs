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
using WPFMovie.Services;
using WPFMovieManager.Models.DTO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPFMovie.ViewModels
{
    public class ViewModelSearch : ObservableObject, IViewModelSearch
    {
        #region Champs

        /// <summary>
        /// Service permettant de manipuler l'API.
        /// </summary>
        private readonly OMDbService _OMDbService;

        /// <summary>
        /// Valeur du texte de la Textbox du ViewSearch.
        /// </summary>
        private string _SearchValue;

        #endregion

        #region Propriétés

        /// <summary>
        /// Titre de l'onglet
        /// </summary>
        public string Title => "Rechercher des films";

        /// <summary>
        /// Collection des films
        /// </summary>
        public ObservableCollection<OMDbShortMovieObject> MovieCollection { get; set; }

        /// <summary>
        /// Valeur du texte de la Textbox du ViewSearch 
        /// </summary>
        public string SearchValue
        {
            get { return this._SearchValue; }
            set
            {
                if (this._SearchValue != value)
                {
                    this._SearchValue = value;
                    this.NotifyPropertyChanged(nameof(SearchValue));
                    this.ResfreshDataGridMovie();
                }

            }

        }

        #endregion

        #region Constructeur

        public ViewModelSearch()
        {
            //TODO: Remplacer OMDbService par une injection de dépendance (via une interface).
            this._OMDbService = new OMDbService();

            //TODO: Changer d'API pour pouvoir avoir la liste des films par année.
            this.MovieCollection = this._OMDbService.SearchMovieByName("indiana");
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Rafraîchi la DataGrid en fonction de la recherche
        /// </summary>
        private void ResfreshDataGridMovie()
        {
            if (this.MovieCollection != null)
            {
                this.MovieCollection.Clear();
            }

            ObservableCollection<OMDbShortMovieObject> tempList = this._OMDbService.SearchMovieByName(SearchValue);
            if (tempList != null)
            {
                foreach (OMDbShortMovieObject MovieObject in tempList)
                {
                    this.MovieCollection.Add(MovieObject);
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged

        /// <summary>
        /// Handler de l'évènement PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Evènement passé lors d'un changement dans la barre de recherche du film.
        /// </summary>
        /// <param name="propertyName"></param>
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}