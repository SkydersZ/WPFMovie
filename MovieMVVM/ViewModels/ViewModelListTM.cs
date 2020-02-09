using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WPFMovieManager.ViewModels.Abstract;

namespace MovieMVVM.ViewModels
{
    /// <summary>
    /// Classe permettant d'associer un ViewModel avec un contexte de données.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    public class ViewModelList<T, M> : ViewModelWithDataContext<M>, IViewModelList<T, M>
        where T : IObservableObject
        where M : IDataContext
    {
        #region Champs

        /// <summary>
        /// Liste des films
        /// </summary>
        private ObservableCollection<T> _ItemsSource;

        /// <summary>
        ///  Film sélectionné
        /// </summary>
        private T _SelectedItem;

        /// <summary>
        /// Commande supprimant un film
        /// </summary>
        private readonly RelayCommand _DeleteCommand;

        #endregion

        #region Propriétés

        public ObservableCollection<T> ItemsSource
        {
            get => this._ItemsSource;
            protected set => this.SetProperty(nameof(this.ItemsSource), ref this._ItemsSource, value);
        }

        public T SelectedItem
        {
            get => this._SelectedItem;
            set => this.SetProperty(nameof(this.SelectedItem), ref this._SelectedItem, value);
        }

        public virtual RelayCommand DeleteCommand => this._DeleteCommand;

        #endregion

        #region Constructor

        public ViewModelList(M dataContext)
            : base(dataContext)
        {
            this._DeleteCommand = new RelayCommand(this.Delete, this.CanDelete);
        }

        #endregion

        #region Méthodes

        public override void LoadData()
        {
            base.LoadData();
            this.ItemsSource = new ObservableCollection<T>(this.DataContext.GetItems<T>());
        }

        #region DeleteCommand

        /// <summary>
        /// Méthode d'exécution de la commande <see cref="DeleteCommand"/>
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void Delete(object parameter)
        {
            T itemToDelete = (T)parameter ?? this.SelectedItem;

            if (itemToDelete != null)
            {
                this.ItemsSource.Remove(itemToDelete);
                this.DataContext.GetItems<T>().Remove(itemToDelete);
            }
        }

        /// <summary>
        /// Méthode qui véfifie si la commande <see cref="CanDelete"/> peut être exécutée
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanDelete(object parameter) => parameter is T || this._SelectedItem != null;

        #endregion

        #endregion
    }
}
