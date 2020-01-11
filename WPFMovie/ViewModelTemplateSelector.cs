using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPFMovie.ViewModels;

namespace WPFMovie
    {
    public class ViewModelTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate template = base.SelectTemplate(item, container);
            
            if(item is ViewModelAllMovies)
            {
                template = Application.Current.Resources["ViewModelAllMoviesTemplate"] as DataTemplate;
            }

            return template;
        }
    }
}