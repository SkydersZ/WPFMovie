using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WPFMovieManager.Models.DTO
{
    /// <summary>
    /// Contient les résultats de recherche d'un film sur OMDb.
    /// </summary>
    public class OMDbMovieSearchList
    {
     [JsonProperty("Search")]
     public ObservableCollection<OMDbShortMovieObject> OMDbMovieObjectList { get; set; }
    
     [JsonProperty("Response")]
    public string Response { get; set; }

    [JsonProperty("Error")]
    public string Error { get; set; }

    }   
}
