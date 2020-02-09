using MovieMVVM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieMVVM.Models
{
    /// <summary>
    /// TODO: Cette classe n'est pas vraiment utilisé dans l'application, a intégrer avec l'objet "OMDbShortMovieObject"
    /// Représente une entité avec un identifiant
    /// </summary>
   public abstract class Entity : ObservableObject, IEntity
    {
        #region Champs
        private long _Identifier;
        #endregion

        #region Propriétés
        public long Identifier { 
            get => this._Identifier; 
            set => this.SetProperty(nameof(this.Identifier), ref this._Identifier, value);
        }
        #endregion
    }
}
