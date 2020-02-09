using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MovieMVVM.Interfaces
{
    /// <summary>
    /// Interface qui fournit un mécanisme de prévention de changement de valeur des propriétés.
    /// </summary>
    public interface IObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
    }
}
