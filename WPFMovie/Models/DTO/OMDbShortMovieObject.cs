using MovieMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFMovieManager.Models.DTO
{
    /// <summary>
    /// Contient les propréiéts réduite issu de OMDb
    /// </summary>
   public class OMDbShortMovieObject
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("imdbID")]
        public string imdbID { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

    }
}
