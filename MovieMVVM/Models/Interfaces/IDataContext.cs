using MovieMVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieMVVM.Models.Interfaces
{
    /// <summary>
    /// Interface de contexte de données
    /// </summary>
    public interface IDataContext : IObservableObject
    {
        #region Méthodes

        /// <summary>
        /// Détermine si le contexte de données peut être sauvegardé.
        /// </summary>
        /// <returns></returns>
        bool CanSave();

        /// <summary>
        ///     Sauvegarde le contexte de données.
        /// </summary>
        void Save();

        /// <summary>
        ///     Obtient la collection des éléments du type spécifié.
        /// </summary>
        /// <typeparam name="T">Type de l'élément de la collection.</typeparam>
        /// <returns>Collection des éléments du type spécifié.</returns>
        ObservableCollection<T> GetItems<T>() where T : IObservableObject; 

        #endregion
    }
}
