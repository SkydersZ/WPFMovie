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
    interface IDataContext : IObservableObject
    {
        #region Méthodes
        bool CanSave();
        void Save();
        T CreateItem<T>() where T : IObservableObject;
        ObservableCollection<T> GetItems<T>() where T : IObservableObject; 
        #endregion
    }
}
