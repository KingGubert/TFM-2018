using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TFM.Controls
{
    /// <summary>
    /// Interaktionslogik für TFRTrack.xaml
    /// </summary>
    public partial class TFRTrack : UserControl, INotifyPropertyChanged
	{
		public ObservableCollection<int> Box = new ObservableCollection<int>() { 1, 2 };










        public TFRTrack()
        {
		
            InitializeComponent();
        }

		#region propertychanged
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
		#endregion
	}
}
