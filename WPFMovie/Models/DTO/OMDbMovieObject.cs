using WPFMovieManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MovieMVVM.Models;

namespace WPFMovieManager.Models.DTO
{
    /// <summary>
    /// Classe conmportant les propriétés d'un film OMDb
    /// </summary>
    public class OMDbMovieObject : Entity
    {
        #region Propriétés
        public string Title 
        {
            get => this.Title;
            set => this.SetProperty(nameof(this.Title), () => this.Title, (v) => this.Title = v, value);
        }
        public string Year {
            get => this.Year;
            set => this.SetProperty(nameof(this.Year), () => this.Year, (v) => this.Year = v, value);
        }
        public string Rated 
        { 
            get => this.Rated;
            set => this.SetProperty(nameof(this.Rated), () => this.Rated, (v) => this.Rated = v, value);
        }
        public string Released {
            get => this.Released; 
            set => this.SetProperty(nameof(this.Released), () => this.Released, (v) => this.Released = v, value);
        }
        public string Runtime 
        {
            get => this.Runtime;
            set => this.SetProperty(nameof(this.Runtime), () => this.Runtime, (v) => this.Runtime = v, value);
        }
        public string Genre 
        {
            get => this.Genre;
            set => this.SetProperty(nameof(this.Genre), () => this.Genre, (v) => this.Genre = v, value);
        }
        public string Director 
        {
            get => this.Director; 
            set => this.SetProperty(nameof(this.Director), () => this.Director, (v) => this.Director = v, value);
        }
        public string Writer 
        {
            get => this.Writer;
            set => this.SetProperty(nameof(this.Writer), () => this.Writer, (v) => this.Writer = v, value);
        }
        public string Actors 
        {
            get => this.Actors;
            set => this.SetProperty(nameof(this.Actors), () => this.Actors, (v) => this.Actors = v, value);
        }
        public string Plot 
        {
            get => this.Plot;
            set => this.SetProperty(nameof(this.Plot), () => this.Plot, (v) => this.Plot = v, value);
        }
        public string Language 
        {
            get => this.Language;
            set => this.SetProperty(nameof(this.Language), () => this.Language, (v) => this.Language = v, value);
        }
        public string Country 
        {
            get => this.Country;
            set => this.SetProperty(nameof(this.Country), () => this.Country, (v) => this.Country = v, value);
        }
        public string Awards 
        {
            get => this.Awards;
            set => this.SetProperty(nameof(this.Awards), () => this.Awards, (v) => this.Awards = v, value);
        }
        public string Poster 
        {
            get => this.Poster;
            set => this.SetProperty(nameof(this.Poster), () => this.Poster, (v) => this.Poster = v, value);
        }
        public string Metascore 
        {
            get => this.Metascore;
            set => this.SetProperty(nameof(this.Metascore), () => this.Metascore, (v) => this.Metascore = v, value);
        }
        public string imdbRating 
        {
            get => this.imdbRating;
            set => this.SetProperty(nameof(this.imdbRating), () => this.imdbRating, (v) => this.imdbRating = v, value);
        }
        public string imdbVotes 
        {
            get => this.imdbVotes;
            set => this.SetProperty(nameof(this.imdbVotes), () => this.imdbVotes, (v) => this.imdbVotes = v, value);
        }
        public string imdbID 
        {
            get => this.imdbID;
            set => this.SetProperty(nameof(this.imdbID), () => this.imdbID, (v) => this.imdbID = v, value);
        }
        public string Type 
        {
            get => this.imdbID;
            set => this.SetProperty(nameof(this.Type), () => this.Type, (v) => this.Type = v, value);
        }
        public string Response 
        {
            get => this.Response;
            set => this.SetProperty(nameof(this.Response), () => this.Response, (v) => this.Response = v, value);
        }
        #endregion
    }
}
