using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using System.Collections.ObjectModel;

namespace WPFMovieManager.ViewModels.Abstract
{
    public interface IViewModelList<T, M> : IViewModelList<M>
        where T : IObservableObject
        where M : IDataContext 
    {
        #region Propriétés
        
        /// <summary>
        /// Obtient la liste des films
        /// </summary>
        ObservableCollection<T> ItemsSource { get; }
        
        /// <summary>
        /// Obtient ou défini le film sélectionné
        /// </summary>
        T SelectedItem { get; set; }

        #endregion
    }
}