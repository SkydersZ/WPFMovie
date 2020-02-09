using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace MovieMVVM.Models
{
    /// <summary>
    /// TODO: Pas utile pour l'instant car la sauvegarde n'est pas encore implémenté dans l'application. Soit à supprimer ou a modifier.
    /// Classe abstraite pour la gestion d'un contexte de données avec sauvegarde dans un unique fichier au format json.
    /// </summary>
    public abstract class FileDataContext : ObservableObject, IFileDataContext
    {
        #region Champs

        private string _FilePath;
        #endregion

        #region Propriétés
        public string FilePath
        {
            get => this._FilePath;
            private set => this.SetProperty(nameof(this.FilePath), ref this._FilePath, value);
        }
        #endregion

        #region Constructeur
        public FileDataContext(string filepath)
        {
            this._FilePath = filepath;
        }
        #endregion

        #region Méthodes
        public virtual bool CanSave() => true;

        public virtual void Save()
        {
            File.WriteAllText(this.FilePath, JsonConvert.SerializeObject(this));
        }

        public abstract ObservableCollection<T> GetItems<T>() where T : IObservableObject;

        public static T Load<T>(string filePath, T defaultContext) where T :  FileDataContext
        {
            T dataContext;

            try
            {
                dataContext = JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
            }
            catch
            {
                dataContext = defaultContext;
            }

            dataContext.FilePath = filePath;

            return dataContext;
        }
        #endregion

    }
}
