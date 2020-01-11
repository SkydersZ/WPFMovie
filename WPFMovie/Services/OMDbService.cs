using MovieHelpers;
using MovieMVVM;
using MovieMVVM.DTO;
using MovieMVVM.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

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

        public ObservableCollection<T> SearchMovieByName<T>(string Name) where T : OMDbMovieObject
        {
            throw new NotImplementedException();
        }
    }
}
