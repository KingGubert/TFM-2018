using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFM.Model
{
    /// <summary>
    /// Dient als Base zum vererbenen des INotifyPropertyChanged Interfaces und zur bereitstellung der entpsprechenden Methoden
    /// </summary>
    public class NotifiableObject : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Feuert das Propertychanged event der übergebenen Property
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
