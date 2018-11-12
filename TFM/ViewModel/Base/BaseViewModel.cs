using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TFM.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //Listen to PropertyChanged Event
        public event PropertyChangedEventHandler PropertyChanged;


        //Call this to fire event
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
