using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WPFMovieManager.Models.DTO;

namespace WPFMovieManager.Models
{
    /// <summary>
    /// TODO: A Modifier, car son rôle est "volé" par les classes DTO "OMDbShortMovieObject" et "OMDbCompleteMovieObject". Pour l'instant elle est inutile.
    /// Cette classe doit contenir l'ensemble des informations des films.
    /// </summary>
    public class Movie : OMDbCompleteMovieObject
    {
        #region Propriétés

        /// <summary>
        /// TODO: A supprimer
        /// </summary>
        public OMDbCompleteMovieObject Movies {
            get => this.Movies;
            private set => this.SetProperty(nameof(Movies), () => this.Movies, (v) => this.Movies = v, value); 
        }

        #endregion

        #region Constructeur

        //TODO: A refaire
        public Movie()
        {
            this.Movies = new Movie(); 
        }
        #endregion
    }
}
