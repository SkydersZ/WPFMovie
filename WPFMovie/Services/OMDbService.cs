using MovieHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net;

namespace WPFMovie.Services
{
    public class OMDbService : IOMDbManipulation<OMDbMovieObject>
    {
        public T SearchMovieById<T>(int Id) where T : OMDbMovieObject
        {
            string URL = $"{Keys.OMDIdUrl}{Id}{Keys.OMDbKeyParameter}{Keys.ApiKey}";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(URL);
                OMDbMovieObject obj = JsonConvert.DeserializeObject<OMDbMovieObject>(json);
                if (obj.Response == "True")
                {
                    return (T)obj;
                }
                return null;
            }
        }
        
        //TODO: Réalise le 
        public ObservableCollection<T> SearchMovieByName<T>(string Name) where T : OMDbMovieObject
        {
            throw new NotImplementedException();
        }
    }
}
