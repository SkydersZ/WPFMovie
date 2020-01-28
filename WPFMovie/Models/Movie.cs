﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WPFMovieManager.Models.DTO;

namespace WPFMovieManager.Models
{
    public class Movie : OMDbMovieObject
    {
        #region Propriétés

        public OMDbMovieObject Movies {
            get => this.Movies;
            private set => this.SetProperty(nameof(Movies), () => this.Movies, (v) => this.Movies = v, value); 
        }

        #endregion

        #region Constructeur

        public Movie()
        {
            this.Movies = new Movie(); 
        }
        #endregion
    }
}
