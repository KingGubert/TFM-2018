using System.ComponentModel;
using System.Windows.Controls;

namespace TFM.Controls
{
	/// <summary>
	/// Interaktionslogik für TemperatureControl.xaml
	/// Anhand der MarkerGridPositionRow wird der Temperatureanzeiger bewegt, die Property ist exposed und kann vom Host geändert werden
	/// </summary>
	public partial class TemperatureControl : UserControl, INotifyPropertyChanged
	{
		#region properties
		private int m_MarkerGridPositionRow;
		public int MarkerGridPositionColumn { get; } = 1;
		private int m_Temperature { get; set; }

		//Gibt an Wo die Skala Angezeigt wird
		public int MarkerGridPositionRow
		{
			get { return m_MarkerGridPositionRow; }
			private set
			{
				m_MarkerGridPositionRow = value;
				OnPropertyChanged("MarkerGridPositionRow");
			}
		}
		#endregion


		#region constructor

		/// <summary>
		/// Standardconstrcutor - initialisiert die Temperatur bei -30 °C
		/// </summary>
		public TemperatureControl()
		{
			ChangeTemperature(-30);
			InitializeComponent();
		}
		#endregion

		#region methods

		/// <summary>
		/// Bewegt den Marker anhand des Übergebenen Temperaturewertes an die Richtige Stelle der Anzeige
		/// </summary>
		/// <param name="newTemperature"></param>
		private void ChangeTemperature(int newTemperature)
		{
			//Prüfen ob wir nicht schon am Maximum sind
			if (IsMax())
			{
				System.Windows.Forms.MessageBox.Show("Die Temperatur ist bereits am Maximum");
				return;
			}

			m_Temperature = newTemperature;

			switch (newTemperature)
			{
				case -30:
					MarkerGridPositionRow = 21;
					return;
				case -28:
					MarkerGridPositionRow = 19;
					return;
				case -26:
					MarkerGridPositionRow = 18;
					return;
				case -24:
					MarkerGridPositionRow = 17;
					return;
				case -22:
					MarkerGridPositionRow = 16;
					return;
				case -20:
					MarkerGridPositionRow = 15;
					return;
				case -18:
					MarkerGridPositionRow = 14;
					return;
				case -16:
					MarkerGridPositionRow = 13;
					return;
				case -14:
					MarkerGridPositionRow = 12;
					return;
				case -12:
					MarkerGridPositionRow = 11;
					return;
				case -10:
					MarkerGridPositionRow = 10;
					return;
				case -8:
					MarkerGridPositionRow = 9;
					return;
				case -6:
					MarkerGridPositionRow = 8;
					return;
				case -4:
					MarkerGridPositionRow = 7;
					return;
				case -2:
					MarkerGridPositionRow = 6;
					return;
				case 0:
					MarkerGridPositionRow = 5;
					return;
				case +2:
					MarkerGridPositionRow = 4;
					return;
				case +4:
					MarkerGridPositionRow = 3;
					return;
				case +6:
					MarkerGridPositionRow = 2;
					return;
				case +8:
					MarkerGridPositionRow = 1;

					return;
				default:
					break;
			}
		}


		/// <summary>
		/// Gibt die Temperatur aus auf der der TemperaturMarker gerade steht
		/// </summary>
		/// <returns></returns>
		public int GetCurrentTemperature()
		{
			return m_Temperature;
		}


		/// <summary>
		/// Gibt einen Bool zurück ob Temperature Maxed out ist.
		/// </summary>
		/// <returns></returns>
		public bool IsMax()
		{
			return m_Temperature == 8 ? true : false;
		}


		#endregion

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
