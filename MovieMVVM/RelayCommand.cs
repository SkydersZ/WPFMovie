using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MovieMVVM
{
    /// <summary>
    /// Classe contenant les propriétés d'une commande.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Evènements

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

        #region Champs

        private readonly Action<object> _Execute;

        private readonly Func<object, bool> _CanExecute;

        #endregion

        #region Constructeur

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this._CanExecute = canExecute;
        }

        #endregion

        #region Méthodes

        public bool CanExecute(object parameter)
        {
            return this._CanExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            this._Execute(parameter);
        }

        #endregion



    }
}
