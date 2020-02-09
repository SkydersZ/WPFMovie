using MovieMVVM.Models.Interfaces;
using MovieMVVM.ViewModels.Abstracts;

namespace MovieMVVM.ViewModels
{
    /// <summary>
    /// ViewModel possédant un contexte de données.
    /// </summary>
    /// <typeparam name="M"></typeparam>
    public class ViewModelWithDataContext<M> : ObservableObject, IViewModelWithDataContext<M>
        where M : IDataContext
    {
        #region Champs

        private IDataContext _DataContext;

        private readonly RelayCommand _SaveCommand;

        #endregion

        #region Propriétés

        public IDataContext DataContext
        {
            get => this._DataContext;
            private set => this.SetProperty(nameof(this.DataContext), ref this._DataContext, value);
        }

        public RelayCommand SaveCommand => this._SaveCommand;

        #endregion

        #region Constructeur

        public ViewModelWithDataContext(IDataContext dataContext)
        {
            this._DataContext = dataContext;
            this._SaveCommand = new RelayCommand(this.Save, this.CanSave);
        }

        #endregion

        #region Méthodes
        
        public virtual void LoadData()
        {

        }

        #region SaveCommand

        protected virtual bool CanSave(object parameter) => this.DataContext.CanSave();

        protected virtual void Save(object parameter)
        {
            this.DataContext.Save();
        }

        #endregion

        #endregion
    }
}