using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;

namespace MovieMVVM.ViewModels.Abstracts
{
    /// <summary>
    /// Interface du ViewModel possédant un contexte données.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IViewModelWithDataContext<T> : IObservableObject 
        where T : IDataContext
    {
        #region Propriétés
        
        /// <summary>
        /// Obtient le contexte des données 
        /// </summary>
        IDataContext DataContext { get; }
        
        /// <summary>
        /// Obtient la commande pour sauvegarder les données
        /// </summary>
        RelayCommand SaveCommand { get; }

        #endregion
    }
}